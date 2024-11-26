using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{

    public GameObject arrow;
    public GameObject firingPoint;

    public Animator anim;

    public float firingRate;
    public float cooldown;
    public float force;

    public bool canShoot;
    public GameObject player;
    public float distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= 50f)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
       
        if (canShoot)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= firingRate)
            {
                anim.SetBool("canShoot", true);
            }
        }
    }

    public void FireArrow()
    {
        GameObject newArrow = Instantiate(arrow, firingPoint.transform.position, firingPoint.transform.rotation);
        newArrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(force, 0f));
        cooldown = 0;
        anim.SetBool("canShoot", false);
    }
}
