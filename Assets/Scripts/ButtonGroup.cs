using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
    public Button[] ButtonList;
    public Image curButton;
    public Color selectedColor;
    public Color highlightedColor;
    public Color pressedColor;
    public Color nomralColor;
    // Start is called before the first frame update
    void Start()
    {
        ButtonList = GetComponentsInChildren<Button>();
    }

    public void Select(Image selected){
        if(curButton != null){
        }

    }


}
