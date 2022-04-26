using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MapInteractions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Background;
    public GameObject CollideMap;
    public GameObject TempImage;
    public GameObject ObjectPrefab;
    public GameObject ColliderImage;
    /**
     * 0 represent object
     * 1 represent collider
     */
    public int ObjectType = -1;

    private int ColliderSize = 20;
    private bool Dragging = false;
    private Vector3 MouseIniPos;
    private bool[,] collideMap;
    private List<GameObject> colliders = new List<GameObject>();
    

    private void Start()
    {
        SetMap();
    }

    void Update()
    {
        if (Dragging)
        {
            Vector3 diff = Input.mousePosition - MouseIniPos;
            Background.transform.position += diff;
            CollideMap.transform.position += diff;
            MouseIniPos = Input.mousePosition;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(1))
        {
            Dragging = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            MouseIniPos = Input.mousePosition;
            Dragging = true;
        } else if (ObjectType == 0 && Input.GetMouseButtonDown(0) && TempImage.GetComponent<Image>().sprite != null)
        {
            Image curImage = TempImage.GetComponent<Image>();
            GameObject AddedObject = Instantiate(ObjectPrefab, Background.transform);
            AddedObject.transform.position = Input.mousePosition;
            AddedObject.GetComponent<Image>().sprite = curImage.sprite;
            AddedObject.GetComponent<Image>().rectTransform.sizeDelta = curImage.sprite.textureRect.size;
        } else if (ObjectType == 1)
        {
            GameObject AddedObject = Instantiate(ColliderImage, CollideMap.transform);
            colliders.Add(AddedObject);
            AddedObject.transform.localPosition = AddCollider();
        }
    }

    /**
     * Set MyMap after changing background
     */
    public void SetMap()
    {
        //Set the Collide Map
        Vector2 map_size = Background.GetComponent<Image>().rectTransform.sizeDelta;
        collideMap = new bool[Mathf.CeilToInt(map_size.y / ColliderSize), Mathf.CeilToInt(map_size.x / ColliderSize)];
        for (int i = 0; i < colliders.Count; i++)
        {
            Destroy(colliders[i]);
        }
        colliders.Clear();
    }

    public Vector2 AddCollider()
    {
        Vector3 mousePos = TempImage.transform.localPosition;
        Vector3 mapPos = GetMapPosition();
        float mapWidth = GetMapWidth(), mapHeight = GetMapHeight();
        int indexOfWidth = Mathf.FloorToInt(Math.Abs(mousePos.x - (mapPos.x - mapWidth / 2)) / ColliderSize);
        //y坐标轴指向屏幕上方，但是数组的下标越往下越大，所以用加
        int indexOfHeight = Mathf.FloorToInt(Math.Abs(mousePos.y - (mapPos.y + mapHeight / 2)) / ColliderSize);
        collideMap[indexOfHeight, indexOfWidth] = true;

        float posOfWidth = -mapWidth / 2 + indexOfWidth * ColliderSize + 10;
        float posOfHeight = mapHeight / 2 - indexOfHeight * ColliderSize - 10;

        return new Vector2(posOfWidth, posOfHeight);
    }

    public Vector3 GetMapPosition()
    {
        return Background.transform.localPosition;
    }

    public float GetMapWidth()
    {
        return Background.GetComponent<RectTransform>().rect.width;
    }
    
    public float GetMapHeight()
    {
        return Background.GetComponent<RectTransform>().rect.height;
    }
}
