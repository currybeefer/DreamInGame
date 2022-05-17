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
    public List<CharacterInfo> CharacterInfoList = new List<CharacterInfo>();


    // Start is called before the first frame update
    void Start()
    {
        CharacterInfoList = new List<CharacterInfo>();
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
        
        //每完成一个人物的编辑，向编辑器数据中存储对应的人物信息
        CharacterInfo curCharacterInfo = editor.curCharacter;
        //CharacterInfoList.Add(curCharacterInfo);
        EditCharacters.editorData.CharacterInfoList.Add(curCharacterInfo);
        
        editor.curPanel.identityDisplay.sprite = identityDisplay.sprite;
        editor.curPanel.name.text = name.text;
        editor.SwitchToCharacters();
    }

}
