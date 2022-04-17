using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{
    public void BackgroundButton(GameObject currentScrollCell)
    {
        GameObject Background = currentScrollCell.transform.parent.parent.parent.GetChild(0).gameObject;
        Image BackgroundImage = Background.GetComponent<Image>();
        BackgroundImage.sprite = currentScrollCell.GetComponent<Image>().sprite;
        BackgroundImage.color = Color.white;
        BackgroundImage.rectTransform.sizeDelta = currentScrollCell.GetComponent<Image>().sprite.textureRect.size;
    }
}
