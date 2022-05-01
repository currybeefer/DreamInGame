using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEditor : MonoBehaviour
{
    public ButtonGroup btnGroup;
    public GameObject mapBtn;
    public GameObject objectBtn;
    // Start is called before the first frame update
    void Start()
    {
        btnGroup.Select(mapBtn);
        mapBtn.GetComponent<Button>().onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
