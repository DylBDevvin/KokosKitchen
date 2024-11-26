using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatZone : MonoBehaviour
{
    public TorchScript ts;
    public bool playerInRange;
    public bool cubeInRange;
    public float timerSubtract;

    public GameObject kokoNormalImage;
    public GameObject kokoFireImage;
    public float faceSwitchTime;

    void Start()
    {
        ts = GetComponentInParent<TorchScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ts.canHeat && playerInRange)
        {
           
        }
        if(ts.canHeat == false)
        {
            gameObject.SetActive(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            kokoNormalImage.SetActive(false);
            kokoFireImage.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            
            kokoNormalImage.SetActive(true);
            kokoFireImage.SetActive(false);
        }
    }
    
}
