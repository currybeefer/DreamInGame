using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMapLogic : MonoBehaviour
{
    public GameObject MapScrollBar;
    public GameObject ObjectScrollBar;
    public GameObject CharacterUI;
    public GameObject MapUI;
    public void MapButton()
    {
        MapScrollBar.SetActive(true);
        ObjectScrollBar.SetActive(false);
    }

    public void ObjectButton()
    {
        MapScrollBar.SetActive(false);
        ObjectScrollBar.SetActive(true);
    }

    public void BackButton()
    {
        MapUI.SetActive(false);
        CharacterUI.SetActive(true);
    }
}
