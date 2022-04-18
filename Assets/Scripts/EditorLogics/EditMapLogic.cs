using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMapLogic : MonoBehaviour
{
    public GameObject MapLoopScroll;
    public GameObject ObjectLoopScroll;
    public GameObject CharacterUI;
    public GameObject MapUI;
    public GameObject GameUI;
    public GameObject TempImage;

    public void MapButton()
    {
        MapLoopScroll.SetActive(true);
        ObjectLoopScroll.SetActive(false);
    }

    public void ObjectButton()
    {
        MapLoopScroll.SetActive(false);
        ObjectLoopScroll.SetActive(true);
    }

    public void BackButton()
    {
        MapUI.SetActive(false);
        CharacterUI.SetActive(true);
    }

    public void NextButton()
    {
        MapUI.SetActive(false);
        GameUI.SetActive(true);
    }

    public void ClearObjectTempImage()
    {
        TempImage.GetComponent<Image>().sprite = null;
        TempImage.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }
}
