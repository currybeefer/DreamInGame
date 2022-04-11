using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EditCharacters : MonoBehaviour
{
    //UI
    public GameObject CharactersUI;
    public GameObject CharacterUI;
    public Toggle Detective;
    public Toggle Suspect;
    public Toggle Murderer;
    public TMP_InputField Name;
    public TMP_InputField Story;
    public GameObject CharacterTag;

    //Singleton
    public static EditCharacters Instance;

    //Infos
    public List<CharacterPanel> CharacterPanels;
    [HideInInspector]
    public CharacterInfo curCharacter_;
    [HideInInspector]
    public CharacterPanel curPanel;
    //Others
    private int initialXPos = -400;
    private int maxCharacters = 8;

    void Start()
    {

        CharacterPanels = new List<CharacterPanel>();
    }

    void Awake()
    {
        if(Instance == null || Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void NextButton()
    {
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(false);
    }

    public void AddButton()
    {
        if(CharacterPanels.Count >= maxCharacters)
        {
            return;
        }

        int idx = CharacterPanels.Count;
        Vector3 pos = new Vector3(-400, 0, 0);
        pos.x += 100 * idx;
        GameObject cur = Instantiate(CharacterTag, CharactersUI.transform);
        cur.transform.localPosition = pos;
        curPanel = cur.GetComponent(typeof(CharacterPanel)) as CharacterPanel;
        CharacterPanels.Add(curPanel);
        SwitchToCharacter();


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

        curPanel.name.text = name;
        SwitchToCharacters();
    }

    public void DeleteButton()
    {
        CharacterPanels.Remove(curPanel);
        Destroy(curPanel.gameObject);
        RePosition();
        
        SwitchToCharacters();
    }

    public void RePosition()
    {
        for(int i =0; i < CharacterPanels.Count; i++)
        {
            Vector3 pos = new Vector3(-400 + 100 * i, 0, 0);
            CharacterPanels[i].transform.localPosition = pos;
        }
    }

    public void SwitchToCharacter()
    {
        curCharacter_ = curPanel.info;
        Name.text = curCharacter_.GetName();
        Story.text = curCharacter_.GetStory();
        CharacterInfo.IdentityType identity = curCharacter_.GetIdentity();
        Detective.SetIsOnWithoutNotify(false);
        Suspect.SetIsOnWithoutNotify(false);
        Murderer.SetIsOnWithoutNotify(false);
        if (identity == CharacterInfo.IdentityType.Detective)
        {
            Detective.SetIsOnWithoutNotify(true);


        } else if(identity == CharacterInfo.IdentityType.Suspect)
        {
            Suspect.SetIsOnWithoutNotify(true);
        }
        else
        {
            Murderer.SetIsOnWithoutNotify(true);
        }
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(true);
    }

    public void SwitchToCharacters()
    {
        CharactersUI.SetActive(true);
        CharacterUI.SetActive(false);
    }
}
