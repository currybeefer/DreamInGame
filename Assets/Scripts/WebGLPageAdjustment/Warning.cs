using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Warning : MonoBehaviour
{
    //Singleton
    public static Warning Instance;

    public TMP_Text message;
    public GameObject warning;
    public GameObject cover;

    public void SetEmptyMessage(string warning){
        message.text = warning + " cannot be empty";
    }

    public void SetMessage(string warning){
        message.text = warning;
    }

    public void Show(){
        warning.SetActive(true);
        cover.SetActive(true);
    }

    void Awake()
    {
        if(Instance == null || Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
