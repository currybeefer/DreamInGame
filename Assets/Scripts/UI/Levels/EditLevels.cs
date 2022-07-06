using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditLevels : MonoBehaviour
{
    public GameObject CharactersUI;
    public GameObject LevelsUI;
    public GameObject GameSettingUI;
    public void nextButton()
    {
        LevelsUI.SetActive(false);
        GameSettingUI.SetActive(true);
    }

    public void backButton()
    {
        LevelsUI.SetActive(false);
        CharactersUI.SetActive(true);
    }
}
