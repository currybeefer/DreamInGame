using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterPanel : MonoBehaviour
{
    public CharacterInfo info;
    public Button btn;
    public TMP_Text name;
    // Start is called before the first frame update
    void Awake()
    {
        btn.onClick.AddListener(() =>
        {
            EditCharacters editor = EditCharacters.Instance;
            editor.curPanel = this;
            editor.SwitchToCharacter();
        });
    }

}
