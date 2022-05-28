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
    public GameObject FinishPage;

    public void BackButton()
    {
        MapUI.SetActive(true);
        GameUI.SetActive(false);
    }


    public void SaveButton()
    {
        if(GameTitle.text==""){
            Warning.Instance.SetEmptyMessage("GameTitle");
            Warning.Instance.Show();
            return;
        }
        if(GameTime.text==""){
            Warning.Instance.SetEmptyMessage("GameTime");
            Warning.Instance.Show();
            return;
        }
        if(EndMessage.text==""){
            Warning.Instance.SetEmptyMessage("Endmessage");
            Warning.Instance.Show();
            return;
        }
        EditorData data = EditorData.Instance;
        data.SetName(GameTitle.text);
        data.SetEnd(EndMessage.text);
        data.SetLength(int.Parse(GameTime.text));
        String dataJsonStr = data.ToString();
        print(dataJsonStr);
        //String jsonFilePath = "D:/DreamInGame/test.json";
        //File.WriteAllText(jsonFilePath, dataJsonStr, System.Text.Encoding.UTF8);
        
        EditorGameManager.SendJsonByHttpPost(dataJsonStr);
        GameUI.SetActive(false);
        FinishPage.SetActive(true);
    }

    public void ClearSettings(){
        GameTitle.text = "";
        EndMessage.text = "";
        GameTime.text = "";

    }
}
