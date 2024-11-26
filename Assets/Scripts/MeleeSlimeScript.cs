using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSlimeScript : MonoBehaviour
{

    public bool playerInRange = true;
    public bool canCount = true;
    public bool canTrack = true;
    public bool preAscending;
    public bool ascending;
    public bool descending;
    public bool landing;
    public bool canShrink = true;
    public bool reset;

    public float countdown;
    public float countdownLimit;
    public float hopSpeed = 30;
    public float hopSpeed2 = 31;
    public float hop;
    public float hop2;
    public float distance;
    public float increaser;

    public MeleeEnemy1 me;
    public Animator anim;
    public Rigidbody2D rb;

    public Transform jumpPoint;
    public Transform player;

    public GameObject impactCircle;
    public GameObject impactCircleFill;
    public Color color1;
    public Color color2;

    public Collider2D impactCollider;

    public PlayerMovement pm;


    //public Transform landingPosition;

    public Vector3 landingPos;

    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;
    public ParticleSystem p5;
    public ParticleSystem p6;
    public ParticleSystem p7;
    public ParticleSystem p8;
    public ParticleSystem p9;
    public ParticleSystem p10;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        me = GetComponent<MeleeEnemy1>();
        impactCircleFill.transform.localScale = new Vector3(0, 0, 0);

        impactCircle.SetActive(false);
        impactCollider.enabled = false;
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.dead)
        {
            preAscending = false;
            landing = false;
            ascending = false;
            descending = false;
            //impactCircleFill.SetActive(false);
            countdown = 0;
            anim.SetBool("idle", true);
        }

        if (reset)
        {
            preAscending = false;
            landing = false;
            ascending = false;
            descending = false;
        }

        if (!me.dead)
        {


            if (canTrack)
            {
                landingPos = player.position;
            }

            if (playerInRange && canCount)
            {
                countdown += Time.deltaTime;
            }

            if (countdown >= countdownLimit)
            {
                anim.SetBool("idle", false);
                countdown = countdownLimit;
                canCount = false;
                anim.SetBool("preAscend", true);
            }

            if (ascending)
            {
                me.canTakeDmg = false;
                hop = hopSpeed * Time.deltaTime;
                me.canTakeDmg = false;
                transform.position = Vector2.MoveTowards(transform.position, jumpPoint.position, hop);
                anim.SetBool("preAscend", false);
                anim.SetBool("ascend", true);
            }

            if (transform.position == jumpPoint.position)
            {
                ascending = false;
                descending = true;
                canTrack = false;
            }

            if (descending)
            {
                distance = Vector2.Distance(transform.position, landingPos);
                if (canShrink)
                {
                    impactCircleFill.transform.localScale += new Vector3(increaser, increaser, increaser); //STARTING POINT, STOP UNDOING HERE!!
                    if (impactCircleFill.transform.localScale.x >= 2)
                    {
                        impactCircleFill.transform.localScale = new Vector3(2, 2, 2);
                    }
                }

                if (distance <= 5)
                {
                    canShrink = false;
                    distance = 5;
                    impactCircleFill.GetComponent<SpriteRenderer>().color = color2;
                }
                impactCircle.SetActive(true);
                impactCircle.transform.position = landingPos;

                hop2 = hopSpeed2 * Time.deltaTime;
                Debug.Log("we made it TOOOOO the jump point!!!!!");
                anim.SetBool("ascend", false);
                anim.SetBool("descend", true);
                transform.position = Vector2.MoveTowards(transform.position, landingPos, hop2);

            }

            if (transform.position == landingPos)
            {
                me.canTakeDmg = true;
                PlayParticles();
                impactCircleFill.GetComponent<SpriteRenderer>().color = color1;
                impactCollider.enabled = true;
                impactCircle.SetActive(false);
                //impactCircleFill.transform.localScale = new Vector3(3.7f, 3.7f, 1);
                impactCircleFill.transform.localScale = new Vector3(0, 0, 0);
                descending = false;
                anim.SetBool("descend", false);
                anim.SetBool("land", true);
                me.canTakeDmg = true;
                canCount = true;
                canTrack = true;
                canShrink = true;
                CameraShake.Instance.ShakeCamera(5f, .1f);
                SoundManagerScript.PlaySound("slimeLand");
                StartCoroutine(Impact());

            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            countdown = 0;
        }
    }

    public void Ascend()
    {
        SoundManagerScript.PlaySound("slimeAscend");
        ascending = true;
    }

    public void Land()
    {
        anim.SetBool("land", false);
    }

    public IEnumerator Impact()
    {
        yield return new WaitForSeconds(0.1f);
        impactCollider.enabled = false;
    }

    public void PlayParticles()
    {
        p1.Play();
        p2.Play();
        p3.Play();
        p4.Play();
        p5.Play();
        p6.Play();
        p7.Play();
        p8.Play();
        p9.Play();
        p10.Play();
           
    }
    
}
