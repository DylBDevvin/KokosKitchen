using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionerScript : MonoBehaviour
{
    public GameObject transitionLocation;
    public GameObject player;
    public Animator anim;

    public SpriteRenderer sr;
    

    public float waitTime;

    public bool door;
    public bool dooring;

    public PlayerMovement pm;

    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dooring)
        {
            pm.GRANDERLOCK = true;
            pm.grandLock = true;
            pm.isLocked = true;
            pm.canMove = false;
            pm.canShoot = false;
            pm.canChargeShot = false;
            pm.movementSpeed = 0f;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            pm.animator.SetBool("moving", false);
            pm.animator.SetBool("running", false);
            
        }
        else
        {
            pm.GRANDERLOCK = false;
            pm.grandLock = false;
            pm.isLocked = false;
            pm.canMove = true;
            pm.canShoot = true;
            pm.canChargeShot = true;
            player.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            anim.SetBool("toBlack", true);
            if (door)
            {
                sr.color = Color.clear;
                dooring = true;
                pm.dooring = true;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                Debug.Log("Transitioning...");
            }
            StartCoroutine(Mover());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            sr.color = Color.white;
            
        }
    }

    public void MovePlayer()
    {
        player.transform.position = transitionLocation.transform.position;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        StartCoroutine(Wait());
        
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("toWhite", true);
        anim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1);
        ToIdle();
    }

    public void ToIdle()
    {
        anim.SetBool("toWhite", false);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        dooring = false;
        pm.dooring = false;
        Debug.Log("to idle");
    }

    public IEnumerator Mover()
    {
        yield return new WaitForSeconds(1.1f);
        MovePlayer();
    }

    

}
