using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeShooter : MonoBehaviour
{
    public bool canFire;
    public GameObject projectile;
    public float bulletForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            Fire();
        }

       
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(projectile, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
        SoundManagerScript.PlaySound("SPADE");
        canFire = false;
        
    }

    public void OpenFire()
    {
        canFire = true;
    }

   

}
