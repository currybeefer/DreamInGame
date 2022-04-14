using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPage : MonoBehaviour
{
    public void CreateGameButton()
    {
        SceneManager.LoadScene(1);
    }
}
