using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatButtonScript : MonoBehaviour
{

    public Sprite OffSprite;
    public Sprite ActiveSprite;
    public Sprite OnSprite;

    public Text countdownText;
    public Animator cdAnim;

    public SpriteRenderer sr;
    public bool hit;
    public bool cantHit;
    public float countdown;
    public float timeLimit;

    public int points;
    public int pointsNeeded;
    public float time = 60f;
    public float timer;
    
    public GameObject mE1;
    public GameObject mE2;
    public GameObject mE3;
    public GameObject mE4;
    public GameObject mE5;
    public GameObject mE6;
    public GameObject mE7;
    public GameObject mE8;
    public GameObject mE9;

    public GameObject sE1;
    public GameObject sE2;
    public GameObject sE3;
    public GameObject sE4;
    public GameObject sE5;
    public GameObject sE6;
    public GameObject sE7;
    public GameObject sE8;
    public GameObject sE9;

    public GameObject door;
    public GameObject door2;

    public bool won;

    public bool cantIncrease;
    public bool cantIncrease2;
    public bool cantIncrease3;
    public bool cantIncrease4;
    public bool cantIncrease5;
    public bool cantIncrease6;
    public bool cantIncrease7;
    public bool cantIncrease8;
    public bool cantIncrease9;
    public bool cantIncrease10;
    public bool cantIncrease11;
    public bool cantIncrease12;
    public bool cantIncrease13;
    public bool cantIncrease14;
    public bool cantIncrease15;
    public bool cantIncrease16;
    public bool cantIncrease17;
    public bool cantIncrease18;

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

        if(hit && pm.dead)
        {
            cdAnim.SetBool("canFadeOut", true);
            cdAnim.SetBool("canFade", false);
            StartCoroutine(Switcheroo());
            door.GetComponent<InteractionObject>().OpenDoor();
            hit = false;
            countdown = 0;
            sr.sprite = OffSprite;
            points = 0;
            if (mE1 != null)
            {
                mE1.GetComponent<MeleeEnemy1>().dead = false;
                mE1.GetComponent<MeleeEnemy1>().ResetStats();
                mE1.SetActive(false);
            }
            if (mE2 != null)
            {
                mE2.GetComponent<MeleeEnemy1>().dead = false;
                mE2.GetComponent<MeleeEnemy1>().ResetStats();
                mE2.SetActive(false);
            }
            if (mE3 != null)
            {
                mE3.GetComponent<MeleeEnemy1>().dead = false;
                mE3.GetComponent<MeleeEnemy1>().ResetStats();
                mE3.SetActive(false);
            }
            if (mE4 != null)
            {
                mE4.GetComponent<MeleeEnemy1>().dead = false;
                mE4.GetComponent<MeleeEnemy1>().ResetStats();
                mE4.SetActive(false);
            }
            if (mE5 != null)
            {
                mE5.GetComponent<MeleeEnemy1>().dead = false;

                mE5.GetComponent<MeleeEnemy1>().ResetStats();
                mE5.SetActive(false);
            }
            if (mE6 != null)
            {
                mE6.GetComponent<MeleeEnemy1>().dead = false;
                mE6.GetComponent<MeleeEnemy1>().ResetStats();

                mE6.SetActive(false);
            }
            if (mE7 != null)
            {
                mE7.GetComponent<MeleeEnemy1>().dead = false;
                mE7.GetComponent<MeleeEnemy1>().ResetStats();
                mE7.SetActive(false);
            }
            if (mE8 != null)
            {
                mE8.GetComponent<MeleeEnemy1>().dead = false;
                mE8.GetComponent<MeleeEnemy1>().ResetStats();
                mE8.SetActive(false);
            }
            if (mE9 != null)
            {
                mE9.GetComponent<MeleeEnemy1>().dead = false;
                mE9.GetComponent<MeleeEnemy1>().ResetStats();
                mE9.SetActive(false);
            }
            if (sE1 != null)
            {
                sE1.GetComponentInChildren<PatrollingAI>().dead = false;
                sE1.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE1.SetActive(false);
            }
            if (sE2 != null)
            {
                sE2.GetComponentInChildren<PatrollingAI>().dead = false;
                sE2.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE2.SetActive(false);
            }
            if (sE3 != null)
            {
                sE3.GetComponentInChildren<PatrollingAI>().dead = false;
                sE3.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE3.SetActive(false);
            }
            if (sE4 != null)
            {
                sE4.GetComponentInChildren<PatrollingAI>().dead = false;
                sE4.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE4.SetActive(false);
            }
            if (sE5 != null)
            {
                sE5.GetComponentInChildren<PatrollingAI>().dead = false;
                sE5.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE5.SetActive(false);
            }
            if (sE6 != null)
            {
                sE6.GetComponentInChildren<PatrollingAI>().dead = false;
                sE6.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE6.SetActive(false);
            }
            if (sE7 != null)
            {
                sE7.GetComponentInChildren<PatrollingAI>().dead = false;
                sE7.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE7.SetActive(false);
            }
            if (sE8 != null)
            {
                sE8.GetComponentInChildren<PatrollingAI>().dead = false;
                sE8.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE8.SetActive(false);
            }
            if (sE9 != null)
            {
                sE9.GetComponentInChildren<PatrollingAI>().dead = false;
                sE9.GetComponentInChildren<PatrollingAI>().ResetStats();
                sE9.SetActive(false);
            }
            cantIncrease = false;
            cantIncrease2 = false;
            cantIncrease3 = false;
            cantIncrease4 = false;
            cantIncrease5 = false;
            cantIncrease6 = false;
            cantIncrease7 = false;
            cantIncrease8 = false;
            cantIncrease9 = false;
            cantIncrease10 = false;
            cantIncrease11 = false;
            cantIncrease12 = false;
            cantIncrease13 = false;
            cantIncrease14 = false;
            cantIncrease15 = false;
            cantIncrease16 = false;
            cantIncrease17 = false;
            cantIncrease18 = false;
        }

        if (hit && !won)
        {
            // ITS ACTIVE, GO TIME
            cdAnim.SetBool("canFade", true);
            sr.sprite = ActiveSprite;
            door.GetComponent<InteractionObject>().CloseDoor();
            countdown += Time.deltaTime;

            //ALL OF THIS JAZZ ENSURES HEALTHY COUNTDOWN
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                timer = 0;
                time -= 1;
                if (time <= 0)
                {
                    time = 0;
                }
                countdownText.text = time.ToString() + " s";

            }
            //
            if (mE1 != null)
            {
                if (!mE1.GetComponent<MeleeEnemy1>().dead)
                {
                    mE1.SetActive(true);
                }
            }
            if (mE2 != null)
            {
                if (!mE2.GetComponent<MeleeEnemy1>().dead)
                {
                    mE2.SetActive(true);
                }
            }
            if (mE3 != null)
            {
                if (!mE3.GetComponent<MeleeEnemy1>().dead)
                {
                    mE3.SetActive(true);
                }
            }
            if (mE4 != null)
            {
                if (!mE4.GetComponent<MeleeEnemy1>().dead)
                {
                    mE4.SetActive(true);
                }
            }
            if (mE5 != null)
            {
                if (!mE5.GetComponent<MeleeEnemy1>().dead)
                {
                    mE5.SetActive(true);
                }
            }
            if (mE6 != null)
            {
                if (!mE6.GetComponent<MeleeEnemy1>().dead)
                {
                    mE6.SetActive(true);
                }
            }
            if (mE7 != null)
            {
                if (!mE7.GetComponent<MeleeEnemy1>().dead)
                {
                    mE7.SetActive(true);
                }
            }
            if (mE8 != null)
            {
                if (!mE8.GetComponent<MeleeEnemy1>().dead)
                {
                    mE8.SetActive(true);
                }
            }
            if (mE9 != null)
            {
                if (!mE9.GetComponent<MeleeEnemy1>().dead)
                {
                    mE9.SetActive(true);
                }
            }
            if (sE1 != null)
            {
                if (!sE1.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE1.SetActive(true);
                }
            }
            if (sE2 != null)
            {
                if (!sE2.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE2.SetActive(true);
                }
            }
            if (sE3 != null)
            {
                if (!sE3.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE3.SetActive(true);
                }
            }
            if (sE4 != null)
            {
                if (!sE4.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE4.SetActive(true);
                }
            }
            if (sE5 != null)
            {
                if (!sE5.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE5.SetActive(true);
                }
            }
            if (sE6 != null)
            {
                if (!sE6.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE6.SetActive(true);
                }
            }
            if (sE7 != null)
            {
                if (!sE7.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE7.SetActive(true);
                }
            }
            if (sE8 != null)
            {
                if (!sE8.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE8.SetActive(true);
                }
            }
            if (sE9 != null)
            {
                if (!sE9.GetComponentInChildren<PatrollingAI>().dead)
                {
                    sE9.SetActive(true);
                }
            }



            if (countdown >= timeLimit && !won) //Took too long to kill all enemies
            {
                cdAnim.SetBool("canFadeOut", true);
                cdAnim.SetBool("canFade", false);
                StartCoroutine(Switcheroo());
                door.GetComponent<InteractionObject>().OpenDoor();
                hit = false;
                countdown = 0;
                sr.sprite = OffSprite;
                points = 0;
                if (mE1 != null)
                {
                    mE1.GetComponent<MeleeEnemy1>().dead = false;
                    mE1.GetComponent<MeleeEnemy1>().ResetStats();
                    mE1.SetActive(false);
                }
                if (mE2 != null)
                {
                    mE2.GetComponent<MeleeEnemy1>().dead = false;
                    mE2.GetComponent<MeleeEnemy1>().ResetStats();
                    mE2.SetActive(false);
                }
                if (mE3 != null)
                {
                    mE3.GetComponent<MeleeEnemy1>().dead = false;
                    mE3.GetComponent<MeleeEnemy1>().ResetStats();
                    mE3.SetActive(false);
                }
                if (mE4 != null)
                {
                    mE4.GetComponent<MeleeEnemy1>().dead = false;
                    mE4.GetComponent<MeleeEnemy1>().ResetStats();
                    mE4.SetActive(false);
                }
                if (mE5 != null)
                {
                    mE5.GetComponent<MeleeEnemy1>().dead = false;
                    
                    mE5.GetComponent<MeleeEnemy1>().ResetStats();
                    mE5.SetActive(false);
                }
                if (mE6 != null)
                {
                    mE6.GetComponent<MeleeEnemy1>().dead = false;
                    mE6.GetComponent<MeleeEnemy1>().ResetStats();
                    
                    mE6.SetActive(false);
                }
                if (mE7 != null)
                {
                    mE7.GetComponent<MeleeEnemy1>().dead = false;
                    mE7.GetComponent<MeleeEnemy1>().ResetStats();
                    mE7.SetActive(false);
                }
                if (mE8 != null)
                {
                    mE8.GetComponent<MeleeEnemy1>().dead = false;
                    mE8.GetComponent<MeleeEnemy1>().ResetStats();
                    mE8.SetActive(false);
                }
                if (mE9 != null)
                {
                    mE9.GetComponent<MeleeEnemy1>().dead = false;
                    mE9.GetComponent<MeleeEnemy1>().ResetStats();
                    mE9.SetActive(false);
                }
                if (sE1 != null)
                {
                    sE1.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE1.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE1.SetActive(false);
                }
                if (sE2 != null)
                {
                    sE2.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE2.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE2.SetActive(false);
                }
                if (sE3 != null)
                {
                    sE3.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE3.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE3.SetActive(false);
                }
                if (sE4 != null)
                {
                    sE4.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE4.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE4.SetActive(false);
                }
                if (sE5 != null)
                {
                    sE5.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE5.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE5.SetActive(false);
                }
                if (sE6 != null)
                {
                    sE6.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE6.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE6.SetActive(false);
                }
                if (sE7 != null)
                {
                    sE7.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE7.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE7.SetActive(false);
                }
                if (sE8 != null)
                {
                    sE8.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE8.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE8.SetActive(false);
                }
                if (sE9 != null)
                {
                    sE9.GetComponentInChildren<PatrollingAI>().dead = false;
                    sE9.GetComponentInChildren<PatrollingAI>().ResetStats();
                    sE9.SetActive(false);
                }

                cantIncrease = false;
                cantIncrease2 = false;
                cantIncrease3 = false;
                cantIncrease4 = false;
                cantIncrease5 = false;
                cantIncrease6 = false;
                cantIncrease7 = false;
                cantIncrease8 = false;
                cantIncrease9 = false;
                cantIncrease10 = false;
                cantIncrease11 = false;
                cantIncrease12 = false;
                cantIncrease13 = false;
                cantIncrease14 = false;
                cantIncrease15 = false;
                cantIncrease16 = false;
                cantIncrease17 = false;
                cantIncrease18 = false;
            }

            if (mE1 != null)
            {
                if (mE1.GetComponent<MeleeEnemy1>().dead && !cantIncrease)
                {
                    points += 1;
                    cantIncrease = true;
                }
            }

            if (mE2 != null)
            {
                if (mE2.GetComponent<MeleeEnemy1>().dead && !cantIncrease2)
                {
                    points += 1;
                    cantIncrease2 = true;
                }
            }

            if (mE3 != null)
            {
                if (mE3.GetComponent<MeleeEnemy1>().dead && !cantIncrease3)
                {
                    points += 1;
                    cantIncrease3 = true;
                }
            }

            if (mE4 != null)
            {
                if (mE4.GetComponent<MeleeEnemy1>().dead && !cantIncrease4)
                {
                    points += 1;
                    cantIncrease4 = true;
                }
            }

            if (mE5 != null)
            {
                if (mE5.GetComponent<MeleeEnemy1>().dead && !cantIncrease5)
                {
                    points += 1;
                    cantIncrease5 = true;
                }
            }


            if (mE6 != null)
            {
                if (mE6.GetComponent<MeleeEnemy1>().dead && !cantIncrease6)
                {
                    points += 1;
                    cantIncrease6 = true;
                }
            }

            if (mE7 != null)
            {
                if (mE7.GetComponent<MeleeEnemy1>().dead && !cantIncrease7)
                {
                    points += 1;
                    cantIncrease7 = true;
                }
            }

            if (mE8 != null)
            {
                if (mE8.GetComponent<MeleeEnemy1>().dead && !cantIncrease9)
                {
                    points += 1;
                    cantIncrease8 = true;
                }
            }

            if (mE9 != null)
            {
                if (mE9.GetComponent<MeleeEnemy1>().dead && !cantIncrease9)
                {
                    points += 1;
                    cantIncrease9 = true;
                }
            }

            if (sE1 != null)
            {


                if (sE1.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease10)
                {
                    points += 1;
                    cantIncrease10 = true;
                }
            }
            if (sE2 != null)
            {
                if (sE2.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease11)
                {
                    points += 1;
                    cantIncrease11 = true;
                }
            }

            if (sE3 != null)
            {
                if (sE3.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease12)
                {
                    points += 1;
                    cantIncrease12 = true;
                }
            }

            if (sE4 != null)
            {
                if (sE4.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease13)
                {
                    points += 1;
                    cantIncrease13 = true;
                }
            }

            if (sE5 != null)
            {
                if (sE5.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease14)
                {
                    points += 1;
                    cantIncrease14 = true;
                }
            }

            if (sE6 != null)
            {
                if (sE6.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease15)
                {
                    points += 1;
                    cantIncrease15 = true;
                }
            }

            if (sE7 != null)
            {
                if (sE7.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease16)
                {
                    points += 1;
                    cantIncrease16 = true;
                }
            }

            if (sE8 != null)
            {
                if (sE8.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease17)
                {
                    points += 1;
                    cantIncrease17 = true;
                }
            }

            if (sE9 != null)
            {
                if (sE9.GetComponentInChildren<PatrollingAI>().dead && !cantIncrease18)
                {
                    points += 1;
                    cantIncrease18 = true;
                }
            }

            if (points == pointsNeeded && countdown < timeLimit) //WON!!!!! :)
            {
                //open door
                won = true;
                cdAnim.SetBool("canFadeOut", true);
                cdAnim.SetBool("canFade", false);
                sr.sprite = OnSprite;
                door.GetComponent<InteractionObject>().OpenDoor();
                door2.GetComponent<InteractionObject>().OpenDoor();
                StartCoroutine(Switcheroo());
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KokoBullet"))
        {
            if (!cantHit)
            {
                hit = true;
            }
            
        }
    }

    public IEnumerator Switcheroo()
    {
        cantHit = true;
        yield return new WaitForSeconds(0.48f);
        cantHit = false;
        cdAnim.SetBool("canFadeOut", false);
        timer = 0;
        time = 60;
        countdownText.text = time.ToString() + " s";
    }



}
