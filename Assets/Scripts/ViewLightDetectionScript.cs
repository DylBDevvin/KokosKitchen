using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLightDetectionScript : MonoBehaviour
{

    public GameObject playerExclamationMark;
    public Transform teleportReturnLocation;
    public GameObject player;
    public MeleeEnemy1 me1;
    public Animator anim;
    public float skeletonSpeed;

    public float waitTime;
    public Animator fadeAnim;
    public int ranRange;

    // Start is called before the first frame update
    void Start()
    {
        me1 = GetComponentInParent<MeleeEnemy1>();
        skeletonSpeed = me1.speed;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isRunning", true);
        if (player.GetComponent<PlayerMovement>().dead)
        {
            playerExclamationMark.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerMovement>().located)
        {
            ranRange = Random.Range(1, 3);
            if (ranRange == 1)
            {
                SoundManagerScript.PlaySound("detect1");
            }
            else
            {
                SoundManagerScript.PlaySound("detect2");
            }
            playerExclamationMark.SetActive(true);
            other.GetComponent<PlayerMovement>().located = true;
            other.GetComponent<PlayerMovement>().GRANDERLOCK = true;
            other.GetComponent<Animator>().SetBool("running", false);
            other.GetComponent<Animator>().SetBool("moving", false);
            other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody2D>().angularVelocity = 0;
            other.GetComponent<PlayerMovement>().grandLock = true;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<PlayerMovement>().dooring = true;
            me1.speed = 0;
            StartCoroutine(TeleportPlayer());           
        }
    }

    public IEnumerator TeleportPlayer()
    {
        fadeAnim.SetBool("toBlack", true);
        yield return new WaitForSeconds(1.2f);
        player.transform.position = teleportReturnLocation.position;
        StartCoroutine(Wait());  
        yield return new WaitForSeconds(0.01f);   
        me1.speed = skeletonSpeed;


    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        playerExclamationMark.SetActive(false);
        fadeAnim.SetBool("toWhite", true);
        fadeAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1);
        ToIdle();
    }

    public void ToIdle()
    {
        fadeAnim.SetBool("toWhite", false);
        player.GetComponent<PlayerMovement>().located = false;
        player.GetComponent<PlayerMovement>().GRANDERLOCK = false;
        player.GetComponent<PlayerMovement>().grandLock = false;
        player.GetComponent<PlayerMovement>().isLocked = false;
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<PlayerMovement>().dooring = false;
    }
}
