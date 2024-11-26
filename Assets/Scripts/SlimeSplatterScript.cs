using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSplatterScript : MonoBehaviour
{

    public GameObject slimeGoopTrap;
    public GameObject player;
    public bool playerTrapped;
    public bool canTrap;
    public int inputCount;
    public int inputLimit;

    public Rigidbody2D rb;

    public GameObject goopLocation;
    public GameObject leftJigglePosition;
    public GameObject rightJigglePosition;
    public GameObject mashPrompt;
    public float jiggleTime;
    public Vector3 change;
    public GameObject goopSplatLeft;
    public GameObject goopSplatRight;

    public float meleeSlowedSpeed;

    public GameObject kokoFace;
    public GameObject slimeKokoFace;

    // Start is called before the first frame update
    void Start()
    {
        canTrap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrapped)
        {
            rb.isKinematic = true;
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            kokoFace.SetActive(false);
            slimeKokoFace.SetActive(true);
           

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {
                Debug.Log("trapped and making inputs");
                inputCount += 1;
                SoundManagerScript.PlaySound("splat");
            }

            if (change.x < .01 || change.y < .01)
            {
                //Left
                player.transform.position = leftJigglePosition.transform.position;   
                goopSplatLeft.SetActive(true);
                Debug.Log("LEFT INPUT");
                StartCoroutine(PlayerJiggleReset());
            }

            if (change.x >= .01 || change.y >= .01)
            {
                //Right
                player.transform.position = rightJigglePosition.transform.position;      
                goopSplatRight.SetActive(true);
                Debug.Log("RIGHT INPUT");
                StartCoroutine(PlayerJiggleReset());
            }

            if (change == Vector3.zero)
            {
                player.transform.position = goopLocation.transform.position;
                goopSplatLeft.SetActive(true);
                goopSplatRight.SetActive(true);
            }
        }

        if(playerTrapped && inputCount >= inputLimit)
        {
            playerTrapped = false;
            rb.isKinematic = false;
            kokoFace.SetActive(true);
            slimeKokoFace.SetActive(false);
            canTrap = false;
            slimeGoopTrap.SetActive(false);
            inputCount = 0;
            player.GetComponent<PlayerMovement>().GRANDERLOCK = false;
            mashPrompt.SetActive(false);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator") && canTrap)
        {
            Debug.Log("trapping?");
            slimeGoopTrap.SetActive(true);
            mashPrompt.SetActive(true);
            player.transform.position = goopLocation.transform.position;
            player.GetComponent<PlayerMovement>().GRANDERLOCK = true;
            player.GetComponent<PlayerMovement>().animator.SetBool("moving", false);
            player.GetComponent<PlayerMovement>().animator.SetBool("running", false);
            playerTrapped = true;
        }

        if (other.CompareTag("Enemy"))
        {
            if(other.GetComponent<MeleeEnemy1>() != null)
            {
                if(other.GetComponent<MeleeEnemy1>().speed != 0)
                {
                    meleeSlowedSpeed = other.GetComponent<MeleeEnemy1>().speed / 3;
                    other.GetComponent<MeleeEnemy1>().speed = meleeSlowedSpeed;
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            canTrap = true;
            playerTrapped = false;
            player.GetComponent<PlayerMovement>().GRANDERLOCK = false;
            kokoFace.SetActive(true);
            slimeKokoFace.SetActive(false);
            mashPrompt.SetActive(false);
            inputCount = 0;
        }

        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<MeleeEnemy1>() != null)
            {
                if (other.GetComponent<MeleeEnemy1>().speed != 0)
                {
                    other.GetComponent<MeleeEnemy1>().speed = other.GetComponent<MeleeEnemy1>().tempSpeed;
                    meleeSlowedSpeed = 0;
                }
            }
        }
    }

    public IEnumerator PlayerJiggleReset()
    {
        yield return new WaitForSeconds(jiggleTime);
        change = Vector3.zero;
    }

   

}
