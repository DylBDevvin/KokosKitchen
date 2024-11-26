using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageOnTriggerEnterScript : MonoBehaviour
{

    public int attackDamage;
    public StormButtonScript sbs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.tag != "parry")
        {
            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
        }

       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StormButton"))
        {
            sbs = other.GetComponent<StormButtonScript>();
            Debug.Log("Lightning storm button HAS in fact, with all due measure and all due respect, been hitty witty what da griddy white boy.");
            sbs.ScreenNuke();
        }
    }
}