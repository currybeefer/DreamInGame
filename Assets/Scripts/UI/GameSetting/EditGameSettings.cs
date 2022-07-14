using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using EditorLogics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Net;
using System.Text;

/// <summary>
/// UI logics of game settings editor
/// </summary>
public class EditGameSettings : MonoBehaviour
{
    public GameObject LevelsUI;
    public GameObject GameUI;
    public TMP_InputField GameTitle;
    public TMP_InputField EndMessage;
    public GameObject FinishPage;

    //Singleton
    public static EditGameSettings Instance;

    void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    /// <summary>
    /// Move back to map editor
    /// </summary>
    public void BackButton()
    {
        LevelsUI.SetActive(true);
        GameUI.SetActive(false);
    }

    /// <summary>
    /// Create Json data and send to backend
    /// </summary>
    public void SaveButton()
    {
        if (GameTitle.text == "")
        {
            Warning.Instance.SetEmptyMessage("GameTitle");
            Warning.Instance.Show();
            return;
        }

        if (EndMessage.text == "")
        {
            Warning.Instance.SetEmptyMessage("Endmessage");
            Warning.Instance.Show();
            return;
        }

        EditCharacters.Instance.SaveData();
        EditLevels.Instance.SaveData();
        EditorData data = EditorData.Instance;
        data.SetName(GameTitle.text);
        data.SetEnd(EndMessage.text);
        string dataJsonStr = data.ToString();
        dataJsonStr = dataJsonStr.Replace("\n", "\\n");
        print(dataJsonStr);
        //String jsonFilePath = "D:/DreamInGame/test.json";
        //File.WriteAllText(jsonFilePath, dataJsonStr, System.Text.Encoding.UTF8);

        //EditorLogics.Network.SendJsonByHttpPost(dataJsonStr);
        //string url = "https://api.dreamin.land/game_info_post/";
        //StartCoroutine(Upload(url, dataJsonStr));
        GameUI.SetActive(false);
        FinishPage.SetActive(true);
    }

    /// <summary>
    /// Clear everything
    /// </summary>
    public void ClearSettings()
    {
        GameTitle.text = "";
        EndMessage.text = "";
    }
}
