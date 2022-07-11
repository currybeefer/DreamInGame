using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Onlick event of background scroll cells
/// </summary>
public class ChangeBackground : MonoBehaviour
{
    /// <summary>
    /// Change the background image in scene onclick
    /// </summary>
    /// <param name="currentScrollCell"></param>
    public void BackgroundButton(GameObject currentScrollCell)
    {
        GameObject Background = EditMap.Instance.Background;
        Image BackgroundImage = Background.GetComponent<Image>();
        BackgroundImage.sprite = currentScrollCell.GetComponent<Image>().sprite;
        BackgroundImage.color = Color.white;
        BackgroundImage.rectTransform.sizeDelta = currentScrollCell.GetComponent<Image>().sprite.textureRect.size;
        EditMap.Instance.ClearMap();
        EditMap.Instance.SaveBackgroundPath(BackgroundImage.sprite.name);
    }
}
