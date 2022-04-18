using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentObject;
    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(CurrentObject);
        }
    }
}
