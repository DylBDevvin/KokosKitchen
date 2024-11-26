using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallScript : MonoBehaviour
{

    public Vector3 increase = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 max = new Vector3(5.0f, 5.0f, 5.0f);

    public Rigidbody2D rb;

    public bool increasing;
    public bool maxSize;
    public bool canGrow;

    public float waitTimer;
    public float seTimer;

    // Start is called before the first frame update
    void Start()
    {
        canGrow = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (increasing && !maxSize)
        {
            if (canGrow)
            {
                canGrow = false;
                transform.localScale += increase;
                StartCoroutine(CanGrowReset());
            }  
        }

        if(transform.localScale.x >= max.x)
        {
            transform.localScale = max;
            maxSize = true;
        }

        if (transform.localScale.x < max.x)
        {
            maxSize = false;
        }

        if (increasing == false)
        {
            rb.velocity = Vector2.zero;        
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerMovement>().change != Vector3.zero) //If player is NOT still, if player is MOVING
            {
                increasing = true;
                SoundManagerScript.PlaySound("snow");
            }
            //if (other.GetComponent<PlayerMovement>().change == Vector3.zero) //If player is NOT still, if player is MOVING
            //{
               // increasing = false;
          //  }


        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            increasing = false;
            rb.angularVelocity = 0;
        }
    }

    public IEnumerator CanGrowReset()
    {
        yield return new WaitForSeconds(waitTimer);
        canGrow = true;
    }

    
}
