using System;
using System.Collections;
using System.Collections.Generic;
using EditorLogics;
using Unity.Mathematics;
//using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using TMPro;

/**
 * ��ͼ������
 * ������Ʒ���϶���
 */

public class MapInteractions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Background;
    public GameObject CollideMap;
    public GameObject TempImage;
    public GameObject ObjectPrefab;
    public GameObject ColliderImage;
    public GameObject Message;
    public GameObject Maps;
    public Sprite EraserImage;
    public Sprite RotationImage;
    public Sprite DraggingImage;
    public TMP_Text mapFilter;
    public TMP_Text objectFilter;
    public string curMapPath;


    public ButtonGroup Tools;
    /**
     * -1 represent normal 
     * 0 represent object
     * 1 represent collider
     * 2 represent eraser
     * 3 represents rotation
     */
    public int ObjectType = -1;

    //Singleton
    public static MapInteractions Instance;

    
    private bool Dragging = false;
    private Vector3 MouseIniPos;
    public int ColliderSize = 32;

    //��ײ��
    [HideInInspector]
    public bool[,] collideMap;
    public List<GameObject> colliders;

    //��Ʒ
    [HideInInspector]
    public List<GameObject> objects;
    public List<ObjectInfo> objectInfoList;

    private void Start()
    {
        objects = new List<GameObject>();
        colliders = new List<GameObject>();
        objectInfoList = new List<ObjectInfo>();
        SetMap();
    }

    void Awake()
    {
        if(Instance == null || Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        Background = gameObject;
    }

    public void OnEnable(){
        Image BackgroundImage = Background.GetComponent<Image>();
        if(BackgroundImage.sprite == null){
            ChangeBackground selected = Maps.GetComponentInChildren<ChangeBackground>();
            selected.BackgroundButton(selected.gameObject);
        }
    }

    void Update()
    {
        if (TempImage.GetComponent<Image>().sprite != null)
        {
            TempImage.transform.position = Input.mousePosition;
        }
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
        if (ObjectType == 4 && !Input.GetMouseButton(0) && !Input.GetMouseButton(1)){
            Dragging = false;
        } else if (ObjectType != 4 && Input.GetMouseButtonUp(1))
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
            AddObject();
        } else if (ObjectType == 1 && Input.GetMouseButtonDown(0) && TempImage.GetComponent<Image>().sprite != null)
        {
            AddCollider();
        } else if (ObjectType == 4&& Input.GetMouseButtonDown(0)){
            MouseIniPos = Input.mousePosition;
            Dragging = true;
        }
    }

    public void SetToCollider()
    {
        ObjectType = 1;
        TempImage.GetComponent<Image>().sprite = ColliderImage.GetComponent<Image>().sprite;
        TempImage.GetComponent<Image>().color = ColliderImage.GetComponent<Image>().color;
        TempImage.GetComponent<Image>().rectTransform.sizeDelta = ColliderImage.GetComponent<Image>().rectTransform.sizeDelta;
    }

    public void ClearTempImage()
    {
        TempImage.GetComponent<Image>().sprite = null;
        TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }


    /**
     * Set MyMap after changing background
     */

    public void SaveMapPath(string name){
        curMapPath = "Maps/" + mapFilter.text + "/" + name; 
    }

    public void SetMap()
    {
        //Set the Collide Map
        Vector2 map_size = Background.GetComponent<Image>().rectTransform.sizeDelta;
        collideMap = new bool[Mathf.CeilToInt(map_size.y / ColliderSize), Mathf.CeilToInt(map_size.x / ColliderSize)];
        ClearMap();
    }

    public void ClearMap(){
        foreach(GameObject col in colliders)
        {
            Destroy(col);
        }
        colliders.Clear();
        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }
        objects.Clear();
        objectInfoList.Clear();
    }

    public void Clear(){
        ClearMap();

    }

    public void AddCollider()
    {
        Vector3 mousePos = TempImage.transform.localPosition;
        Vector3 mapPos = GetMapPosition();
        float mapWidth = GetMapWidth(), mapHeight = GetMapHeight();
        int indexOfWidth = Mathf.FloorToInt(Math.Abs(mousePos.x - (mapPos.x - mapWidth / 2)) / ColliderSize);
        int indexOfHeight = Mathf.FloorToInt(Math.Abs(mousePos.y - (mapPos.y + mapHeight / 2)) / ColliderSize);

        float posOfWidth = -mapWidth / 2 + indexOfWidth * ColliderSize + ColliderSize / 2;
        float posOfHeight = mapHeight / 2 - indexOfHeight * ColliderSize - ColliderSize / 2;
        Debug.Log(posOfWidth);
        Debug.Log(posOfHeight);

        GameObject AddedObject = Instantiate(ColliderImage, CollideMap.transform);
        AddedObject.transform.localPosition = new Vector2(posOfWidth, posOfHeight);
        colliders.Add(AddedObject);
        collideMap[indexOfHeight, indexOfWidth] = true;
    }

    public void RemoveCollider(GameObject collider)
    {
        Vector3 mousePos = TempImage.transform.localPosition;
        Vector3 mapPos = GetMapPosition();
        float mapWidth = GetMapWidth(), mapHeight = GetMapHeight();
        int indexOfWidth = Mathf.FloorToInt(Math.Abs(mousePos.x - (mapPos.x - mapWidth / 2)) / ColliderSize);
        int indexOfHeight = Mathf.FloorToInt(Math.Abs(mousePos.y - (mapPos.y + mapHeight / 2)) / ColliderSize);

        colliders.Remove(collider);
        collideMap[indexOfHeight, indexOfWidth] = false;
    }

    public void AddObject()
    {
        Image curImage = TempImage.GetComponent<Image>();
        GameObject AddedObject = Instantiate(ObjectPrefab, Background.transform);
        AddedObject.transform.position = Input.mousePosition;
        AddedObject.GetComponent<Image>().sprite = curImage.sprite;
        AddedObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(curImage.sprite.texture.width, curImage.sprite.texture.height);
        TMP_InputField messageInput = Message.GetComponent<TMP_InputField>();
        AddedObject.GetComponent<ObjectScript>().message = messageInput.text;
        objects.Add(AddedObject);

        ObjectInfo curObjectInfo = new ObjectInfo();
        string path = "Objects/" + objectFilter.text +"/" +  curImage.sprite.name;
        curObjectInfo.SetImage(path);
        curObjectInfo.SetMessage(Message.GetComponent<TMP_InputField>().text);
        curObjectInfo.SetPosition(Input.mousePosition);
        objectInfoList.Add(curObjectInfo);
        messageInput.text = "";
    }

    public void RemoveObject(GameObject obj)
    {
        int idx = objects.IndexOf(obj);
        objects.RemoveAt(idx);
        objectInfoList.RemoveAt(idx);
    }

    private Vector3 GetMapPosition()
    {
        return Background.transform.localPosition;
    }

    private float GetMapWidth()
    {
        return Background.GetComponent<RectTransform>().rect.width;
    }
    
    private float GetMapHeight()
    {
        return Background.GetComponent<RectTransform>().rect.height;
    }

    public void SetToNormal(){
        ObjectType = -1;
        ClearTempImage();
    }

    public void SetToEraser(){
        ObjectType = 2;
        ClearTempImage();
        TempImage.GetComponent<Image>().sprite = EraserImage;
        TempImage.GetComponent<Image>().color = Color.white;
        TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);

    }

    public void SetToRotate(){
        ObjectType = 3;
        TempImage.GetComponent<Image>().sprite = RotationImage;
        TempImage.GetComponent<Image>().color = Color.white;
        TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
    }

    public void SetToDrag(){
        ObjectType = 4;
        TempImage.GetComponent<Image>().sprite = DraggingImage;
        TempImage.GetComponent<Image>().color = Color.white;
        TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
    }
}
