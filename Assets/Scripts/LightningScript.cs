using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    // Start is called before the first frame update

    //Create Hitbox (set active)
    //Get Rid Of Hitbox (set inactive)
    //Delete GameObject?

    //public ChickenScript cs;

    

    void Start()
    {
        //cs = FindObjectOfType<ChickenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void LightningEnable()
    //{
        //cs.hbActive = true; 
        //Debug.Log("ITS ACTIVE");
    //}

    //public void LightningDisable()
    //{
        //cs.hbActive = false;
    //}

    public void LightningDelete()
    {
        Destroy(gameObject);       
    }
}
