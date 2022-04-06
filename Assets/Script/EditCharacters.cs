using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditCharacters : MonoBehaviour
{
    //UI
    public GameObject CharactersUI;
    public GameObject CharacterUI;
    public Toggle Detective;
    public Toggle Suspect;
    public Toggle Murderer;
    public InputField Name;
    public InputField Story;


    public void NextButton()
    {
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(false);
    }

    public void AddButton()
    {
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(true);
    }

    public void DetectiveToggle()
    {
        Suspect.isOn = false;
        Murderer.isOn = false;
    }

    public void SuspectToggle()
    {
        Detective.isOn = false;
        Murderer.isOn = false;
    }

    public void MurdererToggle()
    {
        Detective.isOn = false;
        Suspect.isOn = false;
    }

    public void SaveButton()
    {
        //To Do: Save current character
        /*
        int identity = CharacterClass.DETECTIVE;
        if (Suspect.isOn == true)
        {
            identity = CharacterClass.SUSPECT;
        } else if (Murderer.isOn == true)
        {
            identity = CharacterClass.MURDERER;
        }
        string name = Name.text;
        string story = Story.text;
        */
        
        CharacterUI.SetActive(false);
        CharactersUI.SetActive(true);
    }
}
