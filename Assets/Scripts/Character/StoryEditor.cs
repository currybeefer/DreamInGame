using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class StoryEditor : MonoBehaviour
{
    public TMP_InputField name;
    public TMP_InputField story;
    public Image identityDisplay;
    public IdentityEditor identityEditor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onActive(Sprite identityImage){
        identityDisplay.sprite = identityImage;
    }

    public void BackButton(){
        identityEditor.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SaveButton(){
        EditCharacters editor = EditCharacters.Instance;
        editor.curCharacter.SetIdentity(identityEditor.curIdentity);
        editor.curCharacter.SetName(name.text);
        editor.curCharacter.SetStory(story.text);
        editor.curPanel.identityDisplay.sprite = identityDisplay.sprite;
        editor.curPanel.name.text = name.text;
        editor.SwitchToCharacters();
    }

}
