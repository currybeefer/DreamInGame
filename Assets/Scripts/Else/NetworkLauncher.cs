using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUi;
    public GameObject nameUi;
    public GameObject editorUi;
    public InputField roomName;
    public InputField playerName;

    public void EditButton()
    {
        SceneManager.LoadScene(2);
    }

    public override void OnConnectedToMaster()
    {
        loginUi.SetActive(true);
    }

    public void PlayButton()
    {
        nameUi.SetActive(false);
        editorUi.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = playerName.text;
    }

    public void JoinOrCreateButton()
    {
        if (roomName.text.Length < 2)
        {
            return;
        }

        loginUi.SetActive(false);

        RoomOptions options = new RoomOptions { MaxPlayers = 10 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
