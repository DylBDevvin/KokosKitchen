using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    public bool hit;
    public bool nuggetCooldown;
    public bool canLocate;
    public bool canZap;
    public bool hbActive;
    public bool canSwitch;

    public bool songSwitchable;

    public bool set;
    public bool set2;
    public bool set3;

    public Transform target;
    public Transform Ptarget;
    public Transform firingPoint;
    public Transform chargeTransform;

    public Vector3 targetDir;
    public Vector3 playerLoc;

    public AudioClip chickenBossTheme;

    public float distanceToTarget;

    public GameObject nugget;
    public GameObject LightningMarker;
    public GameObject door;
    public GameObject lightning;
    public GameObject lightningDropper;
    public GameObject lightningHitbox;
    public GameObject charge;

    public GameObject laserD;
    public GameObject laserU;
    public GameObject laserL;
    public GameObject laserR;


    public float lastAttackTime;
    public float attackDelay;
    public float nuggetForce;
    public float nuggetCooldownResetTime;
    public float speed;
    public float lightningTimer;
    public float lightningLocateTime;
    public float zapTimer;
    public float zapTime;
    public float chargeTimer;
    public float startChargeTime;
    public float charge1Timer;
    public float charge2Timer;
    public float charge3Timer;
    public float charge4Timer;
    public float charge1TimerLimit;
    public float charge2TimerLimit;
    public float charge3TimerLimit;
    public float charge4TimerLimit;
    public float charge3Movespeed;
    public float initialCooldown;
    public float initialCooldownLimit;

    public float camShakeIntensity;
    public float camShakeTime;

    public float r;

    public int nuggetTossCount;
    public int nuggetMaxToss;

    public Animator anim;
    public Animator flashAnim;
    public Animator chargeAnim;

    public Transform[] patrolPoints;
    public Transform currentPatrolPoint;
    public Transform chargeLocation;
    public int currentPatrolIndex;

    public MeleeEnemy1 me1;
    public MusicController mc;
    public PlayerMovement pm;

    public Quaternion q;


    // Start is called before the first frame update
    void Start()
    {
        LightningMarker.SetActive(false);
        anim = GetComponent<Animator>();
        mc = FindObjectOfType<MusicController>();
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        Ptarget = currentPatrolPoint;
        door.GetComponent<InteractionObject>().OpenDoor();
        me1 = GetComponent<MeleeEnemy1>();
        charge.SetActive(false);
        laserD.SetActive(false);
        pm = FindObjectOfType<PlayerMovement>();
        canSwitch = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.dead)
        {
            LightningMarker.SetActive(false);
            ChickenReset();
            
        }
        if (hit)
        {        
            anim.SetBool("hit", true);
            Patrol();
            FireNugget();
            Lightning();
            Charge();
            door.GetComponent<InteractionObject>().CloseDoor();
            //mc.MuteButton();
            if (!songSwitchable) //Only fades once.
            {
                mc.CrossFade(chickenBossTheme);
                songSwitchable = true;
            }
            
            
        }

        if (me1.dead)
        {
            
            hit = false;
            initialCooldown = 0;
            chargeTimer = 0;
            charge1Timer = 0;
            charge2Timer = 0;
            charge3Timer = 0;
            charge4Timer = 0;
            gameObject.SetActive(false);
            charge.SetActive(false);
            me1.canTakeDmg = true;
            laserD.SetActive(false);
            laserU.SetActive(false);
            laserR.SetActive(false);
            laserL.SetActive(false);

            set = false;
            set2 = false;
            set3 = false;
        }

        if (!hit)
        {
            anim.SetBool("hit", false);
            door.GetComponent<InteractionObject>().OpenDoor();
            songSwitchable=false;
        }

        targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        q = Quaternion.AngleAxis(angle, Vector3.forward);
        firingPoint.transform.rotation = Quaternion.RotateTowards(firingPoint.transform.rotation, q, 180 * Time.deltaTime);
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        
    }

    public void FireNugget()
    {
        initialCooldown += Time.deltaTime;
        if (initialCooldown >= initialCooldownLimit)
        {
            initialCooldown = initialCooldownLimit;

            if (Time.time > lastAttackTime + attackDelay && !nuggetCooldown)
            {

                if (hit)
                {
                    //Hit the player - fire the projectile

                    GameObject newBullet = Instantiate(nugget, firingPoint.transform.position, firingPoint.transform.rotation);
                    newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, nuggetForce));
                    lastAttackTime = Time.time;
                    nuggetTossCount++;
                    if (nuggetTossCount >= nuggetMaxToss)
                    {
                        nuggetCooldown = true;
                        StartCoroutine(NuggetCooldownReset());
                    }
                }
            }
        }
    }

    public IEnumerator NuggetCooldownReset()
    {

        yield return new WaitForSeconds(nuggetCooldownResetTime);
        nuggetCooldown = false;
        nuggetTossCount = 0;
    

    }

    void Patrol()
    {
        Ptarget = currentPatrolPoint;
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint.position, step);

        if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.2f)
        {
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];

        }

    }
    void Lightning()
    {
        if (hbActive)
        {
            lightningHitbox.SetActive(true);
            Debug.Log("WAS IT ACTIVE?");
        }

        if (!hbActive)
        {
            lightningHitbox.SetActive(false);
            //Debug.Log("HB INACTIVE");
        }

        lightningTimer += Time.deltaTime;

        if(lightningTimer >= lightningLocateTime && !canLocate)
        {
            //Drop the marker at the player position, play sound effect ONCE
            LightningMarker.SetActive(true);
            SoundManagerScript.PlaySound("thunder");
            LightningMarker.transform.position = target.transform.position; 
            lightningHitbox.transform.position = target.transform.position;
            canLocate = true;
            canZap = true;           
        }

        if (canZap)
        {
            zapTimer += Time.deltaTime;
        }

        if(zapTimer >= zapTime)
        {
            //Drop the lightning bolt
            Instantiate(lightning, lightningDropper.transform.position, lightningDropper.transform.rotation);
            StartCoroutine(ActiveHitBox());
            Debug.Log("LIGHTNIIIIIIIIIIIIIIIIIIIIING!!!!");
            zapTimer = 0;
            lightningTimer = 0;
            canZap = false;
            canLocate = false;
            LightningMarker.SetActive(false);
        }
    }

    void Charge()
    {
        float step = charge3Movespeed * Time.deltaTime;

        chargeTimer += Time.deltaTime;

        if (chargeTimer >= startChargeTime) //Get the charge ball out
        {
            charge.SetActive(true);
            charge1Timer += Time.deltaTime;
            if (!set)
            {
                SoundManagerScript.PlaySound("charge1");
                set = true;
            }
           
        }

        if(charge1Timer >= charge1TimerLimit)
        {
            chargeAnim.SetBool("charge2", true);
            charge2Timer += Time.deltaTime;
            if (!set2)
            {
                SoundManagerScript.PlaySound("charge2");
                set2 = true;
            }
        }

        if(charge2Timer >= charge2TimerLimit) //BOUTA FIRE
        {
            chargeAnim.SetBool("charge3", true);
            chargeAnim.SetBool("charge2", false);
            charge3Timer += Time.deltaTime;
            charge.transform.position = Vector2.MoveTowards(charge.transform.position, chargeLocation.position, step);
            //charge.transform.rotation = Quaternion.RotateTowards(charge.transform.rotation, q, 180 * Time.deltaTime);
        }

        if(charge3Timer >= charge3TimerLimit) // FIRE!!!!!
        {
            if (!set3)
            {
                SoundManagerScript.PlaySound("laser");
                CameraShake.Instance.ShakeCamera(camShakeIntensity, camShakeTime);
                set3 = true;
            }

            
            charge.transform.position = chargeTransform.position;
            charge.transform.rotation = chargeTransform.rotation;
            charge.SetActive(false);
            chargeAnim.SetBool("charge3", false);

           //RESET HERE// if (targetDir.y > targetDir.x)//Vertical Shots
            
                if (targetDir.y < 0 && (targetDir.x > targetDir.y && targetDir.x < -targetDir.y) && canSwitch)
                {
                    laserD.SetActive(true);
                    canSwitch = false;
                }
                if (targetDir.y > 0 && (targetDir.x > -targetDir.y && targetDir.x < targetDir.y) && canSwitch)
                {
                    laserU.SetActive(true);
                    canSwitch = false;
                }
     
                if(targetDir.x < 0 && (targetDir.y > targetDir.x && targetDir.y < -targetDir.x) && canSwitch)
                {
                    laserL.SetActive(true);
                    canSwitch = false;
                }

                if(targetDir.x > 0 && (targetDir.y > -targetDir.x && targetDir.y < targetDir.x) && canSwitch)
                {
                    laserR.SetActive(true);
                    canSwitch = false;
                }
                        
            charge4Timer += Time.deltaTime;
        }

        if(charge4Timer >= charge4TimerLimit) //FIRING FINISHED.
        {

            laserD.GetComponent<LaserScriptEnemy>().canDamage = true;
            laserU.GetComponent<LaserScriptEnemy>().canDamage = true;
            laserL.GetComponent<LaserScriptEnemy>().canDamage = true;
            laserR.GetComponent<LaserScriptEnemy>().canDamage = true;

            canSwitch = true;
            laserD.SetActive(false);
            laserU.SetActive(false);
            laserL.SetActive(false);
            laserR.SetActive(false);
            
            chargeTimer = 0;
            charge1Timer = 0;
            charge2Timer = 0;
            charge3Timer = 0;
            charge4Timer = 0;

            set = false;
            set2 = false;
            set3 = false;

            
        }
    }

    public void ChickenReset()
    {
        me1.ResetStats();
        initialCooldown = 0;
        chargeTimer = 0;
        charge1Timer = 0;
        charge2Timer = 0;
        charge3Timer = 0;
        charge4Timer = 0;
        charge.SetActive(false);
        me1.canTakeDmg = true;
        laserD.SetActive(false);
        laserU.SetActive(false);
        laserR.SetActive(false);
        laserL.SetActive(false);

        set = false;
        set2 = false;
        set3 = false;
    }

    public IEnumerator ActiveHitBox()
    {
        yield return new WaitForSeconds(0.2f); //LIGHTNING STRUCK
        hbActive = true;
        CameraShake.Instance.ShakeCamera(9f, .2f);
        flashAnim.SetBool("flash", true);
        SoundManagerScript.PlaySound("lightning");

        yield return new WaitForSeconds(0.1f);
        
        hbActive = false;
    }

}
