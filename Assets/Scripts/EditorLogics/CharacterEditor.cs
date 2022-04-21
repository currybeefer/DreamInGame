using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CharacterEditor : MonoBehaviour
{
    public IdentityEditor identityEditor;
    public StoryEditor storyEditor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onActive(CharacterInfo info){
        identityEditor.gameObject.SetActive(true);
        storyEditor.gameObject.SetActive(false);
        CharacterInfo.IdentityType identity = info.GetIdentity();
        if (identity == CharacterInfo.IdentityType.Detective)
        {
            identityEditor.detectiveButton.Select();
            identityEditor.SelectIdentity("Detective");
        } else if(identity == CharacterInfo.IdentityType.Suspect)
        {
            identityEditor.suspectButton.Select();
            identityEditor.SelectIdentity("Suspect");
        }else
        {
            identityEditor.murdererButton.Select();
            identityEditor.SelectIdentity("Murderer");
        }
        storyEditor.name.text = info.GetName();
        storyEditor.story.text = info.GetStory();

    }
}
