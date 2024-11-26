using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpawnerScript : MonoBehaviour
{
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator")) //If the object comes into collision with the player's feet (description for zeyzey she has no idea what im doing) //yes i understand all of it
        {
            playerInRange = true; //Player is in range
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator")) //If the object comes into collision with the player's feet (description for zeyzey she has no idea what im doing) //yes i understand all of it
        {
            playerInRange = false; //Player is not in range ?????????? what are you talking about. no. :) bc ily
        }
    }
}
