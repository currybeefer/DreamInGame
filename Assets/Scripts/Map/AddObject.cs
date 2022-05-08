using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * �����б��е���Ʒ��ť
 */
public class AddObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void AddObjectButton(GameObject currentScrollCell)
    {

        GameObject Temp = MapInteractions.Instance.TempImage;
        Image TempImage = Temp.GetComponent<Image>();
        TempImage.sprite = currentScrollCell.GetComponent<Image>().sprite;
        TempImage.color = Color.white;
        TempImage.rectTransform.sizeDelta = currentScrollCell.GetComponent<Image>().sprite.textureRect.size;
        MapInteractions.Instance.ObjectType = 0;
        MapInteractions.Instance.Tools.SelectNone();
    }
}
