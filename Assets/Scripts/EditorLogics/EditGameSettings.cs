using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditGameSettings : MonoBehaviour
{
    public GameObject MapUI;
    public GameObject GameUI;
    public InputField GameTitle;
    public InputField GameTime;
    public InputField EndMessage;

    public void BackButton()
    {
        MapUI.SetActive(true);
        GameUI.SetActive(false);
    }

    public void SaveButton()
    {

    }
}
