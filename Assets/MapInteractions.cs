using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapInteractions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Background;
    public GameObject TempImage;
    public GameObject ObjectPrefab;

    private bool Dragging = false;
    private Vector3 MouseIniPos;
    void Update()
    {
        if (Dragging)
        {
            Vector3 diff = Input.mousePosition - MouseIniPos;
            Background.transform.position += diff;
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
        } else if (Input.GetMouseButtonDown(0) && TempImage.GetComponent<Image>().sprite != null)
        {
            Image curImage = TempImage.GetComponent<Image>();
            GameObject AddedObject = Instantiate(ObjectPrefab, Background.transform);
            AddedObject.transform.position = Input.mousePosition;
            AddedObject.GetComponent<Image>().sprite = curImage.sprite;
            AddedObject.GetComponent<Image>().rectTransform.sizeDelta = curImage.sprite.textureRect.size;
        }
    }
}
