using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parrier : MonoBehaviour
{
    public bool canParry;
    
    public bool parried;
    public bool bulletInRange;
    public bool enemyInRange;
    public bool ballInRange;
    public bool ballInRange2;
    public bool impactRingInRange;
    public bool missed;
    
    public bool instaCharge;

    public PlayerMovement pm;
    public Animator anim;

    public GameObject parryRing;

    public int pCount;
    public int maxPcount = 10;

    public GameObject bullet;
    public MeleeEnemy1 enemScript;
    public GameObject ball;

    public CircleCollider2D parryCollider;

    public SpriteRenderer sr;
    public FlashScript2 fs2;

    public bool hitBall;
    public bool hitBall2;

    public Text pointText;

    public GameObject ppTut;
    public bool parryPointIncreaserUnlocked;
    public bool parryPointOpenable;
    public bool parryPointClosable;

    public GameObject ppTut2;
    public bool parryPointIncreaser2Unlocked;
    public bool parryPoint2Openable;
    public bool parryPoint2Closable;
    public bool parryUnlocked;

    public GameObject parryEnsurer;
    public GameObject parryEnsurer2;
    public GameObject parryEnsurer3;
    public GameObject parryEnsurer4;
    public GameObject parryEnsurer5;

    public bool canDecrease;

    public float ensureTimer;
    public float ensureTimerLim = 3f;


    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        fs2 = GetComponent<FlashScript2>();
        maxPcount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(ensureTimer >= ensureTimerLim)
        {
            StartCoroutine(ParryReset());
        } 
        if(pCount > 0)
        {
            instaCharge = true;
        }
        if(pCount <= 0)
        {
            instaCharge = false;
        }

        if (parryUnlocked)
        {


            pointText.text = pCount.ToString();

            if (bullet == null)
            {
                bulletInRange = false;
            }

            if (canParry)
            {
                if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
                {
                    parryRing.SetActive(true);

                    if (bulletInRange == true)
                    {
                        SoundManagerScript.PlaySound("parryHit");
                        ensureTimer += Time.deltaTime;
                        parryEnsurer.SetActive(true);
                        parryEnsurer2.SetActive(true);
                        parryEnsurer3.SetActive(true);
                        parryEnsurer4.SetActive(true);
                        parryEnsurer5.SetActive(true);
                        anim.SetBool("canZoom", true);
                        Debug.Log("bulllet");

                        //bullet.GetComponent<EnemyBulletScript>().Destroyer();
                        if (bullet != null)
                        {
                            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                            bullet.GetComponent<EnemyBulletScript>().canDamage = false;
                            StartCoroutine(BulletDestroy());
                        }
                        else
                        {
                            bulletInRange = true;
                        }

                        parried = true;
                        if (parryPointIncreaserUnlocked && !parryPointIncreaser2Unlocked)
                        {
                            pCount += 2;
                        }
                        if (parryPointIncreaser2Unlocked)
                        {
                            pCount += 3;
                        }
                        else
                        {
                            pCount++;
                        }
                        instaCharge = true;

                        fs2.Flash();
                        if (pCount > maxPcount)
                        {
                            pCount = maxPcount;
                        }

                    }

                    if (enemyInRange == true)
                    {
                        SoundManagerScript.PlaySound("parryHit");
                        Debug.Log("Enemyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy");
                        anim.SetBool("canZoom", true);
                        ensureTimer += Time.deltaTime;
                        if (enemScript.skeleton)
                        {
                            if (parryPointIncreaserUnlocked && !parryPointIncreaser2Unlocked)
                            {
                                pCount += 2;
                            }
                            if (parryPointIncreaser2Unlocked)
                            {
                                pCount += 3;
                            }
                            else
                            {
                                pCount++;
                            }
                            if (pCount > maxPcount)
                            {
                                pCount = maxPcount;
                            }
                            enemScript.SkellyDeather();
                        }
                        else
                        {
                            enemScript.KnockBackParry();
                            enemScript.Flasher();
                            parried = true;
                            instaCharge = true;
                            fs2.Flash();
                            if (parryPointIncreaserUnlocked && !parryPointIncreaser2Unlocked)
                            {
                                pCount += 2;
                            }
                            if (parryPointIncreaser2Unlocked)
                            {
                                pCount += 3;
                            }
                            else
                            {
                                pCount++;
                            }
                            if (pCount > maxPcount)
                            {
                                pCount = maxPcount;
                            }
                        }

                    }

                    if (ballInRange == true)
                    {
                        ensureTimer += Time.deltaTime;
                        SoundManagerScript.PlaySound("parryHit");
                        anim.SetBool("canZoom", true);
                        Debug.Log("ball");
                        parried = true;
                        fs2.Flash();
                        hitBall = true;

                    }

                    if (ballInRange2 == true)
                    {
                        ensureTimer += Time.deltaTime;
                        SoundManagerScript.PlaySound("parryHit");
                        anim.SetBool("canZoom", true);
                        Debug.Log("ball");
                        parried = true;
                        fs2.Flash();
                        hitBall2 = true;

                    }

                    if (impactRingInRange)
                    {
                        ensureTimer += Time.deltaTime;
                        SoundManagerScript.PlaySound("parryHit");
                        anim.SetBool("canZoom", true);
                        Debug.Log("ball");
                        parried = true;
                        fs2.Flash();
                        if (parryPointIncreaserUnlocked && !parryPointIncreaser2Unlocked)
                        {
                            pCount += 2;
                        }
                        if (parryPointIncreaser2Unlocked)
                        {
                            pCount += 3;
                        }
                        else
                        {
                            pCount++;
                        }
                        if (pCount > maxPcount)
                        {
                            pCount = maxPcount;
                        }
                    }

                    if (bulletInRange == false && enemyInRange == false && ballInRange == false && impactRingInRange == false && ballInRange2 == false)
                    {
                        //MISSED!
                        SoundManagerScript.PlaySound("parry");
                        missed = true;
                        canParry = false;
                        pm.canShoot = false;
                        pm.canChargeShot = false;
                       
                        StartCoroutine(ParryMiss());
                        sr.color = Color.gray;

                    }
                    StartCoroutine(ParryReset());

                }


            }

            ParryPointIncreaserClose();
            ParryPointIncreaser2Close();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("EnemyBullet"))
        {
            bullet = other.gameObject;
            if (bullet != null)
            {
                bulletInRange = true;
                Debug.Log("b in r");
            }

        }

        if (other.CompareTag("Enemy"))
        {
           
            enemyInRange = true;
            enemScript = other.GetComponent<MeleeEnemy1>();
            Debug.Log("e in r");
            
        }

        if (other.CompareTag("ImpactCircle"))
        {
            impactRingInRange = true;
        }

        if (other.CompareTag("Ball"))
        {
           
            ballInRange = true;
            Debug.Log("ball in r");
        }
        if (other.CompareTag("Ball2"))
        {

            ballInRange2 = true;
            Debug.Log("ball in r");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            bulletInRange = false;
            bullet = null;
            Debug.Log("bulletLeft");
        }

        if (other.CompareTag("Enemy"))
        {
            enemyInRange = false;
            
            enemScript = null;
            Debug.Log("enemy left premises");
        }

        if (other.CompareTag("Ball"))
        {
            ballInRange = false;
        }

        if (other.CompareTag("Ball2"))
        {
            ballInRange2 = false;
        }


        if (other.CompareTag("ImpactCircle"))
        {
            impactRingInRange = false;
        }


    }
    public IEnumerator ParryReset()
    {
        yield return new WaitForSeconds(0.27f);
        Debug.Log("RESET");
        anim.SetBool("canZoom", false);
        //canParry = true;
        parryEnsurer.SetActive(false);
        parryEnsurer2.SetActive(false);
        parryEnsurer3.SetActive(false);
        parryEnsurer4.SetActive(false);
        parryEnsurer5.SetActive(false);
        parryRing.SetActive(false);
        parried = false;
        ensureTimer = 0f;
        
        
    }

    public IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(0.05f);
        //bulletInRange = false;
        Destroy(bullet);
        bullet = null;


    }


    public IEnumerator ParryMiss()
    {
        yield return new WaitForSeconds(1.5f);
        canDecrease = true;
        ensureTimer = 0f;
        
        

            if (canDecrease)
            {

                if (pCount > 3)
                {


                    pCount -= 3;
                    canDecrease = false;
                }
            }
        

        if (canDecrease)
        {


            if (pCount <= 3)
            {
                pCount = 0;
                canDecrease = false;
            }
        }
        canParry = true;
        pm.canChargeShot = true;
        pm.canShoot = true;
        missed = false;
        sr.color = Color.white;
    }

    public void ParryPointIncreaserUnlock()
    {
        SoundManagerScript.PlaySound("upgrade");
        parryPointIncreaserUnlocked = true;
        parryPointOpenable = true;
        Time.timeScale = 1;
        if (parryPointOpenable)
        {
            ppTut.GetComponent<Animator>().SetBool("open", true);
            parryPointOpenable = false;
            parryPointClosable = true;
            Time.timeScale = 0;
        }
    }

    public void ParryPointIncreaserClose()
    {
        if(Input.GetKeyDown(KeyCode.X) && parryPointClosable)
        {
            Time.timeScale = 1;
            parryPointClosable = false;
            ppTut.GetComponent<Animator>().SetBool("open", false);
            ppTut.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void ParryPointIncreaser2Unlock()
    {
        SoundManagerScript.PlaySound("upgrade");
        parryPointIncreaser2Unlocked = true;
        parryPoint2Openable = true;
        Time.timeScale = 1;
        if (parryPoint2Openable)
        {
            ppTut2.GetComponent<Animator>().SetBool("open", true);
            parryPoint2Openable = false;
            parryPoint2Closable = true;
            Time.timeScale = 0;
        }
    }

    public void ParryPointIncreaser2Close()
    {
        if (Input.GetKeyDown(KeyCode.X) && parryPoint2Closable)
        {
            Time.timeScale = 1;
            parryPoint2Closable = false;
            ppTut2.GetComponent<Animator>().SetBool("open", false);
            ppTut2.GetComponent<Animator>().SetBool("close", true);
        }
    }
}
   



