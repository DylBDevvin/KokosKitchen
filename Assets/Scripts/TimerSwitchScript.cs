using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSwitchScript : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite ActiveSprite;
    public Sprite OnSprite;

    public SpriteRenderer sr;

    public bool hit;
    public bool check;
    public float countdown;
    public float countdown2;
    public float lim1;
    public float lim2;

    public float total;
    public bool playSe = true;
    public bool playSe2 = true;

    public GameObject door;

    public SpikeManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sm = FindObjectOfType<SpikeManager>();
        total = lim2 + lim1;

    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            sr.sprite = ActiveSprite;
            countdown += Time.deltaTime;
        }
        
        if(countdown >= lim1)
        {
            sr.sprite = OnSprite;
            if (playSe)
            {


                SoundManagerScript.PlaySound("puzzClear");
                playSe = false;
            }
            door.GetComponent<InteractionObject>().OpenDoor();
            countdown2 += Time.deltaTime;
            //sm.spikesOff = true;
            //if (!check)
            //{
                //sm.timer += total;
                //check = true;
            //}
            //Open door/Retreat spikes
        }

        if (countdown2 >= (lim2 - 1))
        {
            if (playSe2)
            {
                SoundManagerScript.PlaySound("spike");
                playSe2 = false;
            }
        }
        if(countdown2 >= lim2)
        {
            sr.sprite = OffSprite;
            //sm.spikesOff = false;
            door.GetComponent<InteractionObject>().CloseDoor();
            hit = false;
            check = false;
            countdown = 0;
            countdown2 = 0;
            playSe2 = true;
            playSe = true;




            //Close door/return spikes
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KokoBullet") || other.CompareTag("EnemyBullet"))
        {
            if (!hit)
            {
                sm.timer = total;
            }
            hit = true;

        }
    }
}
