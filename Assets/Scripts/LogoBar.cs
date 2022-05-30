using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoBar : MonoBehaviour
{
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Adjust(){
        RectTransform parent = rectTransform.parent.GetComponent<RectTransform>();
        Vector2 size = rectTransform.offsetMin;
        rectTransform.offsetMin = new Vector2(size.x, 960.0F / Screen.width * Screen.height - 40);
    }

    // Update is called once per frame
    void Update()
    {
        Adjust();
    }
}
