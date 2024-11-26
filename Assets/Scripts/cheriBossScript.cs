using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheriBossScript : MonoBehaviour
{
    public SpadeShooter ss;
    public SpadeShooter ss2;
    public SpadeShooter ss3;
    public DiamondScript ds;
    public HeartBulletScript hbs;
    public ClubScriptSpawnerThing cs;

    public bool diamondTime;
    public bool spadeTime;
    public bool clubTime;
    public bool heartTime;
    public bool cardShieldSpawnTime;
    public bool canSpawnShield;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public Transform cardLoc1;
    public Transform cardLoc2;
    public Transform cardLoc3;
    public Transform cardLoc4;
    public float cardTimer;
    public float cardTimerMax;
    public int warpNum;
    public Transform warpLoc1;
    public Transform warpLoc2;
    public Transform warpLoc3;
    public Transform warpLoc4;
    public Transform warpLoc5;
    public Transform warpLoc6;
    public Transform warpLoc7;
    public Transform warpLoc8;
    public Transform warpLoc9;
    public Transform warpLoc10;
    public bool canWarp;
    public bool canAttackRoll;

    public int attackRNG;
    public float attackTimer;
    public float attackMaxTime;
    public bool canStartAttackRolling;
    public GameObject nonPrefabGameObjectCardLocationGuy;

    public GameObject cheriLaserCollection1;
    public GameObject cheriLaserCollection2;
    public GameObject cheriLaserCollection3;
    public GameObject cheriLaserCollection4;
    public GameObject cheriLaserCollection5;
    public GameObject cheriLaserCollection6;
    public GameObject cheriLaserCollection7;   
    public GameObject cheriLaserCollection8;

    public bool laserTime;
    public bool fireLaser;

    public GameObject laserWarning0;
    public GameObject laserWarning1;
    public GameObject laserWarning2;
    public GameObject laserWarning3;
    public GameObject laserWarning4;
    public GameObject laserWarning5;
    public GameObject laserWarning6;
    public GameObject laserWarning7;

    public int randomizeLaserWarningTimes;
    public int timesRandomized;
    public int randomLaserSelecter;
    public bool canRandomize = true;

    public float laserMixUpRandomizeWaitTime;
    public float laserDecidedFireTime;
    public bool canSetNum;

    public GameObject warpFiringPointLocation1;
    public GameObject warpFiringPointLocation2;
    public GameObject warpFiringPointLocation3;
    public GameObject warpFiringPointLocation4;
    public GameObject warpFiringPointLocation5;
    public GameObject warpFiringPointLocation6;

    public GameObject warpPellet;
    public GameObject cardWarpAnim;
    public float warpBulletForce;
    public MeleeEnemy1 me1;
    public GameObject warpPoint7;
    public GameObject warpPoint8;
    public bool firstLaserTime;
    public bool secondLaserTime;
    public int laserMax;
    public int laserCount;
    public float laserWaitTimeForTheReset;

    public float a1;
    public float a2;
    public float a3;
    public float a4;
    public float a5;
    public float a6;

    public bool annoyingFire;
    public bool warp7ing;
    public bool warp8ing;
    public bool warp8security;
    public bool warp7security;
    public bool healthLaserActivate;
    public bool healthLaserActivate2;

    public bool destroyLasers;

    public float ssi;
    public float sst;

    public Animator anim;
    public GameObject lightningzone;
    public float newAttackTime;
    public int lastAttackNum;
    public GameObject chaosBall;
    public bool ballin;
    public Transform bss;
    public PlayerMovement pm;
    public Transform startingTransform;

    public cutscene cuts2;
    public bool fightStarted;
    // Start is called before the first frame update
    void Start()
    {
        startingTransform = gameObject.transform;
        canSpawnShield = true;
        lightningzone.SetActive(false);
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.dead)
        {
            StartCoroutine(DestroyL());
            canStartAttackRolling = false;
            transform.position = startingTransform.position;
            lightningzone.SetActive(false);
            warp7ing = false;
            warp8ing = false;
            fightStarted = false;

        }

        if(fightStarted == false)
        {
            destroyLasers = true;
            transform.position = startingTransform.position;
            warp7ing = false;
            warp8ing = false;

        }

        if (me1.dead)
        {
            canAttackRoll = false;
            if(card1 != null)
            {
                card1.SetActive(false);
            }
            if (card2 != null)
            {
                card2.SetActive(false);
            }
            if (card3 != null)
            {
                card3.SetActive(false);
            }
            if (card4 != null)
            {
                card4.SetActive(false);
            }
            destroyLasers = true;
            warp7security = false;
            warp8security = false;
            firstLaserTime = false;
            secondLaserTime = false;
            canStartAttackRolling = false;
            heartTime = false;
            canSpawnShield = false;
            cardShieldSpawnTime = false;
            annoyingFire = false;
            canRandomize = false;
            canWarp = false;
            heartTime = false;
            spadeTime = false;
            clubTime = false;
            lightningzone.SetActive(false);


        }
        if (diamondTime)//KINDA JUST FOR DEBUG
        {
            FireDiamonds();
        }
        if (spadeTime)
        {
            SpadeFire();
        }
        if (heartTime)
        {
            FireHeart();
        }

        if (cardShieldSpawnTime)
        {
            CardShield();
        }

        if (!canSpawnShield)
        {
            cardTimer += Time.deltaTime;
            if(cardTimer >= cardTimerMax)
            {
                canSpawnShield = true; //Because, in the crate script, the cards SHOULD have been deactivated by this time.
                cardTimer = 0;
            }
        }

        if (clubTime)
        {
            ClubSpawn();
           
        }

        if (canWarp)
        {
            cardWarpAnim.SetActive(true);
        }

        if (fireLaser)
        {
            LaserFire();
        }

        if (laserTime)
        {
            LaserDecider();
        }

        if (annoyingFire)
        {
            FireBulletWarp();
        }
        if (ballin)
        {
            SoundManagerScript.PlaySound("HEARTSPAWN");
            Instantiate(chaosBall, bss.position, bss.rotation);
            ballin = false;
        }
        /////////////////////////////////////
        ///

        if (canStartAttackRolling)
        {
            fightStarted = true;
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackMaxTime)
            {
                canAttackRoll = true;
            }
            if (canAttackRoll)
            {               
                anim.SetBool("wave", true);
                anim.SetBool("idle", false); 
            }
        }

        if ((me1.health <= me1.maxHealth / 2) || healthLaserActivate) //HP below 50
        {
            if (firstLaserTime) //Ensures that we only do the first laser set one time.
            {
                Debug.Log("LASER 1");

                if (warp7security)
                {
                    canWarp = true;
                    warp7ing = true;
                }


                if (warp7ing)
                {


                    canStartAttackRolling = false;
                    warp7ing = true;
                    canWarp = true;
                    destroyLasers = false;
                    if (laserCount < laserMax)
                    {
                        LaserDecider();
                    }
                    if (laserCount >= laserMax)
                    {
                        destroyLasers = true;
                        laserCount = 0;
                        firstLaserTime = false;
                        canStartAttackRolling = true;
                        warp7ing = false;
                        canWarp = true;
                        laserWarning0.SetActive(false);
                        laserWarning1.SetActive(false);
                        laserWarning2.SetActive(false);
                        laserWarning3.SetActive(false);
                        laserWarning4.SetActive(false);
                        laserWarning5.SetActive(false);
                        laserWarning6.SetActive(false);
                        laserWarning7.SetActive(false);
                        warp8security = true;
                        warp7security = true;
                        healthLaserActivate = false;
                        secondLaserTime = true;
                        lightningzone.SetActive(true);
                    }
                }
            }
        }
        if ((me1.health <= me1.maxHealth / 5) || healthLaserActivate2) //HP below 20
        {
            if (secondLaserTime) //Ensures that we only do the first laser set one time.
            {
                Debug.Log("OKAY SECOND LASER TIME");
                if (warp8security)
                {
                    canWarp = true;
                    warp8ing = true;
                }


                if (warp8ing)
                {


                    canStartAttackRolling = false;
                    warp8ing = true;
                    canWarp = true;
                    destroyLasers = false;
                    if (laserCount < laserMax)
                    {
                        LaserDecider();
                    }
                    if (laserCount >= laserMax)
                    {
                        destroyLasers = true;
                        laserCount = 0;
                        secondLaserTime = false;
                        canStartAttackRolling = true;
                        warp8ing = false;
                        canWarp = true;
                        laserWarning0.SetActive(false);
                        laserWarning1.SetActive(false);
                        laserWarning2.SetActive(false);
                        laserWarning3.SetActive(false);
                        laserWarning4.SetActive(false);
                        laserWarning5.SetActive(false);
                        laserWarning6.SetActive(false);
                        laserWarning7.SetActive(false);
                        warp8security = true;
                        warp7security = true;
                        healthLaserActivate = false;
                        secondLaserTime = false;
                        attackMaxTime = newAttackTime;
                    }
                }
            }
        }
    
        if (destroyLasers)
        {
            laserWarning0.SetActive(false);
            laserWarning1.SetActive(false);
            laserWarning2.SetActive(false);
            laserWarning3.SetActive(false);
            laserWarning4.SetActive(false);
            laserWarning5.SetActive(false);
            laserWarning6.SetActive(false);
            laserWarning7.SetActive(false);
        }

        CardLocationGuyFollower();
    }

    public void FireDiamonds()
    {
        ds.DiamondFire();
        diamondTime = false;
    }

    public void SpadeFire()
    {
        ss.OpenFire();
        ss2.OpenFire();
        ss3.OpenFire();
        spadeTime = false;
    }

    public void FireHeart()
    {
        hbs.OpenHeart();
        heartTime = false;
    }

    public void CardShield()
    {       
        if (canSpawnShield)
        {
            (Instantiate(card1, cardLoc1.position, cardLoc1.rotation) as GameObject).transform.parent = nonPrefabGameObjectCardLocationGuy.transform;
            (Instantiate(card2, cardLoc2.position, cardLoc2.rotation) as GameObject).transform.parent = nonPrefabGameObjectCardLocationGuy.transform;
            (Instantiate(card3, cardLoc3.position, cardLoc3.rotation) as GameObject).transform.parent = nonPrefabGameObjectCardLocationGuy.transform;    
            (Instantiate(card4, cardLoc4.position, cardLoc4.rotation) as GameObject).transform.parent = nonPrefabGameObjectCardLocationGuy.transform;
        }
        SoundManagerScript.PlaySound("CARD");
        canSpawnShield = false;
    }
    public void ClubSpawn()
    {
        StartCoroutine(ClubCoroutineSOUNDEFFECT());
        cs.ClubFire();
        clubTime = false;
    }

    public void DestroyCard()
    {
        if(card1 != null)
        {
            Destroy(card1);
        }
        if (card2 != null)
        {
            Destroy(card2);
        }
        if (card3 != null)
        {
            Destroy(card3);
        }
        if (card4 != null)
        {
            Destroy(card4);
        }
    }

    public void Warp()
    {

        if (!pm.dead)
        {


            if (warp7ing)
            {
                Warp7();
                anim.SetBool("wave", false);
                anim.SetBool("idle", true);
            }

            if (warp8ing)
            {
                Warp8();
                anim.SetBool("wave", false);
                anim.SetBool("idle", true);
            }
            if (!warp7ing)
            {
                if (!warp8ing)
                {

                    anim.SetBool("wave", false);
                    anim.SetBool("idle", true);

                    warpNum = Random.Range(1, 11);
                    if (warpNum == 1)
                    {
                        transform.position = warpLoc1.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 2)
                    {
                        transform.position = warpLoc2.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 3)
                    {
                        transform.position = warpLoc3.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 4)
                    {
                        transform.position = warpLoc4.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 5)
                    {
                        transform.position = warpLoc10.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 6)
                    {
                        transform.position = warpLoc5.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 7)
                    {
                        transform.position = warpLoc6.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 8)
                    {
                        transform.position = warpLoc7.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 9)
                    {
                        transform.position = warpLoc8.position;
                        SoundManagerScript.PlaySound("warp");
                    }
                    if (warpNum == 10)
                    {
                        transform.position = warpLoc9.position;
                        SoundManagerScript.PlaySound("warp");
                    }


                    canWarp = false;

                }
            }
        }

        if (pm.dead)
        {
            transform.position = startingTransform.position;
        }
    }

    public void Warp7()
    {
        if (warp7security)
        {
            transform.position = warpPoint7.transform.position;
            warp7security = false;
        }
    }

    public void Warp8()
    {
        if (warp8security)
        {
            Debug.Log("WARP 8'D JUST NOW");
            transform.position = warpPoint8.transform.position;          
            warp8security = false;
            
        }
    }

    public void AttackRoll()
    {
        attackRNG = Random.Range(1, 12);

        if (canAttackRoll)
        {
            if (lastAttackNum == 2)
            {
                if (attackRNG == 2)
                {
                    attackRNG = 1; //If it sets up double shields, (if it rolls 2 twice), just teleport.
                }
            }
        }
        if (attackRNG == 1)
        {
            cardWarpAnim.SetActive(true);
        }
        if(attackRNG == 2)
        {
            CardShield();
            SpadeFire();
        }
        if(attackRNG == 3)
        {
            ClubSpawn();
        }
        if(attackRNG == 4)
        {
            //FireHeart();
            heartTime = true;
            Debug.Log("hearts!!");
        }
        if(attackRNG == 5)
        {
            SpadeFire();
        }
        if(attackRNG == 6)
        {
            FireDiamonds();
            SpadeFire();
        }
        if (attackRNG == 7)
        {
            cardWarpAnim.SetActive(true);
        }
        if(attackRNG == 8)
        {
            FireDiamonds();
        }
        if(attackRNG == 9)
        {
            SpadeFire();
            cardWarpAnim.SetActive(true);

        }
        if(attackRNG == 10)
        {
            ClubSpawn();
            cardWarpAnim.SetActive(true);
        }
        if(attackRNG == 11)
        {
            heartTime = true;
            cardWarpAnim.SetActive(true);


        }

        lastAttackNum = attackRNG;
        attackTimer = 0;
        canAttackRoll = false;
    }

    public void CardLocationGuyFollower()
    {
        nonPrefabGameObjectCardLocationGuy.transform.position = transform.position;
    }

    public void LaserFire()
    {
        if (randomLaserSelecter == 1)
        {
            cheriLaserCollection1.SetActive(true);
        }
        if (randomLaserSelecter == 2)
        {
            cheriLaserCollection2.SetActive(true);
        }
        if (randomLaserSelecter == 3)
        {
            cheriLaserCollection3.SetActive(true);
        }
        if (randomLaserSelecter == 4)
        {
            cheriLaserCollection4.SetActive(true);
        }
        if (randomLaserSelecter == 5)
        {
            cheriLaserCollection5.SetActive(true);
        }
        if (randomLaserSelecter == 6)
        {
            cheriLaserCollection6.SetActive(true);
        }
        if (randomLaserSelecter == 7)
        {
            cheriLaserCollection7.SetActive(true);
        }
        if (randomLaserSelecter == 8)
        {
            cheriLaserCollection8.SetActive(true);
        }
        laserCount += 1;
        SoundManagerScript.PlaySound("LASERFIRE");
        if (laserCount < laserMax)
        {
            StartCoroutine(LaserFiredButResetAndGetReadyToShootAnother());
        }
        fireLaser = false;
        laserWarning0.SetActive(false);
        laserWarning1.SetActive(false);
        laserWarning2.SetActive(false);
        laserWarning3.SetActive(false);
        laserWarning0.SetActive(false);
        Debug.Log("LASER FIRED????");
    }

    public void LaserDecider()
    {
        if (canSetNum)
        {
            randomizeLaserWarningTimes = Random.Range(1, 7);
            canSetNum = false;
        }

        if(timesRandomized <= randomizeLaserWarningTimes)
        {
            if (canRandomize)
            {
                randomLaserSelecter = Random.Range(1, 9);
                SoundManagerScript.PlaySound("LASERSWITCH");
                RandomLaserSelection();
                StartCoroutine(RandomizeWaitTime());
                
            }
        }
        if(timesRandomized > randomizeLaserWarningTimes)
        {
            Debug.Log("timesRandomized is factually > randomizeLaserWarningTimes");
            StartCoroutine(LaserFireSetUp());
            timesRandomized = 0;
            laserTime = false;
            canSetNum = true;
        }
    }

    public void RandomLaserSelection()
    {
        if (!destroyLasers)
        {


            if (randomLaserSelecter == 1)
            {
               
                laserWarning0.SetActive(true);
                laserWarning1.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning4.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(false);
            }
            if (randomLaserSelecter == 2)
            {
                laserWarning1.SetActive(true);
                laserWarning0.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning4.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(false);

            }
            if (randomLaserSelecter == 3)
            {
                laserWarning2.SetActive(true);
                laserWarning1.SetActive(false);
                laserWarning0.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning4.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(false);
            }
            if (randomLaserSelecter == 4)
            {
                laserWarning3.SetActive(true);
                laserWarning1.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning0.SetActive(false);
                laserWarning4.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(false);
            }
            if (randomLaserSelecter == 5)
            {
                laserWarning4.SetActive(true);
                laserWarning1.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning0.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(false);
            }
            if (randomLaserSelecter == 6)
            {
                laserWarning4.SetActive(false);
                laserWarning1.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning0.SetActive(false);
                laserWarning5.SetActive(true);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(false);
            }
            if (randomLaserSelecter == 7)
            {
                laserWarning4.SetActive(false);
                laserWarning1.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning0.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(true);
                laserWarning7.SetActive(false);
            }
            if(randomLaserSelecter == 8)
            {
                
                laserWarning4.SetActive(false);
                laserWarning1.SetActive(false);
                laserWarning2.SetActive(false);
                laserWarning3.SetActive(false);
                laserWarning0.SetActive(false);
                laserWarning5.SetActive(false);
                laserWarning6.SetActive(false);
                laserWarning7.SetActive(true);
                
            }
        }
    }

    public IEnumerator RandomizeWaitTime()
    {
        canRandomize = false;
        yield return new WaitForSeconds(laserMixUpRandomizeWaitTime);
        timesRandomized += 1;
        canRandomize = true;
        
    }

    public IEnumerator LaserFireSetUp()
    {
        yield return new WaitForSeconds(laserDecidedFireTime);
        LaserFire();
        laserWarning0.SetActive(false);
        laserWarning1.SetActive(false);
        laserWarning2.SetActive(false);
        laserWarning3.SetActive(false);
        laserWarning4.SetActive(false);
    }

    public void FireBulletWarp()
    {
        SoundManagerScript.PlaySound("CLUBSHOOT");
        GameObject p1 = Instantiate(warpPellet, warpFiringPointLocation1.transform.position, warpFiringPointLocation1.transform.rotation);
        GameObject p2 =Instantiate(warpPellet, warpFiringPointLocation2.transform.position, warpFiringPointLocation2.transform.rotation);
        GameObject p3 =Instantiate(warpPellet, warpFiringPointLocation3.transform.position, warpFiringPointLocation3.transform.rotation);
        GameObject p4 = Instantiate(warpPellet, warpFiringPointLocation4.transform.position, warpFiringPointLocation4.transform.rotation);
        GameObject p5 = Instantiate(warpPellet, warpFiringPointLocation5.transform.position, warpFiringPointLocation5.transform.rotation);
        GameObject p6 = Instantiate(warpPellet, warpFiringPointLocation6.transform.position, warpFiringPointLocation6.transform.rotation);

        p1.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(a1, warpBulletForce));
        p2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(a2, warpBulletForce));
        p3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(a3, warpBulletForce));
        p4.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(a4, warpBulletForce));
        p5.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(a5, warpBulletForce));
        p6.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(a6, warpBulletForce));
        
        Debug.Log("bulletShot");
    }

    public void CardWarperSetInactive()
    {
        
        cardWarpAnim.SetActive(false);
    }
    public IEnumerator LaserFiredButResetAndGetReadyToShootAnother()
    {
        
        yield return new WaitForSeconds(laserWaitTimeForTheReset);
        if(laserCount < laserMax)
        {
            LaserDecider();
        }
        if(laserCount >= laserMax)
        {
            destroyLasers = true;
            laserCount = 0;
            firstLaserTime = false;
            canStartAttackRolling = true;
            warp7ing = false;
            canWarp = true;
            warp8security = true;
            laserWarning0.SetActive(false);
            laserWarning1.SetActive(false);
            laserWarning2.SetActive(false);
            laserWarning3.SetActive(false);
            laserWarning4.SetActive(false);
            laserWarning5.SetActive(false);
            laserWarning6.SetActive(false);
            laserWarning7.SetActive(false);
            healthLaserActivate = false;
            secondLaserTime = true;
        }
    }

    public void DestroyLasersTrue()
    {
        destroyLasers = true;
    }

    public IEnumerator ScrewWarp8WeHateWarp8()
    {
        yield return new WaitForSeconds(1.4f);
        warp8ing = false;
    }

    public IEnumerator ClubCoroutineSOUNDEFFECT()
    {
        if (!me1.dead)
        {


            SoundManagerScript.PlaySound("CLUBSPAWN");
            yield return new WaitForSeconds(3f);
            SoundManagerScript.PlaySound("CLUBGUN");
            yield return new WaitForSeconds(2f);
            SoundManagerScript.PlaySound("CLUBSHOOT");
            yield return new WaitForSeconds(2f);
            SoundManagerScript.PlaySound("CLUBDESPAWN");
        }
    }

    public void CAST()
    {      
        AttackRoll();
        CameraShake.Instance.ShakeCamera(ssi, sst);
        SoundManagerScript.PlaySound("wave");
    }

    public void HANDWAVECASTANIMATIONCANCEL()
    {
        anim.SetBool("wave", false);
        anim.SetBool("idle", true);

    }

    public IEnumerator DestroyL()
    {
        destroyLasers = true;
        yield return new WaitForSeconds(1f);
        destroyLasers = false;
        transform.position = startingTransform.position;
    }
}
