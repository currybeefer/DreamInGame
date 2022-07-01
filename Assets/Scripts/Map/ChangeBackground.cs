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
        GameObject Background = MapInteractions.Instance.gameObject;
        Image BackgroundImage = Background.GetComponent<Image>();
        BackgroundImage.sprite = currentScrollCell.GetComponent<Image>().sprite;
        BackgroundImage.color = Color.white;
        BackgroundImage.rectTransform.sizeDelta = currentScrollCell.GetComponent<Image>().sprite.textureRect.size;
        Background.GetComponent<MapInteractions>().SetMap();
        MapInteractions.Instance.SaveMapPath(BackgroundImage.sprite.name);
    }
}
