using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * ŒÔ∆∑prefab
 */
public class ColliderScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentObject;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (CurrentObject.transform.parent.parent.GetChild(0).GetComponent<MapInteractions>().ObjectType == 1)
            {
                CurrentObject.transform.parent.parent.GetChild(0).GetComponent<MapInteractions>().RemoveCollider(CurrentObject);
                Destroy(CurrentObject);
            }
        }
    }
}
