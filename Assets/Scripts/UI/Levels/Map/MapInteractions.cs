using System;
using System.Collections;
using System.Collections.Generic;
using EditorLogics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using TMPro;

/// <summary>
/// Map interactions
/// </summary>
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

    // Editing tools
    public ButtonGroup Tools;
    /**
     * -1 represent normal 
     * 0 represent object
     * 1 represent collider
     * 2 represent eraser
     * 3 represent rotation
     * 4 represent drag
     */
    public int ObjectType = -1;

    //Singleton
    public static MapInteractions Instance;

    //Map dragging
    private bool Dragging = false;
    private Vector3 MouseIniPos;

    //Size of colliders
    public int ColliderSize = 32;

    //Path of background image
    public string curMapPath;

    //Colliders
    [HideInInspector]
    public List<GameObject> colliders;
    public bool[,] collideMap;

    //Objects
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

    /// <summary>
    /// Set the Collide Map
    /// </summary>
    public void SetMap()
    {
        Vector2 map_size = Background.GetComponent<Image>().rectTransform.sizeDelta;
        collideMap = new bool[Mathf.CeilToInt(map_size.y / ColliderSize), Mathf.CeilToInt(map_size.x / ColliderSize)];
        ClearMap();
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

    /// <summary>
    /// Handle dragging and temp image following
    /// </summary>
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

    /// <summary>
    /// Stop dragging on pointer up
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (ObjectType == 4 && !Input.GetMouseButton(0) && !Input.GetMouseButton(1)){
            Dragging = false;
        } else if (ObjectType != 4 && Input.GetMouseButtonUp(1))
        {
            Dragging = false;
        }
    }

    /// <summary>
    /// Start dragging on pointer down & Add collider and object on pointer down
    /// </summary>
    /// <param name="eventData"></param>
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
        } else if (ObjectType == 4 && Input.GetMouseButtonDown(0)){
            MouseIniPos = Input.mousePosition;
            Dragging = true;
        }
    }

    /// <summary>
    /// Clear temp image(exit object or collider adding)
    /// </summary>
    public void ClearTempImage()
    {
        TempImage.GetComponent<Image>().sprite = null;
        TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }


    /// <summary>
    /// Change the path of background image
    /// </summary>
    /// <param name="name"></param>
    public void SaveMapPath(string name){
        curMapPath = "Maps/" + mapFilter.text + "/" + name; 
    }

    /// <summary>
    /// Clear map
    /// </summary>
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

    /// <summary>
    /// Clear Map
    /// </summary>
    public void Clear(){
        ClearMap();
    }

    /// <summary>
    /// Add a collider
    /// </summary>
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

    /// <summary>
    /// Remove a collider
    /// </summary>
    /// <param name="collider"></param>
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

    /// <summary>
    /// Add an object
    /// </summary>
    public void AddObject()
    {
        Image curImage = TempImage.GetComponent<Image>();
        GameObject AddedObject = Instantiate(ObjectPrefab, Background.transform);
        AddedObject.transform.position = TempImage.transform.position;
        AddedObject.GetComponent<Image>().sprite = curImage.sprite;
        AddedObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(curImage.sprite.texture.width, curImage.sprite.texture.height);
        TMP_InputField messageInput = Message.GetComponent<TMP_InputField>();
        AddedObject.GetComponent<ObjectScript>().message = messageInput.text;
        objects.Add(AddedObject);

        ObjectInfo curObjectInfo = new ObjectInfo();
        string path = "Objects/" + objectFilter.text +"/" +  curImage.sprite.name;
        curObjectInfo.SetImage(path);
        string m = String.Copy(Message.GetComponent<TMP_InputField>().text);
        curObjectInfo.SetMessage(m);
        curObjectInfo.SetPosition(AddedObject.transform.localPosition);
        objectInfoList.Add(curObjectInfo);
        messageInput.text = "";
    }

    /// <summary>
    /// Remove an object
    /// </summary>
    /// <param name="obj"></param>
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



    /// <summary>
    /// Switch to nothing
    /// </summary>
    public void SetToNormal(){
        ObjectType = -1;
        ClearTempImage();
    }

    /// <summary>
    /// Switch to collider adding tool
    /// </summary>
    public void SetToCollider()
    {
        ObjectType = 1;
        TempImage.GetComponent<Image>().sprite = ColliderImage.GetComponent<Image>().sprite;
        TempImage.GetComponent<Image>().color = ColliderImage.GetComponent<Image>().color;
        TempImage.GetComponent<Image>().rectTransform.sizeDelta = ColliderImage.GetComponent<Image>().rectTransform.sizeDelta;
    }

    /// <summary>
    /// Switch to eraser tools
    /// </summary>
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
