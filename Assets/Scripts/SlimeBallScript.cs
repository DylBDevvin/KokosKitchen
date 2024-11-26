using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBallScript : MonoBehaviour
{

    public Parrier p;
    public PlayerMovement pm;

    public Animator anim;
    public Animator textAnim;
    public Animator glubAnim;

    public Rigidbody2D rb;

    public Text scoreText;
    public Text maxScoreText;

    public Transform netPoint;
    public Transform respawnPoint;
    public Vector3 landingPoint;

    public GameObject landMarker;
    public GameObject explosion;

    public int score;
    public int maxScore;
    public int num;
    public int mcMaxScore;

    public bool canHit;
    public bool onNet;
    public bool netToFloor;
    public bool canIncrease;
    public bool inAir;
    public bool canRandomize;
    public bool hittable;
    public bool canHitPlayer;

    public float defspeed = 5;
    public float speed = 5;
    public float speed2 = 7;
    public float speed3 = 9;
    public float speed4 = 11;
    public float randX;
    public float randY;

    public int lim1;
    public int lim2;
    public int lim3;
    public int lim4;

    public bool s1;
    public bool s2;
    public bool s3;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        p = FindObjectOfType<Parrier>();
        pm = FindObjectOfType<PlayerMovement>();
        score = 0;
        maxScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hittable)
        {
            p.hitBall = false;
        }

        if (canHit)
        {
            if (score >= maxScore)
            {
                maxScore = score;
                maxScoreText.text = " ";
            }

            if(score >= lim1)
            {
                speed = speed2;
            }
            if(score >= lim2)
            {
                speed = speed3;
            }
            if(score >= lim3)
            {
                speed = speed4;
            }
            if(score >= lim4)
            {
                if(num == 1)
                {
                    speed = 5;

                }
                if(num == 2)
                {
                    speed = speed2;
                }
                if(num == 3)
                {
                    speed = speed3;
                }
                if(num == 4)
                {
                    speed = speed4;
                }
            }

            if (s1)
            {


                if (p.hitBall == true)
                {
                    canHitPlayer = false;
                    canRandomize = true;
                    inAir = true;
                    landMarker.SetActive(false);
                    netToFloor = false;
                    anim.SetBool("beingHit", true);
                    textAnim.SetBool("active", true);
                    var step = speed * Time.deltaTime;
                    if (canIncrease)
                    {
                        score++;
                        scoreText.text = "Score: " + score.ToString();
                        canIncrease = false;
                        num = Random.Range(1, 5);
                    }
                    transform.position = Vector3.MoveTowards(transform.position, netPoint.position, step);

                }
            }

            if (s2)
            {
                if (p.hitBall2 == true)
                {
                    canHitPlayer = false;
                    canRandomize = true;
                    inAir = true;
                    landMarker.SetActive(false);
                    netToFloor = false;
                    anim.SetBool("beingHit", true);
                    textAnim.SetBool("active", true);
                    var step = speed * Time.deltaTime;
                    if (canIncrease)
                    {
                        score++;
                        scoreText.text = "Score: " + score.ToString();
                        canIncrease = false;
                        num = Random.Range(1, 5);
                    }
                    if (score >= maxScore)
                    {
                        maxScore = score;
                        maxScoreText.text = "Max Score: " + maxScore.ToString();
                    }
                    transform.position = Vector3.MoveTowards(transform.position, netPoint.position, step);

                }
            }

            if (s1)
            {
                if (transform.position == netPoint.position)
                {
                    canHitPlayer = true;
                    p.hitBall = false;
                    canIncrease = true;
                    onNet = true;
                    if (s1) //Slimeball one landing coords
                    {
                        randX = Random.Range(441, 447); //LANDING COORDS
                        randY = Random.Range(-428, -431);
                    }

                    landingPoint = new Vector3(randX, randY, 0);
                    landMarker.transform.position = landingPoint;
                    netToFloor = true;
                }
            }

            if (s2)
            {
                if (transform.position == netPoint.position)
                {
                    if (score >= maxScore)
                    {
                        maxScore = score;
                        maxScoreText.text = "Max Score: " + maxScore.ToString();
                    }
                    canHitPlayer = true;
                    p.hitBall2 = false;
                    canIncrease = true;
                    onNet = true;
                    if (s2) //Slimeball 2 landing coords
                    {
                        randX = Random.Range(1129, 1136); //LANDING COORDS
                        randY = Random.Range(420, 424);
                    }

                    landingPoint = new Vector3(randX, randY, 0);
                    landMarker.transform.position = landingPoint;
                    netToFloor = true;
                }
            }


            if (s1)
            {


                if (netToFloor == true)
                {
                    var step = speed * Time.deltaTime;
                    landMarker.transform.position = landingPoint;
                    landMarker.SetActive(true);
                    transform.position = Vector3.MoveTowards(transform.position, landingPoint, step);
                    onNet = false;

                }
            }

            if (s2)
            {


                if (netToFloor == true)
                {
                    var step = speed * Time.deltaTime;
                    landMarker.transform.position = landingPoint;
                    landMarker.SetActive(true);
                    transform.position = Vector3.MoveTowards(transform.position, landingPoint, step);
                    onNet = false;
                    if (score >= maxScore)
                    {
                        maxScore = score;
                        maxScoreText.text = "Max Score: " + maxScore.ToString();
                    }

                }
            }

            if (s1)
            {
                if (transform.position == landingPoint)
                {
                    hittable = false;
                    inAir = false;
                    anim.SetBool("beingHit", false);
                    textAnim.SetBool("active", false);
                    textAnim.SetBool("inactive", true);
                    netToFloor = false;
                    landMarker.SetActive(false);
                    canHit = false;
                    score = 0;
                    scoreText.text = "Score: " + score.ToString();
                    StartCoroutine(ExplodeAndRespawn());
                    //Let it explode???
                }
            }

            if (s2)
            {
                if (transform.position == landingPoint)
                {
                    hittable = false;
                    inAir = false;
                    anim.SetBool("beingHit", false);
                    textAnim.SetBool("active", false);
                    textAnim.SetBool("inactive", true);
                    netToFloor = false;
                    landMarker.SetActive(false);
                    canHit = false;
                    if (score >= maxScore)
                    {
                        maxScore = score;
                        maxScoreText.text = "Max Score: " + maxScore.ToString();
                    }
                    score = 0;
                    scoreText.text = "Score: " + score.ToString();
                    StartCoroutine(ExplodeAndRespawn());
                    //Let it explode???
                }
            }


        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && inAir == true && canHitPlayer)
        {

            hittable = false;
            anim.SetBool("beingHit", false);
            textAnim.SetBool("active", false);
            textAnim.SetBool("inactive", true);
            netToFloor = false;
            landMarker.SetActive(false);
            canHit = false;
            pm.TakeDamage(0);
            score = 0;
            scoreText.text = "Score: " + score.ToString();
            StartCoroutine(ExplodeAndRespawn());
            inAir = false;
        }
    }
    public IEnumerator ExplodeAndRespawn()
    {
        yield return new WaitForSeconds(1.2f);
        glubAnim.SetBool("shook", true);
        transform.localScale = new Vector3(0.6f, 0.6f, 1);
        speed = defspeed;
        CameraShake.Instance.ShakeCamera(5f, .1f);
        SoundManagerScript.PlaySound("boom");
        anim.SetBool("setToInvis", true);
        yield return new WaitForSeconds(1f);
        SoundManagerScript.PlaySound("revive");
        transform.position = respawnPoint.position;
        transform.localScale = new Vector3(1.67f, 1.67f, 1);
        anim.SetBool("setToInvis", false);
        anim.SetBool("fading", true);
        textAnim.SetBool("inactive", false);
        rb.velocity = Vector2.zero;
    }

    public void FadeReset()
    {
        glubAnim.SetBool("shook", false);
        canHit = true;
        anim.SetBool("fading", false);
        hittable = true;
    }
}
