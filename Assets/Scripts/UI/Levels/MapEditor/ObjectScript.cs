using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Object Script
/// </summary>
public class ObjectScript : MonoBehaviour, IPointerClickHandler
{
    public string message = null;
    /// <summary>
    /// Handle events onclick
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
            switch(MapInteractions.Instance.ObjectType){
                case -1:
                    ShowInfo();
                    break;
                case 2:
                    Remove();
                    break;
                case 3:
                    Rotate();
                    break;
            }
    }

    /// <summary>
    /// Destroy this object
    /// </summary>
    private void Remove(){
        EditMap.Instance.RemoveObject(gameObject);
        Destroy(gameObject, 0);
    }

    private void ShowInfo(){

    }

    private void Rotate(){

    }
}
