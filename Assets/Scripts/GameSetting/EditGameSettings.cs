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
    public GameObject MapUI;
    public GameObject GameUI;
    public TMP_InputField GameTitle;
    public TMP_InputField GameTime;
    public TMP_InputField EndMessage;
    public GameObject FinishPage;

    /// <summary>
    /// Move back to map editor
    /// </summary>
    public void BackButton()
    {
        MapUI.SetActive(true);
        GameUI.SetActive(false);
    }

    /// <summary>
    /// Create Json data and send to backend
    /// </summary>
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
        string dataJsonStr = data.ToString();
        dataJsonStr = dataJsonStr.Replace("\n", "\\n");
        print(dataJsonStr);
        //String jsonFilePath = "D:/DreamInGame/test.json";
        //File.WriteAllText(jsonFilePath, dataJsonStr, System.Text.Encoding.UTF8);

        EditorLogics.Network.SendJsonByHttpPost(dataJsonStr);
        //string url = "https://api.dreamin.land/game_info_post/";
        //StartCoroutine(Upload(url, dataJsonStr));
        GameUI.SetActive(false);
        FinishPage.SetActive(true);
    }

    /// <summary>
    /// Clear everything
    /// </summary>
    public void ClearSettings(){
        GameTitle.text = "";
        EndMessage.text = "";
        GameTime.text = "";

    }

    /// <summary>
    /// Upload data to backend
    /// </summary>
    /// <param name="url"></param>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    IEnumerator Upload(string url, string jsonData)
    {
        WWWForm form = new WWWForm();
        Encoding encoding = Encoding.UTF8;
        byte[] buffer = encoding.GetBytes(jsonData);
        form.AddBinaryData("game", buffer);

        using (UnityWebRequest www = UnityWebRequest.Post(url,jsonData))
        {
            
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
