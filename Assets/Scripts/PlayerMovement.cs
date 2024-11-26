using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    public Vector2 movement;

    public GameObject player;

    public GameObject bullet;
    public GameObject bulletB;

    public GameObject water;
    public GameObject chargeBullet;

    public GameObject waterWalker;

    public float bulletForce;
    public float chargebulletForce;
    public int meleeDamage;
    public float meleeRange;
    public float health;
    public float maxHealth;
    public float cooldown;
    public float attackSpeed = 1f;
    public bool canMove = true;
    public bool canShoot = true;
    public bool canChargeShot = true;
    public bool canCharge = true;
    public bool isGliding;
    public bool canTakeDamage = true;

    public float stoptimer;
    public float shotCharge;
    public float holdDownTime;
    public float chargeShotCooldown;
    public float flashTimer;
    public float startTime;
    public bool timerOn = false;
    public Vector2 dir;
    public bool canKnockback = false;
    public bool isRunning = false;


    public bool ready = false;
    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool chargeShotTime;


    public Animator animator;
    public Vector3 change;


    public Text healthText;
    public Text levelText;
    public Text parryText;
    public GameObject menuPanel;
    public Text messageText;


    public Transform meleePoint;
    public Transform meleePoint2;
    public Transform meleePoint3;
    public GameObject shadow;

    public ShopScript ss;
    public ShopScript2 ss2;
    public FlashScript fs;
    public DialogueManager dm;
    public PlayerInteract pi;
    public Parrier p;
    public LevelSystem ls;


    public CircleCollider2D parrier;

    public bool isLocked;
    public bool allowKnockback;

    public bool grandLock;
    public bool GRANDERLOCK;

    public float knockBackForce;
    public float knockBackForce2;
    public float knockBackForce3;

    public bool chargeDamageMult;

    public Image hpImage;
    public Image hpEffectImage;

    private float hurtSpeed = 0.005f;

    public GameObject glubGlub;
    public float ggSpeed = 3f;
    public Transform ggDown;
    public Transform ggUp;
    public Transform ggLeft;
    public Transform ggRight;
    public bool obtainedGlub;
    public bool laserBeamUnlocked;

    public bool cityUnlocked;
    public bool beachUnlocked;
    public bool royalUnlocked;
    public bool caveUnlocked;
    public bool wrongNeighborhoodUnlocked;
    public bool coldUnlocked;
    public bool raidEXTunlocked;
    public bool raidINTunlocked;

    public bool facingDown;
    public bool facingUp;
    public bool facingRight;
    public bool facingLeft;

    public GameObject laserD;
    public GameObject laserU;
    public GameObject laserL;
    public GameObject laserR;

    public bool laserKnockbacking;
    public bool knockbackDampening;

    public float laserScreenshakeIntensity = 22;
    public float laserScreenshakeTime = 0.1f;
    public float initialKnockbackTime = 0.3f;
    public float initialKnockbackDampenerTime = 0.2f;
    public float originKnockbackValue;
    public float knockbackMinuser;

    public GameObject laserTutorial;
    public bool laserOpenable;
    public bool laserClosable;

    public GameObject healTutorial;
    public bool healUnlocked;
    public bool healOpenable;
    public bool healClosable;

    public GameObject healAndSpeedTutorial;
    public bool healAndSpeedUnlocked;
    public bool healAndSpeedOpenable;
    public bool healAndSpeedClosable;

    public GameObject healAndSpeedAndAttackTutorial;
    public bool HSAUnlocked;
    public bool HSAOpenable;
    public bool HSAClosable;

    public GameObject bouncyBulletTutorial;
    public bool bbUnlocked;
    public bool bbOpenable;
    public bool bbClosable;

    public GameObject VineBoomTutorial;
    public bool vbUnlocked;
    public bool vbOpenable;
    public bool vbClosable;

    public GameObject genTut;
    public bool genTutUnlocked;
    public bool genTutOpenable;
    public bool genTutClosable;

    public GameObject genTut2;
    public bool genTutUnlocked2;
    public bool genTutOpenable2;
    public bool genTutClosable2;

    public GameObject genTut3;
    public bool genTutUnlocked3;
    public bool genTutOpenable3;
    public bool genTutClosable3;

    public GameObject chargeShotTutorial;
    public bool csUnlocked;
    public bool csOpenable;
    public bool csClosable;

    public GameObject parryTutorial;
    public bool pUnlocked;
    public bool pOpenable;
    public bool pClosable;

    public GameObject parryTutorial2;
    public bool pUnlocked2;
    public bool pOpenable2;
    public bool pClosable2;

    public GameObject parryTutorial3;
    public bool pUnlocked3;
    public bool pOpenable3;
    public bool pClosable3;

    public GameObject tripleShotTutorial;
    public bool tripleShotUnlocked;
    public bool tripleShotOpenable;
    public bool tripleShotClosable;



    public SpriteRenderer sprite;

    public GameObject speedBuffFX;
    public GameObject speedAttackBuffFX;

    public float buffTime = 7f;
    public float movementSpeedBuff = 3f;
    public float movementSpeedOriginValue;
    public bool speedBuffed;
    public bool dmgBuffed;

    public GameObject mashPotat;
    public bool mashPotatUnlocked;
    public bool located;

    public float itemBuffTime = 16f;
    public GameObject attackBuffLines;
    public GameObject speedBuffLines;

    public float movementSpeedItemBuff = 5;
    public int attackItemBuff = 5;

    public bool speedItemBuffed;
    public bool attackItemBuffed;
    public bool speedBuffing;
    public bool attackBuffing;

    public bool tripleShootUnlocked;
    public bool bouncyGearUnlocked;
    public bool bouncyGear;

    public int bounceShotSpeed;

    
    public GameObject kokoNormalImage;
    public GameObject kokoDamageImage;
    public float faceSwitchTime;
    public float dmgKBforce;
    public bool canDmgknockback;
    public float kbTime = 0.28f;
    public bool shoots = true;
    public bool hitstun;
    public float velocityLim;
    public bool noKnock;

    public bool dooring;

    public GameObject monCheriLoader;
    public float mcDistance;

    public Transform respawnTransform;
    public Transform cityTransform;
    public Transform beachTransform;
    public Transform royalTransform;
    public Transform caveTransform;
    public Transform caveTransform2;
    public Transform foreverAutumn;
    public Transform winter;
    public Transform winter2;
    public Transform doomGoop;
    public Transform cheri;
    public Transform cheriFinale;
    public Transform spring;
    public Transform cheri2ndHalf;
    public Transform doomGoop2;
    public Transform spring2;
    public Transform winter3;
    public Transform chickenRespawn;
    public Transform cheriStealthRespawn;
    public Transform cheriFinalSectionRespawn;
    public Transform ArenaRespawn;

    public int deathRNG;
    public bool canDeathRandomize;
    public GameObject redDeathScreen;
    public bool canRespawnEnemies;
    public Animator fadeAnim;
    public Transform deadPos;

    public bool t1;
    public bool t2;
    public bool dead;
    public float originMass;

    public bool generalTutorial;
    public bool genTutorialClear;

    public bool chargeShotUnlocked;
    public bool gtl;
    public bool gtlx;
    public bool gt2;
    public bool gtlx2;

    public bool p1;
    public bool px;
    public bool p2;
    public bool px2;

    public cutscene cuts;
    public cutscene cuts2;
    public cutscene cuts3;
    public MeleeEnemy1 me1Cheri;
   

    public bool teleportin;
    public Vector3 position;


    public ChestScript suitcase;

    public GameObject startScreen;
    public bool INSTARTSCREEN;

    public BoxCollider2D triggerBox;
    public MusicController mc;
    public AudioClip titleSong;

    public GameObject titleFadeObj;
    public Animator titleFade;
    public float x;
    public float y;

    public GameObject bagel;
    public Vector3 bagelSpawn;
    public RectTransform startScreenTransform;
    public float bx;
    public float bx2;
    public float by;
    public float by2;
  
    public float fireWaitTime;

    public ShopScript3 ss3;
    public ShopScript4 ss4;
    public ShopScript5 ss5;

    public MoneyBank mb;
    public int money;
    public int rats;

    public Text cityText;
    public Text beachText;
    public Text royalText;
    public Text caveText;
    public Text wrongNText;
    public Text coldText;
    public Text cheriEXTTEXT;
    public Text cheriINTTEXT;

    public bool DEBUG;
    public MenuScript ms;


    private void Start()
    {

       
       
        startScreen.SetActive(true);
        INSTARTSCREEN = true;
        triggerBox.enabled = false;
        
        mb = FindObjectOfType<MoneyBank>();

        t1 = true;
        List<GameObject> myList = new List<GameObject>();
        originMass = rb.mass;
        originKnockbackValue = knockBackForce2;
        movementSpeedOriginValue = movementSpeed;
        health = maxHealth;
        animator = GetComponent<Animator>();
        healthText.text = health.ToString();
        //At start - wait for player to click the start button before starting the game
        //Make the menu panel visible
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        ////messageText.text = "Press Start to Begin";
        //look up how to prevent player input
        //or let it load a scene, and make a title screen
        cooldown = attackSpeed;
        ss = FindObjectOfType<ShopScript>();
        ss2 = FindObjectOfType<ShopScript2>();
        fs = FindObjectOfType<FlashScript>();
        dm = FindObjectOfType<DialogueManager>();
        pi = FindObjectOfType<PlayerInteract>();
        p = FindObjectOfType<Parrier>();
        ls = FindObjectOfType<LevelSystem>();

        sprite = GetComponent<SpriteRenderer>();

        mb.moneyText.text = mb.Money.ToString();
        parryText.text = p.pCount.ToString();

        if (DEBUG)
        {
            cityUnlocked = true;
            beachUnlocked = true;
            royalUnlocked = true;
            caveUnlocked = true;
            wrongNeighborhoodUnlocked = true;
            coldUnlocked = true;
            raidEXTunlocked = true;
            raidINTunlocked = true;
            maxHealth = 45;
            health = 45;
            mb.GetMoney(44000);
        }

        p.maxPcount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(999);
        }

        Heal();
        HealAndSpeed();
        HealAndSpeedAndAttack();

        if (ms.menuOpen)
        {
            canShoot = false;
        }
        

        if (cityUnlocked)
        {
            cityText.text = "Olive City";
        }

        if (beachUnlocked)
        {
            beachText.text = "Shoregrove Town";
        }

        if (royalUnlocked)
        {
            royalText.text = "Oceangrand City";
        }

        if (caveUnlocked)
        {
            caveText.text = "Spooky Scary Skeletown";
        }

        if (wrongNeighborhoodUnlocked)
        {
            wrongNText.text = "Wrong Neighborhood";
        }

        if (coldUnlocked)
        {
            coldText.text = "Foreverflu Village";
        }

        if (raidEXTunlocked)
        {
            cheriEXTTEXT.text = "Mon Cheri Exterior";
        }

        if (raidINTunlocked)
        {
            cheriINTTEXT.text = "Final Room";
        }
        levelText.text = ls.level.ToString();

        if (INSTARTSCREEN || cuts.inCutscene)
        {
            rb.isKinematic = true;
            canShoot = false;
            
            
        }
        position = player.transform.position;
        if (!suitcase.CANCREDIT)
        {


            if (health <= 0)
            {
                dead = true;
            }

            if (teleportin)
            {

                canTakeDamage = false;
            }

            if (pi.ratting)
            {
                canTakeDamage = false;
            }

            if (health > 0)
            {
                dead = false;
                if (!GRANDERLOCK)
                {
                    if (!grandLock)
                    {
                        if (!me1Cheri.dead)
                        {
                            if (!teleportin)
                            {
                                if (!pi.ratting)
                                {
                                    canTakeDamage = true;
                                }
                                }

                            }

                    }
                }
            }
            if (me1Cheri.dead)
            {
                canTakeDamage = false;
            }
            if (cuts.inCutscene == true)
            {
                GRANDERLOCK = true;
            }

            if (cuts2.inCutscene == true)
            {
                GRANDERLOCK = true;
            }

            if (generalTutorial)
            {
                if (!genTutorialClear)
                {
                    GenTutorial1();
                    genTutorialClear = true;
                }
            }

            if (gtl)
            {
                if (!gtlx)
                {
                    GenTutorial2();
                    gtlx = true;
                }
            }

            if (gt2)
            {
                if (!gtlx2)
                {
                    GenTutorial3();
                    gtlx2 = true;
                }
            }

            if (p1)
            {
                if (!px)
                {
                    ParryTutorial12();
                    px = true;
                }
            }

            if (p2)
            {
                if (!px2)
                {
                    ParryTutorial13();
                    px2 = true;
                }
            }

            if (ls.level >= 3)
            {
                if (!chargeShotUnlocked)
                {
                    ChargeShotUnlock();
                    chargeShotUnlocked = true;
                }
            }

            if (ls.level >= 6)
            {
                if (p.parryUnlocked == false)
                {
                    ParryTutorial1();
                    p.parryUnlocked = true;
                }
            }

            if (ls.level >= 13)
            {
                if (!tripleShootUnlocked)
                {
                    TripleShotUnlock();
                    tripleShootUnlocked = true;
                }
            }

            if (t1)
            {
                Time.timeScale = 0;
                t1 = false;
            }

            if (t2)
            {
                Time.timeScale = 1;
                t2 = false;
            }
            if (dooring)
            {
                rb.velocity = Vector3.zero;
                change = Vector3.zero;
                animator.SetBool("moving", false);
                animator.SetBool("running", false);
                movement.x = 0;
                movement.y = 0;

            }

            if (mashPotatUnlocked)
            {
                if (Input.GetKeyDown(KeyCode.O))
                {
                    mashPotat.SetActive(true);
                    StartCoroutine(MashPotatofy());
                }
            }

            if (vbUnlocked)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    SoundManagerScript.PlaySound("vine");
                }
            }

            if (attackItemBuffed)
            {
                attackBuffing = true;

                //Cue Buff
                attackBuffLines.SetActive(true);

                if (attackBuffing)
                {
                    ss.currentStrength += attackItemBuff;
                    attackBuffing = false;
                }
            }

            if (speedItemBuffed)
            {
                speedBuffing = true;

                //Cue Buff
                speedBuffLines.SetActive(true);

                if (speedBuffing)
                {
                    movementSpeed += movementSpeedItemBuff;
                    speedBuffing = false;
                }
            }

            if (located)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;
                grandLock = true;
                isLocked = true;
                canMove = false;
                GRANDERLOCK = true;
            }

            if (laserKnockbacking)
            {
                rb.AddForce(-dir * knockBackForce2);
                knockBackForce2 -= knockbackMinuser;
                if (knockBackForce2 <= 0)
                {
                    knockBackForce2 = 0;
                }
            }
            if (knockbackDampening)
            {
                rb.AddForce(-dir * knockBackForce3);
            }

            if (!obtainedGlub)
            {
                glubGlub.SetActive(false);
            }

            if (obtainedGlub)
            {
                glubGlub.SetActive(true);
            }

            hpImage.fillAmount = health / maxHealth;

            if (hpEffectImage.fillAmount > hpImage.fillAmount)
            {
                hpEffectImage.fillAmount -= hurtSpeed;
            }
            else
            {
                hpEffectImage.fillAmount = hpImage.fillAmount;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            if (!dooring)
            {


                if (!GRANDERLOCK)
                {

                    if (bouncyGearUnlocked)
                    {
                        if (Input.GetKeyUp(KeyCode.Alpha1))
                        {
                            //PLAY SE HERE
                            Debug.Log("Shiftin");
                            bouncyGear = !bouncyGear;
                            SoundManagerScript.PlaySound("CARD");
                        }

                    }
                    if (!grandLock)
                    {
                        if (allowKnockback == false)
                        {

                            rb.velocity = Vector3.zero;
                        }
                        else
                        {
                            Knockback();
                        }



                        //if (pi.ratting)
                        // {
                        // canShoot = false;
                        //  canMove = false;
                        //  canTakeDamage = false;

                        //  }



                        //if(p.canParry == false)
                        //{
                        //canShoot = false;
                        //canCharge = false;
                        //canChargeShot = false;        
                        //}




                        if (!isLocked)
                        {
                            change = Vector3.zero;
                            change.x = Input.GetAxisRaw("Horizontal");
                            change.y = Input.GetAxisRaw("Vertical");
                            movement.x = Input.GetAxisRaw("Horizontal");
                            movement.y = Input.GetAxisRaw("Vertical");
                            Vector2 move = new Vector2(change.x, change.y);
                            UpdateAnimation();
                            cooldown += Time.deltaTime;
                            stoptimer = cooldown - ss2.currentCooldown;
                        }

                        //if (ws2.isGliding == true && !Input.GetKey(KeyCode.Mouse1))
                        //{
                        //    isRunning = true;
                        // }
                        else if (Input.GetKey(KeyCode.Mouse1))
                        {
                            isRunning = true;
                        }
                        else
                        {
                            isRunning = false;
                        }



                        if (pi.tutelAnim == true || pi.isShopping == true || pi.ratting == true || located || pi.talking)
                        {
                            GRANDERLOCK = true;
                            grandLock = true;
                            isLocked = true;
                            canMove = false;
                            canShoot = false;
                            canChargeShot = false;
                            shotCharge = 0f;
                            holdDownTime = 0f;
                        }
                        else
                        {
                            grandLock = false;
                            isLocked = false;
                            canMove = true;
                            canShoot = true;
                            canChargeShot = true;
                        }
                        if (!isLocked)
                        {

                            var ggStep = ggSpeed * Time.deltaTime;

                            if (movement.x > .01f)
                            {
                                dir = transform.right;
                                facingRight = true;
                                facingDown = false;
                                facingUp = false;
                                facingLeft = false;

                                meleePoint.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                glubGlub.transform.position = Vector3.MoveTowards(glubGlub.transform.position, ggRight.position, ggStep);
                                meleePoint2.transform.rotation = Quaternion.Euler(0f, 0f, 120f);
                                meleePoint3.transform.rotation = Quaternion.Euler(0f, 0f, 60f);
                                //waterWalker.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                //shadow.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                            }

                            if (movement.x < -.01f)
                            {
                                facingRight = false;
                                facingDown = false;
                                facingUp = false;
                                facingLeft = true;

                                dir = -transform.right;
                                meleePoint.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                                glubGlub.transform.position = Vector3.MoveTowards(glubGlub.transform.position, ggLeft.position, ggStep);
                                meleePoint2.transform.rotation = Quaternion.Euler(0f, 0f, 300f);
                                meleePoint3.transform.rotation = Quaternion.Euler(0f, 0f, 240f);
                                // waterWalker.transform.rotation = Quaternion.Euler(0f, 0f, 270f);

                                //shadow.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                            }

                            if (movement.y > .01f)
                            {
                                facingRight = false;
                                facingDown = false;
                                facingUp = true;
                                facingLeft = false;

                                dir = transform.up;
                                meleePoint.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                glubGlub.transform.position = Vector3.MoveTowards(glubGlub.transform.position, ggUp.position, ggStep);
                                meleePoint2.transform.rotation = Quaternion.Euler(0f, 0f, 210f);
                                meleePoint3.transform.rotation = Quaternion.Euler(0f, 0f, 150f);
                                // waterWalker.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                // shadow.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                            }

                            if (movement.y < -.01f)
                            {
                                facingRight = false;
                                facingDown = true;
                                facingUp = false;
                                facingLeft = false;

                                dir = -transform.up;
                                meleePoint.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                glubGlub.transform.position = Vector3.MoveTowards(glubGlub.transform.position, ggDown.position, ggStep);
                                meleePoint2.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
                                meleePoint3.transform.rotation = Quaternion.Euler(0f, 0f, 330f);
                                // waterWalker.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                // shadow.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                            }
                        }

                        if (canDmgknockback)
                        {

                            rb.AddForce(-dir * dmgKBforce);
                            if (rb.velocity.magnitude >= dmgKBforce)
                            {
                                //Bruh wtf was that boy.
                                rb.velocity = Vector3.zero; //If we go overboard, stop entirely.
                            }



                        }

                        if (noKnock)
                        {
                            rb.velocity = Vector3.zero;
                        }

                        if (hitstun && noKnock)
                        {
                            rb.velocity = Vector3.zero;
                        }



                        // Ranged Attack///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        if (!INSTARTSCREEN)
                        {


                            if (!cuts.inCutscene)
                            {
                                if (!cuts2.inCutscene)
                                {
                                    if (!cuts3.inCutscene)
                                    {




                                        if (p.canParry)
                                        {


                                            if (canShoot == true || dm.isTalking == false)
                                            {


                                                if ((attackSpeed - ss2.currentCooldown) <= cooldown)
                                                {
                                                    if (Input.GetButtonDown("Fire1") && dm.isTalking == false) // regular shot
                                                    {
                                                        if (p.instaCharge == true && p.pCount != 0 && !bouncyGear) //CHARGE SHOT
                                                        {
                                                           


                                                                StartCoroutine(FireStop());
                                                                ChargeShot();
                                                                p.pCount = p.pCount - 1;
                                                                //parryText.text = p.pCount.ToString();
                                                                if (p.pCount == 0)
                                                                {
                                                                    p.instaCharge = false;
                                                                }
                                                            
                                                        }
                                                        else
                                                        {
                                                            rb.velocity = Vector2.zero;
                                                            shotCharge = Time.time;
                                                            canMove = false;
                                                            GRANDERLOCK = true;
                                                            noKnock = true;
                                                            animator.SetBool("normalShot", true);
                                                            Invoke("SetBoolBack", .2f);

                                                            if (shoots)
                                                            {


                                                                if (bouncyGear == false)
                                                                {
                                                                    GameObject newBullet = Instantiate(bullet, meleePoint.position, meleePoint.rotation);
                                                                    newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -bulletForce));

                                                                    //IF LEVEL IS ABOVE...
                                                                    if (tripleShootUnlocked)
                                                                    {
                                                                        GameObject newBullet2 = Instantiate(bullet, meleePoint2.position, meleePoint2.rotation);
                                                                        newBullet2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -bulletForce));

                                                                        GameObject newBullet3 = Instantiate(bullet, meleePoint3.position, meleePoint3.rotation);
                                                                        newBullet3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -bulletForce));

                                                                    }
                                                                }

                                                                if (bouncyGear == true)
                                                                {
                                                                    GameObject bouncyBullet = Instantiate(bulletB, meleePoint.position, meleePoint.rotation);
                                                                    bouncyBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -bounceShotSpeed));

                                                                    //IF LEVEL IS ABOVE...
                                                                    if (tripleShootUnlocked)
                                                                    {
                                                                        GameObject bouncyBullet2 = Instantiate(bulletB, meleePoint2.position, meleePoint2.rotation);
                                                                        bouncyBullet2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -bounceShotSpeed));

                                                                        GameObject bouncyBullet3 = Instantiate(bulletB, meleePoint3.position, meleePoint3.rotation);
                                                                        bouncyBullet3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -bounceShotSpeed));

                                                                    }
                                                                }
                                                            }
                                                            SoundManagerScript.PlaySound("BubbleShoot");

                                                            cooldown = 0f;
                                                        }
                                                    }

                                                    if (canChargeShot == true && dm.isTalking == false && p.canParry == true) // charge shot


                                                        if (canCharge == true)
                                                        {
                                                            if (Input.GetButton("Fire1") && ready == false)
                                                            {
                                                                downTime = Time.time;
                                                                pressTime = downTime + countDown;
                                                                ready = true;
                                                            }

                                                            if (!Input.GetButton("Fire1"))
                                                            {
                                                                ready = false;
                                                            }


                                                            if (Input.GetButtonUp("Fire1") && chargeShotTime == false)// you charged, but not enough :(
                                                            {
                                                                ready = false;
                                                                downTime = 0;
                                                                pressTime = 0;
                                                                chargeShotTime = false;
                                                            }
                                                            if (Time.time >= pressTime && ready == true) // you charged, allow them to charge shot at will
                                                            {
                                                                Debug.Log("CHARGE SHOT HIIIIIIIIIIIIIIIIIIIIIIIIIII ");
                                                                chargeShotTime = true; // Lets you charge shot, hopefully
                                                            }


                                                            if (Input.GetButtonUp("Fire1") && chargeShotTime == true) //LASER BEAM>????
                                                            {
                                                                if (laserBeamUnlocked && p.pCount >= 5)
                                                                {
                                                                    canMove = false;
                                                                    animator.SetBool("chargeShot", true);
                                                                    StartCoroutine(KnockbackTurnOffer());
                                                                    SoundManagerScript.PlaySound("laser");
                                                                    if (facingDown)
                                                                    {
                                                                        laserD.SetActive(true);

                                                                        CameraShake.Instance.ShakeCamera(laserScreenshakeIntensity, laserScreenshakeTime);
                                                                        canShoot = false;

                                                                        StartCoroutine(TurnOffLaser());
                                                                    }
                                                                    if (facingLeft)
                                                                    {
                                                                        laserL.SetActive(true);

                                                                        CameraShake.Instance.ShakeCamera(laserScreenshakeIntensity, laserScreenshakeTime);
                                                                        canShoot = false;

                                                                        StartCoroutine(TurnOffLaser());
                                                                    }
                                                                    if (facingRight)
                                                                    {
                                                                        laserR.SetActive(true);

                                                                        CameraShake.Instance.ShakeCamera(laserScreenshakeIntensity, laserScreenshakeTime);
                                                                        canShoot = false;

                                                                        StartCoroutine(TurnOffLaser());
                                                                    }
                                                                    if (facingUp)
                                                                    {
                                                                        laserU.SetActive(true);

                                                                        CameraShake.Instance.ShakeCamera(laserScreenshakeIntensity, laserScreenshakeTime);
                                                                        StartCoroutine(TurnOffLaser());
                                                                    }


                                                                    p.pCount -= 5;
                                                                    ready = false;
                                                                    chargeShotTime = false;
                                                                    GRANDERLOCK = true;
                                                                    Debug.Log("LASER UNLEASHED");
                                                                }
                                                                else
                                                                {
                                                                    ChargeShot();
                                                                    ready = false;
                                                                }

                                                            }




                                                            //if (Input.GetButtonUp("Fire1"))
                                                            //{
                                                            // holdDownTime = Time.time - shotCharge;
                                                            // if (holdDownTime >= chargeShotCooldown)
                                                            // {
                                                            // canKnockback = true;
                                                            // holdDownTime = 0;
                                                            // shotCharge = 0;
                                                            // CameraShake.Instance.ShakeCamera(5f, .1f);
                                                            // SoundManagerScript.PlaySound("chargeBubbleSE");
                                                            //  SoundManagerScript.PlaySound("chargeShotSE");
                                                            // Debug.Log("Charge Shot time.");
                                                            //  canMove = false;
                                                            //  canChargeShot = false;
                                                            //  if (canKnockback == true)
                                                            //  {
                                                            //    rb.AddForce(-dir * 225);
                                                            //   rb.velocity = Vector2.zero;
                                                            //   }

                                                            // Invoke("SetBoolBack", .2f);
                                                            // Invoke("SetBoolBack2CS", 2f);
                                                            //  Invoke("SetBoolBack3KB", .2f);

                                                            //  GameObject newChargeBullet = Instantiate(chargeBullet, meleePoint.position, meleePoint.rotation);
                                                            //  newChargeBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -chargebulletForce));
                                                            //  cooldown = 0f;

                                                            // }


                                                            // }
                                                        }
                                                }



                                            }




                                            // Melee Attack

                                            // if (Input.GetButtonDown("Fire2"))
                                            //  {
                                            // Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, meleeRange);
                                            //  for (int i = 0; i < hitObjects.Length; i++)
                                            //   {
                                            //   if (!hitObjects[i].CompareTag("Player"))
                                            //   {
                                            //  hitObjects[1].SendMessage("TakeDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
                                            //  break;
                                            //  }
                                            //  }

                                            // }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }
            ///TUTORIAL SECTOR///
            ChargeShotClose();
            ParryTutorialClose1();
            ParryTutorialClose2();
            ParryTutorialClose3();
            TripleShotTutorialClose();
            HealAndSpeedAndAttackUnlockTutorialClose();
            HealAndSpeedTutorialClose();
            HealTutorialClose();
            GenTutorial1Close();
            GenTutorial1Close2();
            GenTutorial1Close3();
            BouncyBubbleUnlockTutorialClose();
            LaserTutorialClose();
            VineBoomUnlockTutorialClose();



        }
    }
    //public void ChargeShot()
    // {
    //   shotCharge += Time.deltaTime;
    // }


    void UpdateAnimation()
    {
        if (!INSTARTSCREEN)
        {

        
        if (!pi.talking)
        {
                if (!pi.ratting)
                {


                    if (!pi.isShopping)
                    {


                        if (!dooring)
                        {


                            if (!GRANDERLOCK)
                            {


                                if (!grandLock)
                                {


                                    if (canMove == false || pi.ratting || pi.isShopping)
                                    {
                                       


                                            animator.SetBool("moving", false);
                                        animator.SetBool("running", false);
                                    }
                                    if (canMove == true)
                                    {

                                        if (change != Vector3.zero)
                                        {
                                            animator.SetFloat("moveX", change.x);
                                            animator.SetFloat("moveY", change.y);
                                            animator.SetBool("moving", true);
                                            if (isRunning)
                                            {
                                                animator.SetBool("running", true);
                                            }
                                            else
                                            {
                                                animator.SetBool("running", false);
                                            }

                                        }
                                        else
                                        {
                                            animator.SetBool("moving", false);
                                            animator.SetBool("running", false);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

        }
            }
    }

    // Taking damage
    public void TakeDamage(int damage)
    {
        if (!suitcase.CANCREDIT)
        {


            if (!pi.talking)
            {


                if (!GRANDERLOCK)
                {


                    if (!grandLock)
                    {


                        if (canTakeDamage)
                        {


                            health -= damage;
                            SoundManagerScript.PlaySound("kokodmgSE");
                            fs.Flash();
                            CameraShake.Instance.ShakeCamera(5f, .1f);
                            if (p.pCount <= 3)
                            {


                                p.pCount =  0; //Reset the parry count to instantiate charge bubbles
                                               //parryText.text = p.pCount.ToString();
                            }
                            if(p.pCount > 0)
                            {
                                p.pCount -= 3;
                            }

                            if(p.pCount < 0)
                            {
                                p.pCount = 0;
                            }
                            if (health <= 0)
                            {
                                dead = true;
                                rb.mass = 999999999f;
                                canTakeDamage = false;
                                deadPos.position = gameObject.transform.position;
                                Debug.Log("Dead");
                                health = 0;
                                rb.velocity = Vector3.zero;
                                menuPanel.SetActive(true);
                                rb.velocity = Vector3.zero;
                                Time.timeScale = 0f;
                                redDeathScreen.SetActive(true);

                            }
                            healthText.text = health.ToString();
                            StartCoroutine(KokoDamageFaceSwitch());

                        }
                    }
                }
            }
        }
    }

    /// YOOOOO BAD VIDEO STUFF
    private void FixedUpdate()
    {
        if (!INSTARTSCREEN)
        {

          

            
        if (!cuts.inCutscene)
        {
                    if (!cuts2.inCutscene)
                    {

                        if (!cuts3.inCutscene)
                        {



                            if (!suitcase.CANCREDIT)
                            {


                                if (!pi.talking)
                                {
                                    if (!pi.ratting)
                                    {
                                        if (!pi.tutelAnim)
                                        {
                                            if (!pi.isShopping)
                                            {





                                                if (!dooring)
                                                {


                                                    if (!GRANDERLOCK)
                                                    {


                                                        if (!grandLock)
                                                        {


                                                            if (canMove == true)
                                                            {

                                                                rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);

                                                                if (Input.GetKey(KeyCode.Mouse1))
                                                                {
                                                                    if (speedBuffed)
                                                                    {
                                                                        movementSpeed = 6f + ss2.currentSpeed + movementSpeedBuff;
                                                                        isRunning = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        movementSpeed = 6f + ss2.currentSpeed;
                                                                        isRunning = true;
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    if (speedBuffed)
                                                                    {
                                                                        movementSpeed = 4f + movementSpeedBuff;
                                                                        isRunning = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        movementSpeed = 4f;
                                                                        isRunning = false;
                                                                    }

                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    
                }  }
        }
    }

    public void LaserUnlock()
    {
        if (!laserBeamUnlocked)
        {


            SoundManagerScript.PlaySound("upgrade");
            Debug.Log("unlocked laser!");
            laserBeamUnlocked = true;
            laserOpenable = true;
            if (laserOpenable)
            {

                laserTutorial.GetComponent<Animator>().SetBool("open", true);
                laserOpenable = false;
                laserClosable = true;
                Time.timeScale = 0;
            }
        }
        
        //Instantiate the tutorial thing;
    }

    public void LaserTutorialClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && laserClosable)
        {
            Time.timeScale = 1;
            laserClosable = false;
            laserTutorial.GetComponent<Animator>().SetBool("open", false);
            laserTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void HealUnlock()
    {
        if (!healUnlocked)
        {


            SoundManagerScript.PlaySound("upgrade");
            healUnlocked = true;
            healOpenable = true;

            Time.timeScale = 1;
            if (healOpenable)
            {
                healTutorial.GetComponent<Animator>().SetBool("open", true);
                healOpenable = false;
                healClosable = true;
                Time.timeScale = 0;
            }
        }

    }

    public void HealTutorialClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && healClosable)
        {
            Time.timeScale = 1;
            healClosable = false;
            healTutorial.GetComponent<Animator>().SetBool("open", false);
            healTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void HealAndSpeedUnlock()
    {
        if (!healAndSpeedUnlocked)
        {


            SoundManagerScript.PlaySound("upgrade");
            healAndSpeedUnlocked = true;
            healAndSpeedOpenable = true;
            Time.timeScale = 1;
            if (healAndSpeedOpenable)
            {
                healAndSpeedTutorial.GetComponent<Animator>().SetBool("open", true);
                healAndSpeedOpenable = false;
                healAndSpeedClosable = true;
                Time.timeScale = 0;
            }
        }
    }

    public void HealAndSpeedTutorialClose()
    {
        if(Input.GetKeyDown(KeyCode.X) && healAndSpeedClosable)
        {
            Time.timeScale = 1;
            healAndSpeedClosable = false;
            healAndSpeedTutorial.GetComponent<Animator>().SetBool("open", false);
            healAndSpeedTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void HealAndSpeedAndAttackUnlock()
    {
        SoundManagerScript.PlaySound("upgrade");
        HSAUnlocked = true;
        HSAOpenable = true;
        Time.timeScale = 1;
        if (HSAOpenable)
        {
            healAndSpeedAndAttackTutorial.GetComponent<Animator>().SetBool("open", true);
            HSAOpenable = false;
            HSAClosable = true;
            Time.timeScale = 0;
        }
    }

    public void HealAndSpeedAndAttackUnlockTutorialClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && HSAClosable)
        {
            Time.timeScale = 1;
            HSAClosable = false;
            healAndSpeedAndAttackTutorial.GetComponent<Animator>().SetBool("open", false);
            healAndSpeedAndAttackTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void BouncyBubbleUnlock()
    {
        SoundManagerScript.PlaySound("upgrade");
        bouncyGearUnlocked = true;
        bbOpenable = true;
        Time.timeScale = 1;
        if (bbOpenable)
        {
            bouncyBulletTutorial.GetComponent<Animator>().SetBool("open", true);
            bbOpenable = false;
            bbClosable = true;
            Time.timeScale = 0;
        }
    }

    public void BouncyBubbleUnlockTutorialClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && bbClosable)
        {
            Time.timeScale = 1;
            bbClosable = false;
            bouncyBulletTutorial.GetComponent<Animator>().SetBool("open", false);
            bouncyBulletTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void VineBoomUnlock()
    {
        SoundManagerScript.PlaySound("upgrade");
        vbUnlocked = true;
        vbOpenable = true;
        Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.X) && vbOpenable)
        {
            VineBoomTutorial.GetComponent<Animator>().SetBool("open", true);
            vbOpenable = false;
            vbClosable = true;
            Time.timeScale = 0;
        }
    }

    public void VineBoomUnlockTutorialClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && vbClosable)
        {
            Time.timeScale = 1;
            vbClosable = false;
            VineBoomTutorial.GetComponent<Animator>().SetBool("open", false);
            VineBoomTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void TripleShotUnlock()
    {
        if (!tripleShootUnlocked)
        {
            SoundManagerScript.PlaySound("upgrade");
            tripleShootUnlocked = true;
            tripleShotOpenable = true;
            Time.timeScale = 1;
            if (tripleShotOpenable)
            {
                tripleShotTutorial.GetComponent<Animator>().SetBool("open", true);
                tripleShotOpenable = false;
                tripleShotClosable = true;
                Time.timeScale = 0;
            }
        }
    }

    public void TripleShotTutorialClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && tripleShotClosable)
        {
            Time.timeScale = 1;
            tripleShotClosable = false;
            tripleShotTutorial.GetComponent<Animator>().SetBool("open", false);
            tripleShotTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void ChargeShotUnlock()
    {
        if (!csUnlocked)
        {


            SoundManagerScript.PlaySound("upgrade");
            csUnlocked = true;
            csOpenable = true;
            Time.timeScale = 1;
            if (csOpenable)
            {
                chargeShotTutorial.GetComponent<Animator>().SetBool("open", true);
                csOpenable = false;
                csClosable = true;
                Time.timeScale = 0;
            }
        }
    }

    public void ChargeShotClose()
    {
        if (Input.GetKeyDown(KeyCode.X) && csClosable)
        {
            Time.timeScale = 1;
            csClosable = false;
            chargeShotTutorial.GetComponent<Animator>().SetBool("open", false);
            chargeShotTutorial.GetComponent<Animator>().SetBool("close", true);
        }
    }

    public void GenTutorial1()
    {
        SoundManagerScript.PlaySound("upgrade");
        genTutUnlocked = true;
        genTutOpenable = true;
        Time.timeScale = 1;
        if (genTutOpenable)
        {
            genTut.GetComponent<Animator>().SetBool("open", true);
            genTutOpenable = false;
            genTutClosable = true;
            Time.timeScale = 0;
        }
    }

    public void GenTutorial1Close()
    {
        if (Input.GetKeyDown(KeyCode.X) && genTutClosable)
        {
            Debug.Log("yessrrrrrrr");
            Time.timeScale = 1;
            genTutClosable = false;
            genTut.GetComponent<Animator>().SetBool("open", false);
            genTut.GetComponent<Animator>().SetBool("close", true);
            gtl = true;
            


        }
    }

    public void GenTutorial2()
    {
        
        genTutUnlocked2 = true;
        genTutOpenable2 = true;
        Time.timeScale = 1;       
        if (genTutOpenable2)
        {
            genTut2.GetComponent<Animator>().SetBool("open", true);
            genTutOpenable2 = false;
            genTutClosable2 = true;
            Time.timeScale = 0;
        }
    }

    public void GenTutorial1Close2()
    {
        if (Input.GetKeyDown(KeyCode.X) && genTutClosable2)
        {
            Debug.Log("yessrrrrrrr");
            Time.timeScale = 1;
            genTutClosable2 = false;
            genTut2.GetComponent<Animator>().SetBool("open", false);
            genTut2.GetComponent<Animator>().SetBool("close", true);
            gt2 = true;



        }
    }

    public void GenTutorial3()
    {       
        genTutUnlocked3 = true;
        genTutOpenable3 = true;
        Time.timeScale = 1;
        if (genTutOpenable3)
        {
            genTut3.GetComponent<Animator>().SetBool("open", true);
            genTutOpenable3 = false;
            genTutClosable3 = true;
            Time.timeScale = 0;
        }
    }

    public void GenTutorial1Close3()
    {
        if (Input.GetKeyDown(KeyCode.X) && genTutClosable3)
        {
            Debug.Log("yessrrrrrrr");
            Time.timeScale = 1;
            genTutClosable3 = false;
            genTut3.GetComponent<Animator>().SetBool("open", false);
            genTut3.GetComponent<Animator>().SetBool("close", true);
            gt2 = false; 
            gtl = false;

        }
    }

    public void ParryTutorial1()
    {
        if (!pUnlocked)
        {


            SoundManagerScript.PlaySound("upgrade");
            pUnlocked = true;
            pOpenable = true;
            Time.timeScale = 1;
            if (pOpenable)
            {
                parryTutorial.GetComponent<Animator>().SetBool("open", true);
                pOpenable = false;
                pClosable = true;
                Time.timeScale = 0;
            }
        }
    }

    public void ParryTutorialClose1()
    {
        if (Input.GetKeyDown(KeyCode.X) && pClosable)
        {
            Debug.Log("yessrrrrrrr");
            Time.timeScale = 1;
            pClosable = false;
            parryTutorial.GetComponent<Animator>().SetBool("open", false);
            parryTutorial.GetComponent<Animator>().SetBool("close", true);
            p1 = true;


        }
    }

    public void ParryTutorial12()
    {
        if (!pUnlocked2)
        {


            pUnlocked2 = true;
            pOpenable2 = true;
            Time.timeScale = 1;
            if (pOpenable2)
            {
                parryTutorial2.GetComponent<Animator>().SetBool("open", true);
                pOpenable2 = false;
                pClosable2 = true;
                Time.timeScale = 0;
            }
        }
    }

    public void ParryTutorialClose2()
    {
        if (Input.GetKeyDown(KeyCode.X) && pClosable2)
        {

            Debug.Log("yessrrrrrrr");
            Time.timeScale = 1;
            pClosable2 = false;
            parryTutorial2.GetComponent<Animator>().SetBool("open", false);
            parryTutorial2.GetComponent<Animator>().SetBool("close", true);
            p2 = true;

        }
    }

    public void ParryTutorial13()
    {
        if (!pUnlocked3)
        {


            pUnlocked3 = true;
            pOpenable3 = true;
            Time.timeScale = 1;
            if (pOpenable3)
            {
                parryTutorial3.GetComponent<Animator>().SetBool("open", true);
                pOpenable3 = false;
                pClosable3 = true;
                Time.timeScale = 0;

            }
        }
    }

    public void ParryTutorialClose3()
    {
        if (Input.GetKeyDown(KeyCode.X) && pClosable3)
        {

            Debug.Log("yessrrrrrrr");
            Time.timeScale = 1;
            pClosable = false;
            parryTutorial3.GetComponent<Animator>().SetBool("open", false);
            parryTutorial3.GetComponent<Animator>().SetBool("close", true);
            p1 = false;
            p2 = false;
        }
    }




    public void StartButton()
    {
        // menuPanel.SetActive(false);
        //Time.timeScale = 1f;

        //Restart the game
        RespawnStuff();
        Debug.Log("CLICK");
    }

    public void QuitButton()
    {
        //This does not work in the editor only in the stand alone published version
        //So maybe get rid of this lol
        // make kokomi respawn at restaurant, lose half money
        //But actually for a quit button this works nvm
        Application.Quit();
        Debug.Log("Quit button has been pressed");
    }

    public void IncreaseHealth(int level)
    {
        maxHealth++;
        health = maxHealth;
        healthText.text = health.ToString();
    }



    private void SetBoolBack()
    {
        canMove = true;
        GRANDERLOCK = false;
        noKnock = false;
        animator.SetBool("normalShot", false);
    }

    private void SetBoolBack2CS()
    {
        canChargeShot = true;
        animator.SetBool("chargeShot", false);
    }

    private void SetBoolBack3KB()
    {
        canDmgknockback = false;
        allowKnockback = false;
        rb.velocity = Vector3.zero;
    }

    private void SetBoolBack4KB()
    {
        //Player just got hit and exited their knockback phase.
        canDmgknockback = false;
        allowKnockback = false;
        canMove = true;
        canShoot = true;
        shoots = true;
        hitstun = false;
        rb.velocity = Vector3.zero;
    }

    public void ChargeShot()
    {

        if (chargeShotUnlocked)
        {
            if (!bouncyGear)
            {



                if (canShoot)
                {


                    CameraShake.Instance.ShakeCamera(5f, .1f);


                    canKnockback = true;
                    if (canKnockback == true)
                    {
                        if (!p.instaCharge)
                        {


                            allowKnockback = true;
                            rb.AddForce(-dir * knockBackForce);
                            //rb.velocity = new Vector3(0, 0, 0);
                            rb.angularVelocity = 0;
                        }


                    }
                    SoundManagerScript.PlaySound("chargeBubbleSE");
                    SoundManagerScript.PlaySound("chargeShotSE");

                    ready = false;
                    canMove = false;
                    GRANDERLOCK = true;

                    animator.SetBool("chargeShot", true);
                    Invoke("SetBoolBack", .2f);
                    Invoke("SetBoolBack2CS", .2f);
                    //Invoke("SetBoolBack3KB", .2f);

                    cooldown = 0f;
                    chargeShotTime = false;
                    canChargeShot = false;


                    GameObject newChargeBullet = Instantiate(chargeBullet, meleePoint.position, meleePoint.rotation);
                    newChargeBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -chargebulletForce));
                }
            }
        }
    }

    public void Knockback()
    {
        rb.AddForce(-dir * knockBackForce);
                //rb.velocity = new Vector3(0, 0, 0);
                //rb.angularVelocity = 0;
        Invoke("SetBoolBack3KB", .2f);
    }

    public IEnumerator TurnOffLaser()
    {
        yield return new WaitForSeconds(0.5f);

        canShoot = true;
        GRANDERLOCK = false;
        canMove = true;
        animator.SetBool("chargeShot", false);

        laserD.GetComponent<KokoLaserScript>().canDamage = true;
        laserU.GetComponent<KokoLaserScript>().canDamage = true;
        laserL.GetComponent<KokoLaserScript>().canDamage = true;
        laserR.GetComponent<KokoLaserScript>().canDamage = true;

        laserD.SetActive(false);
        laserU.SetActive(false);
        laserL.SetActive(false);
        laserR.SetActive(false);

    }

    public IEnumerator KnockbackTurnOffer()
    {
        laserKnockbacking = true;
        yield return new WaitForSeconds(initialKnockbackTime);
        laserKnockbacking = false;
        knockBackForce2 = originKnockbackValue;
        //StartCoroutine(KnockbackDampener());
        
    }

    public IEnumerator KnockbackDampener()
    {
        knockbackDampening = true;
        yield return new WaitForSeconds(initialKnockbackDampenerTime);
        knockbackDampening = false;
    }

    public void Heal()
    {
        
        if (healUnlocked && !healAndSpeedUnlocked && !HSAUnlocked)
        {
            if (Input.GetKeyDown(KeyCode.Space) && p.pCount >= 5)
            {
                p.pCount -= 5;
                health += 5;
                SoundManagerScript.PlaySound("heal");
                healthText.text = health.ToString();
                StartCoroutine(FlashGreen());
            }
        }
    }

    public void HealAndSpeed()
    {
        
        if (healAndSpeedUnlocked && !HSAUnlocked)
        {
            if (Input.GetKeyDown(KeyCode.Space) && p.pCount >= 5)
            {
                p.pCount -= 5;
                health += 3;
                SoundManagerScript.PlaySound("heal");
                StartCoroutine(SpeedBuff());
                healthText.text = health.ToString();
                StartCoroutine(FlashGreen());
            }
        }
    }

    public void HealAndSpeedAndAttack()
    {
        
        if (HSAUnlocked)
        {
            if (Input.GetKeyDown(KeyCode.Space) && p.pCount >= 5)
            {
                p.pCount -= 5;
                health += 5;
                SoundManagerScript.PlaySound("heal");
                StartCoroutine(SpeedBuffAttackBuff());
                healthText.text = health.ToString();
                StartCoroutine(FlashGreen());
            }
        }
    }

    public IEnumerator FlashGreen()
    {
        sprite.color = Color.green;
        yield return new WaitForSeconds(0.125f);
        sprite.color = Color.white;
    }

    public IEnumerator SpeedBuff()
    {
        speedBuffFX.SetActive(true);
        speedBuffed = true;
        yield return new WaitForSeconds(buffTime);
        movementSpeed = movementSpeedOriginValue;
        speedBuffed = false;
        speedBuffFX.SetActive(false);
    }

    public IEnumerator SpeedBuffAttackBuff()
    {
        speedAttackBuffFX.SetActive(true);
        speedBuffed = true;
        dmgBuffed = true;
        yield return new WaitForSeconds(buffTime);
        movementSpeed = movementSpeedOriginValue;
        speedBuffed = false;
        dmgBuffed = false;
        speedAttackBuffFX.SetActive(false);
    }

    public IEnumerator MashPotatofy()
    {
        yield return new WaitForSeconds(5f);
        mashPotat.SetActive(false);
    }

    public IEnumerator AttackBuffPotion()
    {
        attackItemBuffed = true;
        yield return new WaitForSeconds(itemBuffTime);
        //Remove buff
        attackItemBuffed = false;
        ss.currentStrength -= attackItemBuff;
        attackBuffLines.SetActive(false);
    }

    public IEnumerator SpeedBuffPotion()
    {
        speedItemBuffed = true;
        
        yield return new WaitForSeconds(itemBuffTime);
        //Remove buff
        speedItemBuffed = false;
        movementSpeed -= movementSpeedItemBuff;
        speedBuffLines.SetActive(false);
    }

    public void BuffA()
    {
        StartCoroutine(AttackBuffPotion());
    }

    public void BuffS()
    {
        StartCoroutine(SpeedBuffPotion());
    }

    public IEnumerator KokoDamageFaceSwitch()
    {
        kokoNormalImage.SetActive(false);
        kokoDamageImage.SetActive(true);
        yield return new WaitForSeconds(faceSwitchTime);
        kokoNormalImage.SetActive(true);
        kokoDamageImage.SetActive(false);
    }

    public void HitKnockback()
    {
        rb.velocity = Vector3.zero;
        canDmgknockback = true;
        canMove = false;
        canShoot = false;
        shoots = false;
        hitstun = true;
        Invoke("SetBoolBack4KB", kbTime);
    }
    
    public void LoadingManagement()
    {
        mcDistance = Vector3.Distance(monCheriLoader.transform.position, player.transform.position);
        if(mcDistance <= 1000)
        {
            monCheriLoader.SetActive(true);
        }
        if(mcDistance > 1000)
        {
            monCheriLoader.SetActive(false);
        }

    }

    public void RespawnStuff()
    {
        deadPos = gameObject.transform;
        GRANDERLOCK = true;
        transform.position = deadPos.position;
        Time.timeScale = 1;
        GRANDERLOCK = true;
        canDmgknockback = false;
        rb.velocity = Vector3.zero;
        canKnockback = false;
        health = maxHealth;
        located = false;
        dooring = false;
        healthText.text = health.ToString();
        StartCoroutine(TeleportPlayer());
        menuPanel.SetActive(false);
        redDeathScreen.SetActive(false);  
        canRespawnEnemies = true;
        canTakeDamage = false;
        //Respawn all dead enemies
    }

    public IEnumerator TeleportPlayer()
    {
        fadeAnim.SetBool("toBlack", true);
        teleportin = true;
        deadPos = gameObject.transform;
        yield return new WaitForSeconds(1.2f);
        deadPos = gameObject.transform;
        rb.velocity = Vector3.zero;
        transform.position = respawnTransform.position;
        rb.velocity = Vector3.zero;
        canTakeDamage = true;
        StartCoroutine(Wait());
        yield return new WaitForSeconds(0.01f);
       


    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.6f); ////////
        
        fadeAnim.SetBool("toWhite", true);
        fadeAnim.SetBool("toBlack", false);
       
        yield return new WaitForSeconds(1);
        ToIdle();
    }

    public void ToIdle()
    {
        fadeAnim.SetBool("toWhite", false);
        GRANDERLOCK = false;
        teleportin = false;
        canTakeDamage = true;
        rb.mass = originMass;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tutorial"))
        {
            generalTutorial = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tutorial"))
        {
            generalTutorial = false;
        }
    }

    public void SaveToJson()
    {
        PlayerData data = new PlayerData();
        data.health = health;
        data.level = ls.level;

        data.position = new float[3];

        data.position[0] = position.x;
        data.position[1] = position.y;
        data.position[2] = position.z;
        data.csUnlocked = csUnlocked;
        data.tripleShotUnlocked = tripleShootUnlocked;
        data.pUnlocked1 = pUnlocked;
        data.pUnlocked2 = pUnlocked2;
        data.pUnlocked3 = pUnlocked3;

        data.gen1 = genTutUnlocked;
        data.gen2 = genTutUnlocked2;
        data.gen3 = genTutUnlocked3;

        data.cityTPU = cityUnlocked;
        data.beachTPPU = beachUnlocked;
        data.royalTPU = royalUnlocked;
        data.caveTPU = caveUnlocked;
        data.wrongNTPU = wrongNeighborhoodUnlocked;
        data.fFluTPU = coldUnlocked;
        data.cEXTTPU = raidEXTunlocked;
        data.cINTTPU = raidINTunlocked;

        data.shop1Unlocked = pi.d1;
        data.shop2Unlocked = pi.d2;
        data.shop3Unlocked = pi.d3;
        data.shop4Unlocked = pi.d4;
        data.shop5Unlocked = pi.d5;

        data.strength = ss.currentStrength;
        data.speed = ss2.currentSpeed;
        data.cd = ss2.currentCooldown;
        data.moneyMult = ss3.currentMoneyMult;
        data.xpMult = ss3.currentXpMult;
        data.maxPcount = ss4.currentPcount;
        data.dMult = ss4.currentDmult;
        data.slimeAttack = ss5.currentSlimeAttack;
        data.slimeCooldown = ss5.currentSlimeCooldown;

        data.money = mb.Money;
        data.rats = pi.ratCount;

        data.bouncyUnlocked = bouncyGearUnlocked;
        data.vineBoomUnlocked = vbUnlocked;
        data.laserUnlocked = laserBeamUnlocked;
        data.healUnlocked = healUnlocked;
        data.healAndSpeedUnlocked = healAndSpeedUnlocked;
        data.healAndSpeedAndAttackUnlocked = HSAUnlocked;
        data.doubleParryUnlocked = p.parryPointIncreaserUnlocked;
        data.tripleParryUnlocked = p.parryPointIncreaser2Unlocked;
        data.potatoUnlocked = mashPotatUnlocked;

        data.maxHP = maxHealth;
        data.glubglubUnlocked = obtainedGlub;

        data.ssPrice2 = ss.cost2;
        data.ss2Price1 = ss2.cost;
        data.ss2Price2 = ss2.cost2;
        data.ss3Price1 = ss3.cost;
        data.ss3Price2 = ss3.cost2;
        data.ss4Price1 = ss4.cost;
        data.ss4Price2 = ss4.cost2;
        data.ss5Price1 = ss5.cost;
        data.ss5Price2 = ss5.cost2;

        data.glubbed = ss5.glubbed;

        data.genTut1 = genTutOpenable;
        data.genTut2 = genTutOpenable2;
        data.genTut3 = genTutOpenable3;

        data.genTutUnlocked1 = genTutUnlocked;
        data.genTutUnlocked2 = genTutUnlocked2;
        data.genTutUnlocked3 = genTutUnlocked3;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/player.json", json); 

    }
  
    public void LoadFromJson()
    {
        if (File.Exists(Application.dataPath + "/player.json"))
        {
            t1 = false;
            t2 = true;
            INSTARTSCREEN = false;
            triggerBox.enabled = true;
            string json = File.ReadAllText(Application.dataPath + "/player.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            startScreen.SetActive(false);
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            csUnlocked = data.csUnlocked;
            tripleShootUnlocked = data.tripleShotUnlocked;

            genTutUnlocked = data.genTutUnlocked1;
            genTutUnlocked2 = data.genTutUnlocked2;
            genTutUnlocked3 = data.genTutUnlocked3;

            genTutOpenable = data.genTut1;
            genTutOpenable2 = data.genTut2;
            genTutOpenable3 = data.genTut3;

            maxHealth = data.maxHP;
            genTutUnlocked = data.gen1;
            genTutUnlocked2 = data.gen2;
            genTutUnlocked3 = data.gen3;


            ss.currentStrength = data.strength;
            ss2.currentSpeed = data.speed;
            ss2.currentCooldown = data.cd;
            ss3.currentMoneyMult = data.moneyMult;
            ss3.currentXpMult = data.xpMult;
            ss4.currentPcount = data.maxPcount;
            ss4.currentDmult = data.dMult;
            ss5.currentSlimeAttack = data.slimeAttack;
            ss5.currentSlimeCooldown = data.slimeCooldown;

            pUnlocked = data.pUnlocked1;
            pUnlocked2 = data.pUnlocked2;
            pUnlocked3 = data.pUnlocked3;

            cityUnlocked = data.cityTPU;
            beachUnlocked = data.beachTPPU;
            royalUnlocked = data.royalTPU;
            caveUnlocked = data.caveTPU;
            wrongNeighborhoodUnlocked = data.wrongNTPU;
            coldUnlocked = data.fFluTPU;
            raidEXTunlocked = data.cEXTTPU;
            raidINTunlocked = data.cINTTPU;

            pi.d1 = data.shop1Unlocked;
            pi.d2 = data.shop2Unlocked;
            pi.d3 = data.shop3Unlocked;
            pi.d4 = data.shop4Unlocked;
            pi.d5 = data.shop5Unlocked;


            bouncyGearUnlocked = data.bouncyUnlocked;
            vbUnlocked = data.vineBoomUnlocked;
            laserBeamUnlocked = data.laserUnlocked;
            healUnlocked = data.healUnlocked;
            healAndSpeedUnlocked = data.healAndSpeedUnlocked;
            HSAUnlocked = data.healAndSpeedAndAttackUnlocked;
            p.parryPointIncreaser2Unlocked = data.tripleParryUnlocked;
            p.parryPointIncreaserUnlocked = data.doubleParryUnlocked;
            mashPotatUnlocked = data.potatoUnlocked;
            obtainedGlub = data.glubglubUnlocked;

            ss.cost2 = data.ssPrice2;
            ss2.cost = data.ss2Price1;
            ss2.cost2 = data.ss2Price2;
            ss3.cost = data.ss3Price1;
            ss3.cost2 = data.ss3Price2;
            ss4.cost = data.ss4Price1;
            ss4.cost2 = data.ss4Price2;
            ss5.cost = data.ss5Price1;
            ss5.cost2 = data.ss5Price2;

            ss5.glubbed = data.glubbed;

            healthText.text = health.ToString();

            mb.Money = data.money;

            pi.ratCount = data.rats;

            mb.moneyText.text = data.money.ToString();

            gameObject.transform.position = position;

            health = maxHealth;
            healthText.text = health.ToString();

            ss.LoadCost();
            ss2.LoadCost();
            ss3.LoadCost();
            ss4.LoadCost();
            ss5.LoadCost();

            health = data.health;
            ls.level = data.level;

            
            Debug.Log("loadin");
        }
        else
        {
            Debug.Log("NO FILE FOUND");
        }
    }

    public void DELETEJSON()
    {
        if(File.Exists(Application.dataPath + "/player.json"))
        {
            File.Delete(Application.dataPath + "/player.json");
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startScreen.SetActive(false);
        t1 = false;
        t2 = true;
        Debug.Log("Scene Reset");
    }

    public void StartItUp()
    {
        t1 = false;
        t2 = true;
        INSTARTSCREEN = false;
        GRANDERLOCK = true;
        triggerBox.enabled = true;
        startScreen.SetActive(false);
        
    }

    public void LoadFade()
    {
        if (File.Exists(Application.dataPath + "/player.json"))
        {
            t1 = false;
            t2 = true;
            titleFadeObj.SetActive(true);
            titleFade.SetBool("load", true);
        }
        else
        {
            SoundManagerScript.PlaySound("BubblePopSE");
        }
    }

    public void SaveFade()
    {
        t1 = false;
        t2 = true;
        titleFadeObj.SetActive(true);
        titleFade.SetBool("new", true);
 
        Debug.Log("FADE");
    }

    public void BagelSpawn()
    {
        x = Random.Range(bx, bx2);
        y = Random.Range(by, by2);

        bagelSpawn = new Vector3(x, y, 0f);

        Instantiate(bagel, bagelSpawn, Quaternion.identity, startScreenTransform);
        SoundManagerScript.PlaySound("bagel");
    }

    public IEnumerator FireStop()
    {
        yield return new WaitForSeconds(fireWaitTime);
       
    }
}

