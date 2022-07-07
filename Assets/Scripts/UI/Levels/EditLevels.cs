using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditLevels : MonoBehaviour
{
    //UI
    public GameObject CharactersUI;
    public GameObject LevelsUI;
    public GameObject LevelUI;
    public GameObject GameSettingUI;
    public GameObject LevelTag;
    public GameObject Add;

    //Data
    public List<LevelPanel> LevelPanels;
    public List<LevelInfo> LevelInfos;
    [HideInInspector]
    public LevelPanel curPanel;

    //Singleton
    public static EditLevels Instance;

    //Constant
    private int maxLevels = 5;



    public void NextButton()
    {
        LevelsUI.SetActive(false);
        GameSettingUI.SetActive(true);
    }

    public void BackButton()
    {
        LevelsUI.SetActive(false);
        CharactersUI.SetActive(true);
    }

    public void SwitchToLevel()
    {
        LevelsUI.SetActive(false);
        LevelUI.SetActive(true);
    }

    /// <summary>
    /// Create a new character
    /// </summary>
    public void AddButton()
    {
        int idx = LevelPanels.Count;
        Vector3 pos = new Vector3(-300, 0, 0);
        pos.x += 120 * idx;
        GameObject cur = Instantiate(LevelTag, LevelsUI.transform);
        cur.transform.localPosition = pos;
        Vector3 addPos = new Vector3(-300 + 120 * (idx + 1), 0, 0);
        Add.transform.localPosition = addPos;
        curPanel = cur.GetComponent(typeof(LevelPanel)) as LevelPanel;
        LevelPanels.Add(curPanel);
        if (LevelPanels.Count >= maxLevels)
        {
            Add.SetActive(false);
        }
        SwitchToLevel();
    }

    public void DeleteButton(LevelPanel panel)
    {
        int idx = LevelPanels.IndexOf(panel);
        //if (idx < LevelInfos.Count)
        //{
        //    LevelInfos.RemoveAt(idx);
        //}
        LevelPanels.Remove(panel);
        Destroy(panel.gameObject);
        RePosition();
    }

    public void RePosition()
    {
        for (int i = 0; i < LevelPanels.Count; i++)
        {
            Vector3 pos = new Vector3(-300 + 120 * i, 0, 0);
            LevelPanels[i].transform.localPosition = pos;
        }
        Vector3 addPos = new Vector3(-300 + 120 * LevelPanels.Count, 0, 0);
        Add.transform.localPosition = addPos;
        if (LevelPanels.Count < maxLevels)
        {
            Add.SetActive(true);
        }
    }
}
