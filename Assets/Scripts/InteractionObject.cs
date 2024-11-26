using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public bool inventory; //if true, object can be stored in inventory
    public bool openable; //if true, object can be opened
    public bool locked; //if true, object is locked
    public bool talks; //if true, object talks to the player
    public string itemType;//This will tell what type of item this object is
    public bool open;
    public bool tutel;
    public bool shop;
    public bool chest;
    public bool rat;
    public bool potion;
    public bool redPotion;
    public bool bluePotion;
    public bool orangePotion;
    public bool egg;
    public bool cuts;
    public bool pearl1;
    public bool pearl2;
    public bool pearl3;
    public bool pearl4;
    public bool pearl5;
    public bool pearl6;
    public bool pearl7;
    public bool pearl8;
    public bool permPowerPotion;
    public bool speedPowerPotion;


    public GameObject itemNeeded; //Item object needs to do interactions
    public string message; //the message this object will give the player
    public string itemNeeded2;



    public Animator anim;
    public Animator ratTextAnim;
    public Collider2D openDoorCollider;
    public Collider2D closeDoorCollider;

    public PlayerMovement pm;
    public PlayerInteract pi;

    


    private void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        pi = FindObjectOfType<PlayerInteract>();
    }

    private void Update()
    {
        
    }

    public void DoInteraction()
    {
        //Picked up and put in inventory
        gameObject.SetActive(false);
    }

    public void UndoInteraction()
    {
        gameObject.SetActive(true);
    }

    public void Open()
    {
        //anim.SetBool("open", true);
        open = true;

    }

    public void Talk()
    {
        Debug.Log(message);
    }

    public void OpenDoor()
    {
        anim.SetBool("canOpen", true);
        anim.SetBool("canClose", false);

    }

    public void OpenDoorC()
    {
        openDoorCollider.enabled = true;
        closeDoorCollider.enabled = false;
    }

    public void CloseDoor()
    {
        
        openDoorCollider.enabled = false;
        closeDoorCollider.enabled = true;
        anim.SetBool("canOpen", false);
        anim.SetBool("canClose", true);
    }

    public void UndoCloseDoor()
    {
        Debug.Log("doorUNDONE????");
        anim.SetBool("canClose", false);
    }

    public void TimeToUnlock()
    {
        ratTextAnim.SetBool("textFade", false);
        gameObject.SetActive(false);
        pi.ratting = false;
        pm.grandLock = false;
        pm.GRANDERLOCK = false;
    }

    public void RatFade()
    {
        pi.ratCount += 1;
        pi.ratText.text = pi.ratCount.ToString() + "/50";
        ratTextAnim.SetBool("textFade", true);
        anim.SetBool("fading", true);
    }
}
