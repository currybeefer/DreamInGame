using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    public LevelInfo info;

    private void Start()
    {
        info = new LevelInfo();
    }
    public void OnClick()
    {
        EditLevels editor = EditLevels.Instance;
        editor.curPanel = this;
        editor.SwitchToLevel();
    }

    public void Delete()
    {
        EditLevels editor = EditLevels.Instance;
        editor.DeleteButton(this);
    }

    public LevelInfo GetLevelInfo()
    {
        return info;
    }
}
