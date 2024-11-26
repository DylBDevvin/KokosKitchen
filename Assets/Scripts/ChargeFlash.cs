using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeFlash : MonoBehaviour
{
    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;
    public FlashScript2 fs2;
    public PlayerMovement pm;


    private void Start()
    {
        fs2 = FindObjectOfType<FlashScript2>();
    }
    void Update()
    {
        if (pm.chargeShotUnlocked)
        {


            if (Input.GetButtonDown("Fire1") && ready == false)
            {
                downTime = Time.time;
                pressTime = downTime + countDown;
                ready = true;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                ready = false;
            }
            if (Time.time >= pressTime && ready == true)
            {
                ready = false;
                Debug.Log("yesss");
                fs2.Flash();
                SoundManagerScript.PlaySound("chargeFullSE");
            }
        }
    }
}
