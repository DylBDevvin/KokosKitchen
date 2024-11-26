using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class MeleeEnemy1 : MonoBehaviour
{
    public float speed = 3f;
    public float tempSpeed;
    [SerializeField] private int attackDamage = 2;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public Transform target;
    public int health;
    public int maxHealth;
    public SpriteRenderer sprite;
    public LevelSystem ls;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    public Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;
    public float distanceToTarget;
    public Transform player;
    public int expToGive;
    public bool canTakeDmg;
    public bool canDamage;
    public GameObject deathAnim;

    public ShopScript ss;


    public GameObject damageTextPrefab;
    public string textToDisplay;

    public HPSliderThing hpt;

    public GameObject itemDrop;
    public GameObject rareItemDrop;
    public int percentDrop;
    public bool knocked;

    public bool skeleton;
    public bool canMove = true;
    public bool canShoot = true;
    public float skellyDownTime;
    public float skellyJiggleTime;
    public Collider2D deadHitBox;
    public BoxCollider2D AliveHitBox;
    public float angle;
    public float lastAttackTime;
    public float attackDelay;
    public float attackRange;
    public GameObject projectile;
    public GameObject firingPoint;
    public Transform raycastPoint;
    public float bulletForce;
    public float skellyTossCount;
    public float skellyMaxToss;
    public bool skellyCooldown;
    public float skellyCooldownResetTime;
    public bool playerInRange;

    public Transform[] patrolPoints;
    public Transform currentPatrolPoint;
    public int currentPatrolIndex;

    public ParticleSystem p1;
    public ParticleSystem p2;

    public bool dead;

    public Vector3 spawnPoint;

    public bool chicken;
    public ChickenScript cs;
    public GameObject chickenDrop;

    public bool stealthSkelly;
    public bool canDie;
    public GameObject flashlight;
    public Transform dPos;
    public Transform uPos;
    public Transform lPos;
    public Transform rPos;

    public float kbackForce = 63000;
    public float speedMeleeKbackForce = 160000;
    public float kbTime = 0.29f;
    public float kbpTime = 0.42f;
    public bool sMelee;

    public bool knockedP;
    public float kbackForceP = 95000;
    public float speedMeleeKbackForceP = 300010;

    //VOIDER
    public float voidSpawnDistance;
    public float voidTimer;
    public float voidTimerMax;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;

    public int RNGNum;
    public bool portal;
    public bool portalEnem;

    public bool canSpawn = true;
    public int spawnTotal;
    public int spawnMax;

    public float portalEnemyDeathTime;
    public float maxDeathTime;
    public GameObject portalTarget;
    public bool raiden;
    public GameObject raidenSpadeFirePos;
    public GameObject raidenSpadeFirePos2;
    public GameObject raidenSpadeFirePos3;

    public float skellyStartSpeed;
    public float deadSpeed = 0;

    public bool cheri;
    public Transform cheriTransformForCam;
    public Transform playerTransformForCam;
    public GameObject blackener;
    public CinemachineVirtualCamera cvc;

    public GameObject pantCheri;
    public GameObject cheriChatBox;
    public Transform finalKokoTransform;
    public GameObject suitcase;

    public MusicController mc;
    public AudioClip nothing;
    public float dShake1;
    public float dShake2;
    public GameObject cutsceneGuy;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider;
    public BoxCollider2D portalBoxCollider;
    public bool canDrop = true;

    public float screenshakeS = 4f;
    public float screenshakeT = 0.1f;



    private void Start()
    {
       
        screenshakeT = 0.1f;
        canDamage = true;
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        skellyStartSpeed = speed;

        if (skeleton || stealthSkelly)
        {
            currentPatrolIndex = 0;
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
            target = currentPatrolPoint;
        }

        if (stealthSkelly)
        {
            canTakeDmg = false;
        }

        
        tempSpeed = speed;
        

        maxHealth = health;
        ss = FindObjectOfType<ShopScript>();
        ls = FindObjectOfType<LevelSystem>();
        canAttack = attackSpeed;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (chicken)
        {
            cs = GetComponent<ChickenScript>();
        }

        hpt.maxHp = maxHealth;
        hpt.hp = maxHealth;
        if (skeleton || stealthSkelly)
        {
            AliveHitBox.enabled = true;
            deadHitBox.enabled = false;
            anim.SetBool("isRunning", true);
        }

        spawnPoint = transform.position;


        if (portalEnem)
        {
            portalTarget = GameObject.FindGameObjectWithTag("Player");
        }

        if (skeleton)
        {
            canTakeDmg = true;
        }
    }


    private void Update()
    {

        if (player.GetComponent<PlayerMovement>().dead)
        {
            if (!cheri)
            {
                RESPAWN();
                StartCoroutine(RespawnWait());
            }
          
        }

        if (portalEnem)
        {
            if (!dead)
            {


                anim.SetBool("isRunning", true);
                canTakeDmg = true;
            }
        }

        if (portal)
        {
            if (!dead)
            {


                VoidSpawningStuff();
            }
        }
        if (skeleton)
        {
            if (!dead)
            {


                Vector3 targetDir = player.position - firingPoint.transform.position;
                angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                firingPoint.transform.rotation = Quaternion.RotateTowards(firingPoint.transform.rotation, q, 180 * Time.deltaTime);
            }
        }

        if (portalEnem)
        {

            portalEnemyDeathTime += Time.deltaTime;
            if (portalEnemyDeathTime >= maxDeathTime)
            {
                if (!dead)
                {


                    sprite.color = Color.white;
                    //gameObject.SetActive(false);
                    DeathEffect();
                    Destroy(gameObject);
                    Debug.Log("boom.");
                }

            }
        }

        if (skeleton)
        {
            if (!playerInRange)
            {
                if (!dead)
                {


                    Patrol();
                }
            }
        }

        if (stealthSkelly)
        {
            Patrol();
        }
        if (raiden)
        {
            Vector3 targetDir = player.position - raidenSpadeFirePos.transform.position;
            angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            raidenSpadeFirePos.transform.rotation = Quaternion.RotateTowards(raidenSpadeFirePos.transform.rotation, q, 180 * Time.deltaTime);
            raidenSpadeFirePos2.transform.rotation = Quaternion.RotateTowards(raidenSpadeFirePos2.transform.rotation, q, (180 * Time.deltaTime) + 30);
            raidenSpadeFirePos3.transform.rotation = Quaternion.RotateTowards(raidenSpadeFirePos3.transform.rotation, q, (180 * Time.deltaTime) + 330);
        }
        if (canMove == true)
        {
            
            distanceToTarget = Vector3.Distance(transform.position, player.position);
            if (skeleton || stealthSkelly)
            {
                dir = target.position - transform.position;
            }
            if (!skeleton && !stealthSkelly)
            {
                dir = player.position - transform.position;
            }
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            movement = dir;
            if (shouldRotate)
            {
                anim.SetFloat("X", dir.x);
                anim.SetFloat("Y", dir.y);

            }

            if (stealthSkelly) //FLASHLINGT VIEWING DIRECTION
            {
                if (dir.y < 0 && (dir.x > dir.y && dir.x < -dir.y))
                {
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 270); 
                    flashlight.transform.position = dPos.position;
                }
                if (dir.y > 0 && (dir.x > -dir.y && dir.x < dir.y))
                {
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 90); 
                    flashlight.transform.position = uPos.position;
                }

                if (dir.x < 0 && (dir.y > dir.x && dir.y < -dir.x))
                {
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180); 
                    flashlight.transform.position = lPos.position;
                }

                if (dir.x > 0 && (dir.y > -dir.x && dir.y < dir.x))
                {
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 0); 
                    flashlight.transform.position = rPos.position;

                }
            }

            if (playerInRange && !stealthSkelly && !portalEnem)
            {
                target = player;
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                canAttack += Time.deltaTime;

                if (skeleton)
                {                
                    if (Time.time > lastAttackTime + attackDelay && !skellyCooldown)
                    {
                        if (!dead)
                        {


                            if (playerInRange)
                            {
                                //Hit the player - fire the projectile

                                if (canShoot)
                                {


                                    GameObject newBullet = Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
                                    newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                    lastAttackTime = Time.time;
                                    skellyTossCount++;
                                    if (skellyTossCount >= skellyMaxToss)
                                    {
                                        skellyCooldown = true;
                                        StartCoroutine(SkellyCooldownReset());
                                    }
                                }
                            }
                        }
                    }
                }

            }

            if (portalEnem)
            {              
                portalTarget = GameObject.FindGameObjectWithTag("Player");
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, portalTarget.transform.position, step);
                canAttack += Time.deltaTime;
                dir = portalTarget.transform.position - transform.position;
                movement = dir;
                if (shouldRotate)
                {
                    anim.SetFloat("X", dir.x);
                    anim.SetFloat("Y", dir.y);

                }

            }

            if (knocked == false)
            {
                rb.velocity = Vector3.zero;
            }

            if (knocked)
            {
                canMove = false;
                if (!sMelee)
                {        
                    rb.AddForce(-dir * kbackForce);
                }
                if (sMelee)
                {
                    rb.AddForce(-dir * speedMeleeKbackForce);
                }
            }


            if (knockedP)
            {
                canMove = false;
                if (!sMelee)
                {
                    rb.AddForce(-dir * kbackForceP);
                }
                if (sMelee)
                {
                    rb.AddForce(-dir * speedMeleeKbackForceP);
                }
            }

            
        }

    }

    void Patrol()
    {
        if (!dead)
        {
            if(health > 0)
            {
                anim.SetBool("isRunning", true);
            }
        }
        target = currentPatrolPoint;
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint.position, step);

        if(Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.2f)
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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!portal)
        {


            if (!stealthSkelly)
            {


                if (other.gameObject.tag == "Player" && other.gameObject.tag != "parry")
                {
                    if (canDamage)
                    {


                        if (attackSpeed <= canAttack)
                        {
                            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
                            canAttack = 0f;
                            if (!other.gameObject.GetComponent<PlayerMovement>().noKnock)
                            {
                                other.gameObject.GetComponent<PlayerMovement>().HitKnockback();
                            }
                        }
                    }


                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!stealthSkelly)
        {



            if (other.gameObject.tag == "Player" && other.gameObject.tag != "parry")
            {
                canTakeDmg = true;
                target = other.transform;
                playerInRange = true;
                Debug.Log(target);
                anim.SetBool("isRunning", true);

            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!skeleton || !stealthSkelly)
        {
            if (other.gameObject.tag == "Player" && distanceToTarget >= 6)
            {
                if (!cheri)
                {


                    canTakeDmg = false;
                    target = null;
                    playerInRange = false;
                    if (!skeleton || stealthSkelly)
                    {
                        anim.SetBool("isRunning", false);
                    }
                }
            }
        }

        if (skeleton)
        {
            if (other.gameObject.tag == "Player" && distanceToTarget >= 4.5)
            {
                canTakeDmg = false;
                target = currentPatrolPoint;
                playerInRange = false;
                if (!skeleton)
                {
                    anim.SetBool("isRunning", true);
                }

            }
        }
    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    // if (collision.gameObject.tag == "KokoBullet")
    // {
    //     Physics2D.IgnoreCollision( collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //   }
    //  }



    public void TakeDamage(int damage)
    {
        if (canTakeDmg == true)
        {
            health -= damage;
            Knockback();
            StartCoroutine(FlashRed());
            CameraShake.Instance.ShakeCamera(screenshakeS, screenshakeT);
            SoundManagerScript.PlaySound("BubblePopSE");
            GameObject DamageTextInstance = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(damage.ToString());

            hpt.hp -= damage;
            if (chicken)
            {
                cs.hit = true;
            }

            Debug.Log("hit!");

            if(!skeleton)
            if (health <= 0)
            {
                   
                    if (!cheri)
                    {
                        dead = true;



                        if (chicken)
                        {
                            if (canDrop)
                            {


                                Instantiate(chickenDrop, transform.position, transform.rotation);
                                canDrop = false;
                            }
                        }
                        percentDrop = Random.Range(1, 100);

                        DeathEffect();
                        if (portalEnem)
                        {
                            Destroy(gameObject);
                        }
                        if (rareItemDrop && itemDrop != null)
                        {
                            if (canDrop)
                            {



                                if (percentDrop >= 90)
                                {
                                    Instantiate(rareItemDrop, transform.position, transform.rotation);
                                }
                                else if (percentDrop < 90 && percentDrop >= 40)
                                {
                                    Instantiate(itemDrop, transform.position, transform.rotation);
                                }
                                canDrop = false;
                            }
                        }

                        ls.GainExperienceFlatRate(expToGive);
                        sprite.color = Color.white;
                        DeathRemover();
                        player.GetComponent<PlayerMovement>().canTakeDamage = false;

                    }

                    if (cheri)
                    {
                        anim.SetBool("dead", true);
                        mc.CrossFade(nothing);
                        blackener.SetActive(true);
                        player.GetComponent<PlayerMovement>().GRANDERLOCK = true;
                        cvc.Follow = cheriTransformForCam;

                        dead = true;
                        
                    }
            }

            

            if (skeleton)
            {
                if(health <= 0)
                {
                    speed = deadSpeed;
                    canShoot = false;
                    canMove = false;
                    anim.SetBool("isRunning", false);
                    anim.SetBool("canDrop", true);
                    StartCoroutine(SkellyWait());
                    //Drop the head and make it jiggle or summ
                }

                if(health > 0)
                {
                    speed = skellyStartSpeed;
                }
            }

        }
    }

    public void DeathEffect()
    {
        if (deathAnim != null)
        {
            GameObject effect = Instantiate(deathAnim, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("deathSE");
            Destroy(effect, .8f);
        }

    }

    public void DeathEffect2()
    {
        if (deathAnim != null)
        {          
            SoundManagerScript.PlaySound("deathSE");
        }

    }

    public void ZapDeathEffect()
    {
        if (deathAnim != null)
        {
            GameObject effect = Instantiate(deathAnim, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("deathSE");
            percentDrop = Random.Range(1, 100);
            if (rareItemDrop && itemDrop != null)
            {


                if (percentDrop >= 90)
                {
                    Instantiate(rareItemDrop, transform.position, transform.rotation);
                }
                else if (percentDrop < 90 && percentDrop >= 40)
                {
                    Instantiate(itemDrop, transform.position, transform.rotation);
                }
            }
            GameObject DamageTextInstance = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("9999");
            ls.GainExperienceFlatRate(expToGive);
            Destroy(effect, .8f);
            DeathRemover(); 

        }


    }

    public IEnumerator SkellyCooldownReset()
    {
        yield return new WaitForSeconds(skellyCooldownResetTime);
        skellyCooldown = false;
        skellyTossCount = 0;
    }
    public void SkellyDeather()
    {
        Invoke("SkellyDeath", 0.05f);
    }
    public void SkellyDeath()
    {
        if (!stealthSkelly)
        {
            dead = true;
            DeathEffect();
            percentDrop = Random.Range(1, 100);
            health = 0;
            hpt.dead = true;
            hpt.bg.SetActive(false);
            hpt.hpFill.SetActive(false);
            hpt.effect.SetActive(false);
            if (percentDrop >= 90)
            {
                Instantiate(rareItemDrop, transform.position, transform.rotation);
            }
            else if (percentDrop < 90 && percentDrop >= 40)
            {
                Instantiate(itemDrop, transform.position, transform.rotation);
            }
            ls.GainExperienceFlatRate(expToGive);
            sprite.color = Color.white;
            DeathRemover();
            

        }
    }

    public IEnumerator SkellyWait()
    {
        AliveHitBox.size = new Vector3(1f, 1.2f, 1);
        

        yield return new WaitForSeconds(skellyDownTime);
        anim.SetBool("isRunning", false);
        anim.SetBool("canJiggle", true);
        anim.SetBool("canDrop", false);
        StartCoroutine(JiggleSkelly());
    }

    public IEnumerator JiggleSkelly()
    {
        yield return new WaitForSeconds(skellyJiggleTime);
        anim.SetBool("canJiggle", false);
        anim.SetBool("isRunning", true);
        health = maxHealth;
        hpt.hp = maxHealth;
        canMove = true;
        canShoot = true;
        speed = skellyStartSpeed;
        AliveHitBox.size = new Vector3(1, 2, 1);

        
        

    }

    public void Flasher()
    {
        StartCoroutine(FlashRed());
    }
    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.125f);
        sprite.color = Color.white;
    }

    public void Knockback()
    {
        knocked = true;
        Invoke("KBStop", kbTime);
        Debug.Log("knockbacking");
    }

    public void KnockBackParry()
    {
        knockedP = true;
        Invoke("KBPStop", kbpTime);
        Debug.Log("knockbacking for parry");
    }

    public IEnumerator KnockStop()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector3.zero;
    }

    public void KBStop()
    {
        rb.velocity = Vector3.zero;
        knocked = false;
        if (playerInRange)
        {
            canMove = true;
        }    
    }

    public void KBPStop()
    {
        rb.velocity = Vector3.zero;
        knockedP = false;
        if (playerInRange)
        {
            canMove = true;
        }
    }

    public void PlayParticles()
    {
        SoundManagerScript.PlaySound("skellyDrop");
        p1.Play();
        p2.Play();

    }

    public void ResetStats()
    {
        transform.position = spawnPoint;
        health = maxHealth;
        hpt.maxHp = maxHealth;
        hpt.hp = maxHealth;
        boxCollider.enabled = true;
        anim.enabled = true;
        canDamage = true;
        sr.enabled = true;

        if (!skeleton)
        {


            anim.SetBool("isRunning", false);
        }
        if (skeleton)
        {
            anim.SetBool("isRunning", true);
        }
    }

    public void RESPAWN()
    {
        canDrop = true;
        canDamage = true;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
        anim.enabled = true;
        if (!stealthSkelly)
        {
            sprite.color = Color.white;
        }
        if (!skeleton)
        {


            anim.SetBool("isRunning", false);
        }
        if (skeleton)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("canDrop", false);
            anim.SetBool("canJiggle", false);
        }
        sr.enabled = true;
        transform.position = spawnPoint;
        health = maxHealth;
        hpt.maxHp = maxHealth;
        hpt.hp = maxHealth;
        playerInRange = false;
        canMove = true;
        dead = false;
        if (portal)
        {
            canMove = false;
            canSpawn = true;
            portalBoxCollider.enabled = true;
        }

        
    }

    public void VoidSpawningStuff()
    {
       
            if (GetComponentInChildren<BlackHoleSpawnerScript>().playerInRange) //If player is in range, start spawning enemies from black hole. (hopefully.)
            {
                voidTimer += Time.deltaTime;
                if (voidTimer >= voidTimerMax)
                {
                    //Spawn a guy
                    RNGNum = Random.Range(1, 10);
                    spawnTotal += 1;
                    if (RNGNum <= 3 && canSpawn)
                    {
                        Instantiate(enemy1, spawn1.transform);
                        SoundManagerScript.PlaySound("spawn");
                        voidTimer = 0;
                        
                    }
                    if (RNGNum >= 4 && RNGNum <= 6 && canSpawn)
                    {
                        Instantiate(enemy2, spawn2.transform);
                        voidTimer = 0;
                        
                    }
                    if (RNGNum >= 7 && RNGNum <= 9 && canSpawn)
                    {
                        Instantiate(enemy3, spawn3.transform);
                        voidTimer = 0;
                        
                    }
                    RNGNum = 0;
                }
            }
        
        
    }

    public void Screenshake()
    {
        CameraShake.Instance.ShakeCamera(dShake1, dShake2);
        SoundManagerScript.PlaySound("cheri");
        //Sound Effect
    }

    public void DieCheri()
    {
        ls.GainExperienceFlatRate(expToGive);
        blackener.SetActive(false);
        cutsceneGuy.SetActive(true);
        cheriChatBox.SetActive(true);
        cvc.Follow = playerTransformForCam;
        DeathEffect2();
        pantCheri.SetActive(true);
        suitcase.SetActive(true);
        player.transform.position = finalKokoTransform.position;
        player.GetComponent<Animator>().SetFloat("moveY", 1f);
        player.GetComponent<Animator>().SetFloat("moveX", 0f);
        gameObject.SetActive(false);
    }

    public void DeathRemover()
    {
        canDamage = false;
        anim.enabled = false;
        sr.enabled = false;
       // playerInRange = false;
        boxCollider.enabled = false;
        canMove = false;
        canShoot = false;
        if (skeleton)
        {
            speed = skellyStartSpeed;
        }
        if (!skeleton)
        {
            anim.SetBool("isRunning", false);
        }
      
        if (portal)
        {
            canSpawn = false;
            portalBoxCollider.enabled = false;
        }
      
    }

    public IEnumerator RespawnWait()
    {
        yield return new WaitForSeconds(4f);
        RESPAWN();
    }

}



   


