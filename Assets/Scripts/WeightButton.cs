using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{

    public bool pressed;
    public bool blockPressed;
    public bool solved;

    public SpriteRenderer sr;
    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    public GameObject door;
    public GameObject door2;

    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    public bool threeBlocks;
    public bool twoBlocks;
    public bool fourBlocks;
    public bool fiveBlocks;
    public bool oneBlock;

    public float playerDistance;
    public float SEdistanceCanPlay = 10f;
    public float SEdistanceCantPlay = 11f;
    public GameObject player;
    public bool canPress;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().dead)
        {
            solved = false;
            sr.sprite = unpressedSprite;
            door.GetComponent<InteractionObject>().CloseDoor();
            if (door2 != null)
            {
                door2.GetComponent<InteractionObject>().CloseDoor();
            }
            blockPressed = false;
            pressed = false;
            
        }

        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (playerDistance <= SEdistanceCanPlay)
        {
            canPress = true;
        }
        if (playerDistance >= SEdistanceCantPlay)
        {
            canPress = false;
        }

        if (pressed == true || blockPressed == true && !solved)
        {
            sr.sprite = pressedSprite;
        }
        if(pressed == false && blockPressed == false && !solved)
        {
            sr.sprite = unpressedSprite;
        }

        if (solved)
        {
            sr.sprite = pressedSprite;
        }

        if (fiveBlocks)
        {
            if (button5 != null && button4 != null && button3 != null && button2 != null) //Uses 5 buttons
            {
                if (button5.GetComponent<WeightButton>().pressed == true || button5.GetComponent<WeightButton>().blockPressed == true)
                    if (button4.GetComponent<WeightButton>().pressed == true || button4.GetComponent<WeightButton>().blockPressed == true)
                        if (button3.GetComponent<WeightButton>().pressed == true || button3.GetComponent<WeightButton>().blockPressed == true)
                            if (GetComponent<WeightButton>().pressed == true || button2.GetComponent<WeightButton>().blockPressed == true)
                                if (pressed == true || blockPressed == true)
                                {
                                    solved = true; //Solve puzzle
                                    door.GetComponent<InteractionObject>().OpenDoor();
                                    if (door2 != null)
                                    {
                                        door2.GetComponent<InteractionObject>().OpenDoor();
                                    }
                                }
            }
        }

        if (fourBlocks) {
            if (button4 != null && button3 != null && button2 != null && button5 == null) //Uses 4 buttons
            {
                if (button4.GetComponent<WeightButton>().pressed == true || button4.GetComponent<WeightButton>().blockPressed == true)
                    if (button3.GetComponent<WeightButton>().pressed == true || button3.GetComponent<WeightButton>().blockPressed == true)
                        if (button2.GetComponent<WeightButton>().pressed == true || button2.GetComponent<WeightButton>().blockPressed == true)
                            if (pressed == true || blockPressed == true)
                            {
                                solved = true; //Solve puzzle
                                door.GetComponent<InteractionObject>().OpenDoor();
                                if (door2 != null)
                                {
                                    door2.GetComponent<InteractionObject>().OpenDoor();
                                }
                            }
            }
        }

        if (threeBlocks) {
            if (button3 != null && button2 != null && button4 == null && button5 == null) //Uses 3 buttons
            {
                if (button3.GetComponent<WeightButton>().pressed == true || button3.GetComponent<WeightButton>().blockPressed == true)
                {
                    if (button2.GetComponent<WeightButton>().pressed == true || button2.GetComponent<WeightButton>().blockPressed == true)
                    {
                        if (pressed == true || blockPressed == true)
                            if (button2.GetComponent<WeightButton>().pressed == true || button2.GetComponent<WeightButton>().blockPressed == true)
                                if (button3.GetComponent<WeightButton>().pressed == true || button3.GetComponent<WeightButton>().blockPressed == true)
                                {
                                    solved = true; //Solve puzzle
                                    Debug.Log("THREE BLOCK PUZZLE SOLVED!!");
                                    door.GetComponent<InteractionObject>().OpenDoor();
                                    if (door2 != null)
                                    {
                                        door2.GetComponent<InteractionObject>().OpenDoor();
                                    }
                                 }
                    }
                }
            }
        }

        if (twoBlocks) 
        {
            if (button2 != null && button3 == null && button4 == null && button5 == null) //Uses 2 buttons
            {
                if (button2.GetComponent<WeightButton>().pressed == true || button2.GetComponent<WeightButton>().blockPressed == true)
                {


                    if (pressed == true || blockPressed == true)
                    {
                        solved = true; //Solve puzzle
                        door.GetComponent<InteractionObject>().OpenDoor();
                        Debug.Log("DOUBLE BLOC PUZZLE SOLVED!!");
                        if (door2 != null)
                        {
                            door2.GetComponent<InteractionObject>().OpenDoor();
                        }
                    }
                }
            }
        }

        if (oneBlock) {
            if (button5 == null && button4 == null && button3 == null && button2 == null) //Uses 1 button
            {
                if (pressed == true || blockPressed == true)
                {
                    solved = true; //Solve puzzle
                    door.GetComponent<InteractionObject>().OpenDoor();
                    if (door2 != null)
                    {
                        door2.GetComponent<InteractionObject>().OpenDoor();
                    }
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!solved)
        {
            if (other.CompareTag("TitleCardActivator"))
            {
                pressed = true;
                if (!blockPressed)
                {     
                    SoundManagerScript.PlaySound("press");                  
                }
            }
            if (other.CompareTag("Block"))
            {              
                blockPressed = true;               
                if (!pressed)
                {                 
                        SoundManagerScript.PlaySound("press");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!solved)
        {
            if (other.CompareTag("TitleCardActivator"))
            {
                pressed = false;
                if (!blockPressed)
                {
                    SoundManagerScript.PlaySound("unpress");
                }
            }
            if (other.CompareTag("Block"))
            {
                blockPressed = false;
                if (!pressed)
                {
                    SoundManagerScript.PlaySound("unpress");
                }
            }
        }
    }
}
