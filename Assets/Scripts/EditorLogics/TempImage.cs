using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempImage : MonoBehaviour
{
    public GameObject currentImage;
    void Update()
    {
        if (currentImage.GetComponent<Image>().sprite != null)
        {
            currentImage.transform.position = Input.mousePosition;
        }
    }
}
