using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour
{

    [SerializeField] private FlashScript flashEffect;
   
    private PatrollingAI pa;


    ///
    private void Start()
    {
        pa = FindObjectOfType<PatrollingAI>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (pa.TakingDmg == true)
        {
            flashEffect.Flash();
        }

    }
}
