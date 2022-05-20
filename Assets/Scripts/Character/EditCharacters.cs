using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using EditorLogics;
using TMPro;

public class EditCharacters : MonoBehaviour
{
    public static EditorData editorData;
    public static MapData mapData;

    //UI
    public GameObject CharactersUI;
    public GameObject CharacterUI;
    public GameObject MapUI;
    public GameObject CharacterTag;
    public GameObject Add;

    //Singleton
    public static EditCharacters Instance;

    //Infos
    public List<CharacterPanel> CharacterPanels;
    [HideInInspector]
    public CharacterInfo curCharacter;
    [HideInInspector]
    public CharacterPanel curPanel;
    [HideInInspector]
    public List<CharacterInfo> CharacterInfoList;

    
    private int maxCharacters = 8;

    void Start()
    {
        editorData = new EditorData();
        mapData = new MapData();
        CharacterPanels = new List<CharacterPanel>();
        CharacterInfoList = new List<CharacterInfo>();
        Vector3 pos = new Vector3(-320, 0, 0);
        Add.transform.localPosition = pos;
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
        MapUI.SetActive(true);
        EditorData.Instance.SetCharacterInfoList(CharacterInfoList);
    }

    public void AddButton()
    {
        if(CharacterPanels.Count >= maxCharacters)
        {
            return;
        }

        int idx = CharacterPanels.Count;
        Vector3 pos = new Vector3(-320, 0, 0);
        pos.x += 80 * idx;
        GameObject cur = Instantiate(CharacterTag, CharactersUI.transform);
        cur.transform.localPosition = pos;
        Vector3 addPos = new Vector3(-320 + 80 * (idx + 1), 0, 0);
        Add.transform.localPosition = addPos;
        curPanel = cur.GetComponent(typeof(CharacterPanel)) as CharacterPanel;
        CharacterPanels.Add(curPanel);
        SwitchToCharacter();
    }

    public void DeleteButton(CharacterPanel panel){
        CharacterPanels.Remove(panel);
        Destroy(panel.gameObject);
        RePosition();
    }

    public void RePosition()
    {
        for(int i =0; i < CharacterPanels.Count; i++)
        {
            Vector3 pos = new Vector3(-320 + 80 * i, 0, 0);
            CharacterPanels[i].transform.localPosition = pos;
        }
        Vector3 addPos = new Vector3(-320 + 80 * CharacterPanels.Count, 0, 0);
        Add.transform.localPosition = addPos;
        
    }

    public void SwitchToCharacter()
    {
        curCharacter = curPanel.info;
        CharacterEditor characterEditor = CharacterUI.GetComponent<CharacterEditor>();
        CharactersUI.SetActive(false);
        CharacterUI.SetActive(true);
        characterEditor.onActive(curCharacter);
    }

    public void SwitchToCharacters()
    {
        CharactersUI.SetActive(true);
        CharacterUI.SetActive(false);
    }

    public void AddInfo(){
        CharacterInfoList.Add(curCharacter);
    }
}
