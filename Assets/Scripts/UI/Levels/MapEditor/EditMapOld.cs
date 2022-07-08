using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EditorLogics;
using System;

/// <summary>
/// UI logics of map editor
/// </summary>
public class EditMapLogic : MonoBehaviour
{
    public GameObject LevelsUI;
    public GameObject MapEditorUI;
    public GameObject LevelSettingEditorUI;
    public GameObject MapLoopScroll;
    public GameObject ObjectLoopScroll;
    public GameObject CollideMap;
    public GameObject Background;
    public GameObject Message;
    public GameObject MapSelectBg;
    public GameObject ObjectSelectBg;
    public GameObject mapButton;

    /// <summary>
    /// Clear everything in map
    /// </summary>
    public void ClearMap(){
        MapInteractions mapInteractions = Background.GetComponent<MapInteractions>();
        Background.GetComponent<Image>().sprite = null;
        mapInteractions.OnEnable();
        mapInteractions.SetMap();
        mapInteractions.SetToDrag();
        ButtonGroup Options = mapButton.transform.parent.GetComponent<ButtonGroup>();
        MapButton();
        Options.Select(mapButton);
    }

    /// <summary>
    /// Switch to map scroll view
    /// </summary>
    public void MapButton()
    {
        MapLoopScroll.SetActive(true);
        CollideMap.SetActive(false);
        ObjectLoopScroll.SetActive(false);
        Message.SetActive(false);
        MapSelectBg.SetActive(true);
        ObjectSelectBg.SetActive(false);
    }

    /// <summary>
    /// Switch to object scroll view
    /// </summary>
    public void ObjectButton()
    {
        MapLoopScroll.SetActive(false);
        CollideMap.SetActive(false);
        ObjectLoopScroll.SetActive(true);
        Message.SetActive(true);
        MapSelectBg.SetActive(false);
        ObjectSelectBg.SetActive(true);
    }

    /// <summary>
    /// Switch to collider view
    /// </summary>
    public void CollideButton()
    {
        CollideMap.SetActive(true);
    }

    /// <summary>
    /// Move to Characters editor
    /// </summary>
    public void BackButton()
    {
        EditLevels editor = EditLevels.Instance;
        editor.CancelAdding();
        MapEditorUI.SetActive(false);
        LevelsUI.SetActive(true);
    }

    /// <summary>
    /// Move to game settings editor
    /// </summary>
    public void NextButton()
    {
        MapEditorUI.SetActive(false);
        LevelSettingEditorUI.SetActive(true);
    }
}
