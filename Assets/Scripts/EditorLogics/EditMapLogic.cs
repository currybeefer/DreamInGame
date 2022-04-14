using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMapLogic : MonoBehaviour
{
    public GameObject MapLoopScroll;
    public GameObject ObjectLoopScroll;
    public GameObject CharacterUI;
    public GameObject MapUI;
    public GameObject GameUI;
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
}
