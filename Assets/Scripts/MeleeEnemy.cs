using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
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
    public int health;
    public LevelSystem ls;
    public FlashScript fs;
    public bool TakingDmg = false;



    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        ls = FindObjectOfType<LevelSystem>();
        fs = FindObjectOfType<FlashScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check the distance to the player
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > awarenessRange)
        {
            //Patrol();

        }

        // if the player is in enemys awarenessRange - Chase
        if (distanceToTarget < awarenessRange && distanceToTarget > attackRange)
        {
           // Chase();
        }

        if (distanceToTarget < attackRange)
        {
            Attack();
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
            Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
            float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f; // to offset the angle in which the dudes spider in the video is drawn

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
        }

        void Chase()
        {
            //Get the distance to the target and check to see if it is close enough to chase
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            //Start chasing the target, turn and move towards target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f; // to offset the angle in which the dudes spider in the video is drawn
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }


        void Attack()
        {

            //Check the distance between spider and player to see if the player is close enough to attack


            //Check to see if enough time has passed since we last attacked
            if (Time.time > lastAttackTime + attackDelay)
            {
                target.SendMessage("TakeDamage", damage);
                /////Record the time we attacked
                lastAttackTime = Time.time;
            }


            //Check to see if the player is within attack range for ranged attack

            //Turn towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180 * Time.deltaTime);

           // if (Time.time > lastAttackTime + attackDelay)
            {
                //Raycast to see if we have line of sight to the target
               // RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, transform.up, attackRange);
                //Check to see if we hit anything and what it was
              //  if (hit.transform == target)
                {
                    //Hit the player - fire the projectile
                  //  Debug.Log("hi");
                  //  GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
                  //  newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                   // lastAttackTime = Time.time;
                }
            }



        }



    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(FlashRed());
       
        
        CameraShake.Instance.ShakeCamera(3f, .02f);
        SoundManagerScript.PlaySound("BubblePopSE");
        Debug.Log("hit!");

        if (health <= 0)
        {
            ls.GainExperienceFlatRate(20);
            gameObject.SetActive(false);
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.125f);
        sprite.color = Color.white;
    }


}
