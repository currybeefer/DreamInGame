using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Åö×²Îïprefab
 */
public class ObjectScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentObject;
    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (CurrentObject.transform.parent.GetComponent<MapInteractions>().ObjectType == 0)
            {
                CurrentObject.transform.parent.GetComponent<MapInteractions>().RemoveObject(CurrentObject);
                Destroy(CurrentObject);
            }
        }
    }
}
