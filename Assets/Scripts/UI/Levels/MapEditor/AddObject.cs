using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Onlick event of object scroll cells
/// </summary>
public class AddObject : MonoBehaviour
{
    /// <summary>
    /// Change the temp image in scene onclick
    /// </summary>
    /// <param name="currentScrollCell"></param>
    public void AddObjectButton(GameObject currentScrollCell)
    {

        GameObject Temp = MapInteractions.Instance.TempImage;
        Image TempImage = Temp.GetComponent<Image>();
        TempImage.sprite = currentScrollCell.transform.GetChild(0).GetComponent<Image>().sprite;
        TempImage.color = Color.white;
        Texture tex = currentScrollCell.transform.GetChild(0).GetComponent<Image>().sprite.texture;
        TempImage.rectTransform.sizeDelta = new Vector2(tex.width, tex.height);
        MapInteractions.Instance.ObjectType = 0;
        MapInteractions.Instance.Tools.SelectNone();
    }
}
