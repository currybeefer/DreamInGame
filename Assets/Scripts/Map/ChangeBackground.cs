using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * �����б��еı�����ť
 */

public class ChangeBackground : MonoBehaviour
{
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
