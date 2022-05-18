using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using EditorLogics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditGameSettings : MonoBehaviour
{
    public GameObject MapUI;
    public GameObject GameUI;
    public TMP_InputField GameTitle;
    public TMP_InputField GameTime;
    public TMP_InputField EndMessage;

    public void BackButton()
    {
        MapUI.SetActive(true);
        GameUI.SetActive(false);
    }

    public void SaveButton()
    {
        EditCharacters.editorData.map = EditCharacters.mapData;
        EditCharacters.editorData.name = GameTitle.text;
        EditCharacters.editorData.length = int.Parse(GameTime.text);
        EditCharacters.editorData.end = EndMessage.text;
        if (EditCharacters.editorData.name == "" && EditCharacters.editorData.length <= 0)
        {
            Debug.Log("编辑器数据有误，时间和名字均为空！请检查游戏是否编辑完成。");
            return;
        }
        String dataJsonStr = EditCharacters.editorData.ToString();
        //String jsonFilePath = "D:/DreamInGame/test.json";
        //File.WriteAllText(jsonFilePath, dataJsonStr, System.Text.Encoding.UTF8);
        
        EditorGameManager.SendJsonByHttpPost(dataJsonStr);
    }
}
