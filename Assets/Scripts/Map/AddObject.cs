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
        TempImage.sprite = currentScrollCell.transform.GetChild(0).GetComponent<Image>().sprite;
        TempImage.color = Color.white;
        Texture tex = currentScrollCell.transform.GetChild(0).GetComponent<Image>().sprite.texture;
        TempImage.rectTransform.sizeDelta = new Vector2(tex.width, tex.height);
        MapInteractions.Instance.ObjectType = 0;
        MapInteractions.Instance.Tools.SelectNone();
    }
}
