using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    [Serializable]
    public class PointerEvent : UnityEvent {}

    [FormerlySerializedAs("onPointerEnter")]
    [SerializeField]
    private PointerEvent m_OnPointerEnter = new PointerEvent();

    [FormerlySerializedAs("onPointerExit")]
    [SerializeField]
    private PointerEvent m_OnPointerExit = new PointerEvent();

    [FormerlySerializedAs("onPointerClick")]
    [SerializeField]
    private PointerEvent m_OnPointerClick = new PointerEvent();

    public PointerEvent onPointerEnter
    {
        get { return m_OnPointerEnter; }
        set { m_OnPointerEnter = value; }
    }

    public PointerEvent onPointerExit
    {
        get { return m_OnPointerExit; }
        set { m_OnPointerExit = value; }
    }

    public PointerEvent onPointerClick
    {
        get { return m_OnPointerClick; }
        set { m_OnPointerClick = value; }
    }


   
    //UI--------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_OnPointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_OnPointerExit.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_OnPointerClick.Invoke();
    }
}



