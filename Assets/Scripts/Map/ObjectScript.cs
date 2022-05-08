using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * ��ײ��prefab
 */
public class ObjectScript : MonoBehaviour, IPointerClickHandler
{
    public string message = null;
    // Start is called before the first frame update
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

    private void Remove(){
        MapInteractions.Instance.objects.Remove(gameObject);
        Destroy(gameObject, 0);
    }

    private void ShowInfo(){

    }

    private void Rotate(){

    }
}
