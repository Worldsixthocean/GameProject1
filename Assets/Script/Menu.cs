using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{   
    public GameObject[] menu;
    private int Id;
    // Start is called before the first frame update
    void Start()
    {
        Id=Random.Range(0, menu.Length);
    }

    // Update is called once per frame
    void Update()
    {   

        if(Input.GetKeyDown(KeyCode.Space)){
            menu[Id].SetActive(false);
            Id=Random.Range(0, menu.Length);
            Debug.Log(Id);
            menu[Id].SetActive(true);
        }

        



        
    }
    
}
