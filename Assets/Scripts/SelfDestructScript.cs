using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{

    public GameObject parentLaser;
    public bool laser;
    public cheriBossScript cs;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public void TurnOff()
    {
        if (laser)
        {
            parentLaser.SetActive(false);
        }
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    public void DestroyLasers()
    {
        cs.DestroyLasersTrue();
    }

    
}
