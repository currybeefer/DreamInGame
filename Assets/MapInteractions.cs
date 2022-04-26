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


    private bool Dragging = false;
    private Vector3 MouseIniPos;
    private bool[,] collideMap;
    

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
            AddedObject.transform.position = Input.mousePosition;
        }
    }

    /**
     * Set MyMap after changing background
     */
    public void SetMap()
    {
        //Set the Collide Map
        Vector2 map_size = Background.GetComponent<Image>().rectTransform.sizeDelta;
        collideMap = new bool[Mathf.CeilToInt(map_size.x / 20), Mathf.CeilToInt(map_size.y / 20)];
    }

    public Vector2 AddCollider()
    {
        Vector2 mousePos = Input.mousePosition;
        return mousePos;
    }









    public void AddCollideObj(GameObject obj)
    {
        GameObject Temp = obj.transform.parent.GetChild(0).GetChild(1).gameObject;
        Image TempImage = Temp.GetComponent<Image>();
        //TODO 这里需要用sprite.create新建一张红色图片，长宽按照pixel来
        TempImage.sprite = obj.GetComponent<Image>().sprite;
        TempImage.color = Color.white;
        TempImage.rectTransform.sizeDelta = obj.GetComponent<Image>().sprite.textureRect.size;
    }
    
    //TODO 仿照OnPointerDown编写插表示碰撞的红色图片的函数

    private float posXForInsertImage;
    private float posYForInsertImage;
    public void SetCollide()
    {
        const int collideMapSize = 20;
        bool[,] collideMap = new bool[collideMapSize,collideMapSize];
        Vector3 mousePos = TempImage.transform.localPosition;
        Vector3 mapPos = GetMapPosition();
        float mapWidth = GetMapWidth(), mapHeight = GetMapHeight();
        float pixelOfWidth = mapWidth / collideMapSize;
        float pixelOfHeight = mapHeight / collideMapSize;
        int indexOfWidth = Mathf.CeilToInt(Math.Abs(mousePos.x - (mapPos.x - mapWidth/2)) / pixelOfWidth);
        //y坐标轴指向屏幕上方，但是数组的下标越往下越大，所以用加
        int indexOfHeight = Mathf.CeilToInt(Math.Abs(mousePos.y - (mapPos.y + mapHeight/2)) / pixelOfHeight);

        posXForInsertImage = (mapPos.x - mapWidth/2) + (indexOfWidth - 1) * pixelOfWidth + pixelOfWidth / 2;
        posYForInsertImage = (mapPos.y + mapHeight/2) - (indexOfHeight - 1) * pixelOfHeight - pixelOfHeight / 2;
        Debug.Log("x坐标" + posXForInsertImage + ",y坐标" + posYForInsertImage);
        
        collideMap[indexOfWidth - 1, indexOfHeight - 1] = true;
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
