using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatrollingAI : MonoBehaviour
{

    public SpriteRenderer sprite;

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    public float bulletForce;

    public GameObject projectile;

    public float awarenessRange;
    public float distanceToTarget;
    public Transform raycastPoint;
    public Transform firingPoint;
    public int maxHealth;
    public int health;
    public LevelSystem ls;
    public FlashScript fs;
    public bool TakingDmg = false;
    public float lockPos;
    public GameObject deathAnim;


    public GameObject damageTextPrefab;
    public string textToDisplay;

    public GameObject numD;



    public HPSliderThing hpt;

    public GameObject itemDrop;
    public GameObject rareItemDrop;
    public int percentDrop;

    public bool playerInRange;

    public Vector3 targetDir;
    public bool dead;
    public Vector3 spawnPoint;

    public float expToGive = 20;

    public bool creamCheese;
    public bool cc2;

    public bool nrBallin;
    public bool rBallin;

    public GameObject projectile2;
    public GameObject projectile3;
    public GameObject firingPoint2;
    public GameObject firingPoint3;

    public GameObject cream;
    public int RNG;
    public bool zapped;

    public bool tripled;

    public SpriteRenderer sr;
    public BoxCollider2D boxCollider;
    public Animator anim;
    public GameObject player;
    public bool canDrop = true;

    public float screenshakeS = 4f;
    public float screenshakeT = 0.1f;

    // public HealthBarBehavior Healthbar;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        screenshakeT = 0.1f;
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        ls = FindObjectOfType<LevelSystem>();
        fs = FindObjectOfType<FlashScript>();
        //hpt = FindObjectOfType<HPSliderThing>();

        hpt.maxHp = maxHealth;
        hpt.hp = maxHealth;

        spawnPoint = transform.position;
        if (!creamCheese)
        {


            sr = GetComponentInParent<SpriteRenderer>();
            anim = GetComponentInParent<Animator>();
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().dead)
        {
            if (!creamCheese)
            {
                Respawn();
            }


        }

        if (creamCheese)
        {
            if (player.GetComponent<PlayerMovement>().dead)
            {
                health = maxHealth;
            }
        }
        targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        if (!creamCheese)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180 * Time.deltaTime);
        }
        if (creamCheese)
        {
            firingPoint.transform.rotation = Quaternion.RotateTowards(firingPoint.transform.rotation, q, 180 * Time.deltaTime);
            if (tripled)
            {
                firingPoint2.transform.rotation = Quaternion.RotateTowards(firingPoint2.transform.rotation, q, (180 * Time.deltaTime) + 30);
                firingPoint3.transform.rotation = Quaternion.RotateTowards(firingPoint2.transform.rotation, q, (180 * Time.deltaTime) + 330);
            }
            if (distanceToTarget >= 15f)
            {
                nrBallin = true;
                rBallin = false;
            }
            else
            {
                rBallin = true;
                nrBallin = false;
            }
        }


        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        //Check the distance to the player
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > awarenessRange)
        {
            if (!dead)
            {


                Patrol();
            }
        }

        // if the player is in enemys awarenessRange - Chase
        if (distanceToTarget < awarenessRange && distanceToTarget > attackRange)
        {
            //Chase();
        }

        if (distanceToTarget < attackRange)
        {
            if (!dead)
            {


                playerInRange = true;
                Attack();
            }
        }






        void Patrol()
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            //Check to see if we have reached the patrol point
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
            {
                //Check to see if we have any more patrol points, else go back to beginning
                //We have reached the patrol point, get the next one
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

            //Turn to face current patrol point

        }

        // void Chase()
        {
            //Get the distance to the target and check to see if it is close enough to chase
            // float distanceToTarget = Vector3.Distance(transform.position, target.position);

            //Start chasing the target, turn and move towards target
            Vector3 targetDir = target.position - transform.position;
            //float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f; // to offset the angle in which the dudes spider in the video is drawn
            //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }


        void Attack()
        {
            //Check to see if the player is within attack range for ranged attack

            //Turn towards the target

            if (!dead)
            {


                if (Time.time > lastAttackTime + attackDelay)
                {
                    //Raycast to see if we have line of sight to the target
                    //RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, transform.up, attackRange);
                    //Debug.Log(hit);
                    //Check to see if we hit anything and what it was
                    if (playerInRange)
                    {
                        //Hit the player - fire the projectile
                        Debug.Log("hi");
                        if (!creamCheese)
                        {
                            GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
                            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                            if (tripled)
                            {
                                GameObject newBulletT2 = Instantiate(projectile, firingPoint2.transform.position, firingPoint2.transform.rotation);
                                GameObject newBulletT3 = Instantiate(projectile, firingPoint3.transform.position, firingPoint3.transform.rotation);
                                newBulletT2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                newBulletT3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));

                            }


                            lastAttackTime = Time.time;
                        }
                        if (creamCheese)
                        {
                            if (nrBallin)
                            {
                                GameObject newBullet2 = Instantiate(projectile2, firingPoint.transform.position, firingPoint.transform.rotation);
                                newBullet2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                lastAttackTime = Time.time;
                            }
                            if (rBallin)
                            {
                                RNG = Random.Range(0, 12);

                                if (!cc2)
                                {
                                    if (RNG <= 7)
                                    {
                                        GameObject newBullet = Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
                                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        lastAttackTime = Time.time;
                                    }
                                    if (RNG >= 8 && RNG <= 12)
                                    {
                                        GameObject newBullet3 = Instantiate(projectile3, firingPoint.transform.position, firingPoint.transform.rotation);
                                        newBullet3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        lastAttackTime = Time.time;
                                    }
                                }
                                if (cc2)
                                {
                                    if (RNG <= 4)
                                    {
                                        GameObject newBullet = Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
                                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        lastAttackTime = Time.time;
                                    }
                                    if (RNG >= 5 && RNG <= 8)
                                    {
                                        GameObject newBullet3 = Instantiate(projectile3, firingPoint.transform.position, firingPoint.transform.rotation);
                                        newBullet3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        lastAttackTime = Time.time;
                                    }

                                    if (RNG >= 9)
                                    {
                                        GameObject newBullet = Instantiate(projectile, firingPoint.transform.position, firingPoint.transform.rotation);
                                        GameObject newBullet3 = Instantiate(projectile3, firingPoint2.transform.position, firingPoint2.transform.rotation);
                                        GameObject newBullet4 = Instantiate(projectile3, firingPoint3.transform.position, firingPoint3.transform.rotation);
                                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        newBullet3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        newBullet4.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                                        lastAttackTime = Time.time;

                                    }
                                }
                            }

                        }

                    }
                }



            }
        }



    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(FlashRed());
        CameraShake.Instance.ShakeCamera(screenshakeS, screenshakeT);
        SoundManagerScript.PlaySound("BubblePopSE");
        GameObject DamageTextInstance = Instantiate(damageTextPrefab, numD.transform.position, Quaternion.identity);
        DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(damage.ToString());

        hpt.hp -= damage;

        Debug.Log("hit!");

        if (health <= 0)
        {
            dead = true;
            percentDrop = Random.Range(1, 100);
            DeathEffect();
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

            ls.GainExperienceFlatRate(expToGive);
            sprite.color = Color.white;
            if (!creamCheese)
            {
                DeathRemover();
            }
            if (creamCheese)
            {
                gameObject.SetActive(false);
                //cream.SetActive(false);
                Debug.Log("dead cheese");
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
            zapped = true;
            this.transform.parent.gameObject.SetActive(false);

        }


    }


    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.125f);
        sprite.color = Color.white;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);

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
        }
    }

    public void ResetStats()
    {
        transform.position = spawnPoint;
        health = maxHealth;
        hpt.maxHp = maxHealth;
        hpt.hp = maxHealth;
        zapped = false;

        anim.enabled = true;
        sr.enabled = true;
        boxCollider.enabled = true;
    }


    public void Respawn()
    {
        canDrop = true;
        this.transform.parent.gameObject.SetActive(true);
        sprite.color = Color.white;
        gameObject.SetActive(true);

        transform.position = spawnPoint;
        health = maxHealth;
        hpt.maxHp = maxHealth;
        hpt.hp = maxHealth;
        zapped = false;

        anim.enabled = true;
        sr.enabled = true;
        boxCollider.enabled = true;
        dead = false;
    }

    public void DeathRemover()
    {
        anim.enabled = false;
        sr.enabled = false;
        playerInRange = false;
        boxCollider.enabled = false;
        dead = true;



    }

   

}
