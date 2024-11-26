using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public GameObject projectile;
    public float bulletForce;
    public float cooldown;
    public float firingRate;
    public bool canFire;
    public float firingTime;
    public float totalFiringTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FIRING
        if (canFire)
        {
            firingTime += Time.deltaTime;
            cooldown += Time.deltaTime;

            if (cooldown >= firingRate)
            {
                GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
                SoundManagerScript.PlaySound("DIAMOND");
                cooldown = 0;
            }
        }

        if(firingTime >= totalFiringTime)
        {
            canFire = false;
            firingTime = 0f;
        }

        if (!canFire)
        {
            cooldown = 0;
            firingTime = 0;
        }
    }

    public void DiamondFire()
    {
        canFire = true;
    }
}
