using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHolderScript : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    public GameObject button3;

    public GameObject door;
    public GameObject door2;

    public bool staysLit;
    public bool solved;
    public bool singleButton;

    public bool canPlaySound;

    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>(); //May need to do on Awake or enable or smt
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.dead)
        {
            ResetPuzzle();
        }

        if (!pm.dead)
        {


            if (!singleButton)
            {
                if (button.GetComponent<ButtonScript>().on && button2.GetComponent<ButtonScript>().on && button3.GetComponent<ButtonScript>().on)
                {
                    if (!canPlaySound)
                    {
                        SoundManagerScript.PlaySound("puzzClear");
                        canPlaySound = true;
                    }

                    solved = true;
                    door.GetComponent<InteractionObject>().OpenDoor();
                    if (door2 != null)
                    {
                        door2.GetComponent<InteractionObject>().OpenDoor();
                    }


                    if (staysLit)
                    {
                        solved = true;
                        button.GetComponent<ButtonScript>().solver = true;
                        button2.GetComponent<ButtonScript>().solver = true;
                        button3.GetComponent<ButtonScript>().solver = true;
                        door.GetComponent<InteractionObject>().OpenDoor();
                        if (door2 != null)
                        {
                            door2.GetComponent<InteractionObject>().OpenDoor();
                        }
                    }

                }
                else
                {
                    solved = false;
                    door.GetComponent<InteractionObject>().CloseDoor();
                    if (door2 != null)
                    {
                        door2.GetComponent<InteractionObject>().CloseDoor();
                    }

                }
            }

            if (singleButton)
            {
                if (button.GetComponent<ButtonScript>().on)
                {
                    solved = true;
                    door.GetComponent<InteractionObject>().OpenDoor();
                    if (door2 != null)
                    {
                        door2.GetComponent<InteractionObject>().OpenDoor();
                    }
                }
            }
        }
    }

    public void ResetPuzzle()
    {
        door.GetComponent<InteractionObject>().CloseDoor();
        if (door2 != null)
        {
            door2.GetComponent<InteractionObject>().CloseDoor();
        }
        solved = false;
        button.GetComponent<ButtonScript>().solver = false;
        if (!singleButton)
        {


            button2.GetComponent<ButtonScript>().solver = false;
            button3.GetComponent<ButtonScript>().solver = false;
        }

        if (!singleButton)
        {


            button.GetComponent<ButtonScript>().hit = false;
            button2.GetComponent<ButtonScript>().hit = false;
            button3.GetComponent<ButtonScript>().hit = false;
        }

        if (!singleButton)
        {


            button.GetComponent<ButtonScript>().off = true;
            button2.GetComponent<ButtonScript>().off = true;
            button3.GetComponent<ButtonScript>().off = true;
        }
    }
    
}
