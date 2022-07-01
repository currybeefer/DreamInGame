using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustedToScreenSize : MonoBehaviour
{
    public float heightRatio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Adjust();
    }

    public void Adjust(){
        float h = 960.0F / Screen.width * Screen.height * heightRatio;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, h);
    }
}
