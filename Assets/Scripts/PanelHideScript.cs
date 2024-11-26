using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHideScript : MonoBehaviour
{

    public GameObject inventoryUI;
    public bool open;
    



    private void Start()
    { 
        open = false;
        inventoryUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.X))
        //{
           // open = !open;
           //  inventoryUI.SetActive(open);
        //   }
        
    }

  
}
