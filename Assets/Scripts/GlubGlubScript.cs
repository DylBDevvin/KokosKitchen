using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlubGlubScript : MonoBehaviour
{

    public GameObject glubBullet;

    public float glubForce;
    public float glubDmg;
    public float glubCooldown;
    public float glubCheck;
    public float angle;

    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public Sprite s10;

    public bool enemyInRange;

    public Transform target;
    public GameObject firingPoint;

    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!pm.dead)
        {
            if (!pm.cuts2.inCutscene)
            {

                if (!pm.cuts3.inCutscene)
                {


                    if (target != null)
                    {


                        if (enemyInRange)
                        {

                            Vector3 targetDir = target.position - firingPoint.transform.position;
                            angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                            firingPoint.transform.rotation = Quaternion.RotateTowards(firingPoint.transform.rotation, q, 180 * Time.deltaTime);
                            glubCheck += Time.deltaTime;
                            if (glubCheck >= glubCooldown)
                            {
                                GameObject newBullet = Instantiate(glubBullet, firingPoint.transform.position, firingPoint.transform.rotation);
                                newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, glubForce));
                                glubCheck = 0;
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Shooting AI"))
        {
            enemyInRange = true;
            target = other.transform;
        }            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Shooting AI"))
        {
            enemyInRange = false;
            target = null;
        }       
    }
}
