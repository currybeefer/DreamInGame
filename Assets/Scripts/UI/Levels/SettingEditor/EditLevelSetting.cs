using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EditLevelSetting : MonoBehaviour
{
    //UI
    public GameObject LevelsUI;
    public GameObject LevelUI;
    public GameObject MapEditorUI;
    public GameObject GameSettingEditorUI;

    public TMP_InputField Title;
    public TMP_InputField Duration;
    public TMP_InputField Summary;

    public GameObject LevelsEditor;

    #region Buttons
    public void BackButton()
    {
        MapEditorUI.SetActive(true);
        GameSettingEditorUI.SetActive(false);
    }

    public void SaveButton()
    {
        if (Title.text == "")
        {
            Warning.Instance.SetEmptyMessage("GameTitle");
            Warning.Instance.Show();
            return;
        }

        if (Duration.text == "")
        {
            Warning.Instance.SetEmptyMessage("GameTitle");
            Warning.Instance.Show();
            return;
        }

        if (Summary.text == "")
        {
            Warning.Instance.SetEmptyMessage("Endmessage");
            Warning.Instance.Show();
            return;
        }

        LevelsUI.SetActive(true);
        LevelUI.SetActive(false);
        MapEditorUI.SetActive(true);
        GameSettingEditorUI.SetActive(false);

        //Save Data
        EditLevels levels = EditLevels.Instance;
        EditMap map = EditMap.Instance;
        levels.curPanel.GetLevelInfo().SetBackground(map.BackgroundPath);
        levels.curPanel.GetLevelInfo().SetCollideMap(map.ColliderMap);
        levels.curPanel.GetLevelInfo().SetObejcts(map.ObjectInfoList);
        levels.curPanel.GetLevelInfo().SetTitle(Title.text);
        levels.curPanel.GetLevelInfo().SetDuration(int.Parse(Duration.text));
        levels.curPanel.GetLevelInfo().SetSummary(Summary.text);
        levels.curPanel.UpdatePanel(Title.text, Duration.text);
        levels.FinishAdding();

        //Clear Data
        map.ClearMap();
    }

    #endregion
}
