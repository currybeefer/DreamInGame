using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Map Editor��UI
 */
public class EditMapLogic : MonoBehaviour
{
    public GameObject MapLoopScroll;
    public GameObject ObjectLoopScroll;
    public GameObject CharacterUI;
    public GameObject MapUI;
    public GameObject GameUI;
    public GameObject CollideMap;
    public GameObject Background;
    public GameObject Message;
    public GameObject MapSelectBg;
    public GameObject ObjectSelectBg;

    public void MapButton()
    {
        MapLoopScroll.SetActive(true);
        CollideMap.SetActive(false);
        ObjectLoopScroll.SetActive(false);
        Message.SetActive(false);
        Background.GetComponent<MapInteractions>().ObjectType = -1;
        MapSelectBg.SetActive(true);
        ObjectSelectBg.SetActive(false);
    }

    public void ObjectButton()
    {
        MapLoopScroll.SetActive(false);
        CollideMap.SetActive(false);
        ObjectLoopScroll.SetActive(true);
        Message.SetActive(true);
        Background.GetComponent<MapInteractions>().ObjectType = -1;
        MapSelectBg.SetActive(false);
        ObjectSelectBg.SetActive(true);
    }

    public void CollideButton()
    {
        CollideMap.SetActive(true);
        Background.GetComponent<MapInteractions>().ObjectType = 1;
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
