using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{

    public bool spikesOff;
    public float timer;

    public bool tick1;
    public bool tick2;
    public bool tick3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > 0)
        {
            spikesOff = true;
        }
        if(timer <= 0)
        {
            spikesOff = false;
            tick1 = false;
            tick2 = false;
            tick3 = false;
        }
        if(timer < 0)
        {
            timer = 0;
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

       
    }
}
