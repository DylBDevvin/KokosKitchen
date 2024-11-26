using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOADER : MonoBehaviour
{
    public PlayerMovement pm;
    public bool saveQuitRestricted;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        if (!saveQuitRestricted)
        {


            pm.SaveToJson();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            saveQuitRestricted = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            saveQuitRestricted = false;
        }
    }
}
