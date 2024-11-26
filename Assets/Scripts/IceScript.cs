using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    public bool canMelt;
    public bool melting;
    public bool playerInRange;
    public GameObject player;
    public bool canPlaySE;

    public int SEdistanceCanPlay;
    public int SEdistanceCantPlay; //SE DISTANCE CAN PLAY + 1;
    public float playerDistance;
    public Vector3 scaleChange = new Vector3(-0.01f, 0.01f, 0f);
    public Vector3 scaleZero = new Vector3(0f, 0f, 0f);
    public Vector3 startingScale;
    public Vector3 startingPosition;

    public float respawnWaitTime = 1f;

    public Rigidbody2D rb;
    public Animator anim;
    public bool canPlaySE2 = true;
    public bool canReset = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = gameObject.transform.localPosition;
        startingScale = gameObject.transform.localScale;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().dead)
        {
            gameObject.transform.localScale = startingScale;
            gameObject.transform.localPosition = startingPosition;
        }

        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if(playerDistance <= SEdistanceCanPlay)
        {
            canPlaySE = true;
        }
        if(playerDistance >= SEdistanceCantPlay)
        {
            canPlaySE = false;
        }

        if (canMelt)
        {
            if (melting)
            {
                transform.localScale += scaleChange;
            }

            if (transform.localScale.x <= 0.11 || transform.localScale.y <= 0.11)
            {
                melting = false;
                Debug.Log("FINISHED MELTING. ICE BLOCK IS QUITE DEAD :(");
                //Respawn
                gameObject.transform.localScale = startingScale;
                gameObject.transform.localPosition = startingPosition;
                anim.SetBool("respawn", true);
                if (canPlaySE)
                {
                    SoundManagerScript.PlaySound("iceRespawn");
                }

                StartCoroutine(IceIdle());
            }
        }

        if (!playerInRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("TorchLight"))
        {
            if (canMelt)
            {
                melting = true;
            }
        }
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KokoBullet"))
        {
            if (canReset)
            {


                melting = false;
                Debug.Log("FINISHED MELTING. ICE BLOCK IS QUITE DEAD :(");
                //Respawn
                gameObject.transform.localScale = startingScale;
                gameObject.transform.localPosition = startingPosition;
                anim.SetBool("respawn", true);
                if (canPlaySE2)
                {


                    SoundManagerScript.PlaySound("iceRespawn");
                    StartCoroutine(SE());
                    canPlaySE2 = false;
                }
                canReset = false;
                rb.bodyType = RigidbodyType2D.Static;
                StartCoroutine(IceIdle());
                StartCoroutine(Resettable());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TorchLight"))
        {
            if (canMelt)
            {
                melting = false;
            }
        }
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public IEnumerator IceIdle()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("respawn", false);
    }

    public IEnumerator Resettable()
    {
        yield return new WaitForSeconds(2f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        canReset = true;
    }

    public IEnumerator IceWaitRespawn()
    {
        yield return new WaitForSeconds(respawnWaitTime);
        //Respawn
        gameObject.transform.localScale = startingScale;
        gameObject.transform.localPosition = startingPosition;
        anim.SetBool("respawn", true);
        if (canPlaySE)
        {
            SoundManagerScript.PlaySound("iceRespawn");
        }

        StartCoroutine(IceIdle());
    }

    public IEnumerator SE()
    {
        yield return new WaitForSeconds(4f);
        canPlaySE2 = true;
    }
}
