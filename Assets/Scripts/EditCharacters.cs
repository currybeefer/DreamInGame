using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    public GameObject CharacterTag;

    //[HideInInspector]
    public List<CharacterInfo> CharacterInfos;

    private CharacterInfo curCharacter_;

    public void Start()
    {
        CharacterInfos = new List<CharacterInfo>();
        CharacterInfos.Clear();
    }

    public void NextButton()
    {
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(false);
    }

    public void AddButton()
    {
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(true);

        CharacterInfo newInfo = new CharacterInfo();
        CharacterInfos.Add(newInfo);
        curCharacter_ = newInfo;

    }

    public void SaveButton()
    {
        CharacterInfo.IdentityType identity;
        if (Detective.isOn)
        {
            identity = CharacterInfo.IdentityType.Detective;
        } else if (Suspect.isOn)
        {
            identity = CharacterInfo.IdentityType.Suspect;
        } else
        {
            identity = CharacterInfo.IdentityType.Murder;
        }
        curCharacter_.SetIdentity(identity);
        string name = Name.text;
        string story = Story.text;

        curCharacter_.SetName(name);
        curCharacter_.SetStory(story);

        CharacterUI.SetActive(false);
        CharactersUI.SetActive(true);

        //Update UI
        int idx = CharacterInfos.Count - 1;
        Vector3 pos = new Vector3(-6, 1.5f, 0);
        pos.x += 2 * (idx % 7);
        if (idx >= 7)
        {
            pos.y = -1;
        }
        GameObject cur = Instantiate(CharacterTag, pos, Quaternion.identity, CharactersUI.transform);
        Text text = cur.GetComponentInChildren(typeof(Text)) as Text;
        text.text = name;
    }

    public void DeleteButton()
    {
        CharacterInfos.Remove(curCharacter_);
        CharactersUI.SetActive(true);
        CharacterUI.SetActive(false);
    }
}
