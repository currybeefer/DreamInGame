using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Collider script
/// </summary>
public class ColliderScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentObject;
    /// <summary>
    /// Destroy this collider onclick
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (CurrentObject.transform.parent.parent.GetChild(0).GetComponent<MapInteractions>().ObjectType == 1)
            {
                EditMap.Instance.RemoveCollider(CurrentObject);
                Destroy(CurrentObject);
            }
        }
    }
}
