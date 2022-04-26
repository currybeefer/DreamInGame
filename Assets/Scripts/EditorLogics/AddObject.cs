using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void AddObjectButton(GameObject currentScrollCell)
    {
        GameObject Temp = currentScrollCell.transform.parent.parent.parent.GetChild(0).GetChild(2).gameObject;
        Image TempImage = Temp.GetComponent<Image>();
        TempImage.sprite = currentScrollCell.GetComponent<Image>().sprite;
        TempImage.color = Color.white;
        TempImage.rectTransform.sizeDelta = currentScrollCell.GetComponent<Image>().sprite.textureRect.size;
    }
}
