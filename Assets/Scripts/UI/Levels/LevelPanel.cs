using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    public void OnClick()
    {
        EditLevels editor = EditLevels.Instance;
        editor.SwitchToLevel();
    }

    public void Delete()
    {
        EditLevels editor = EditLevels.Instance;
        editor.DeleteButton(this);
    }
}
