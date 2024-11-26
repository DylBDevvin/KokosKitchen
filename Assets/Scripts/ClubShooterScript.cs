using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubShooterScript : MonoBehaviour
{
    public GameObject gun;
    public float timer;
    public float gunSpawnTime;
    public float fireBulletTime;
    public float boomTime;
    public float despawnTime;
    public float bulletForce;
    public float angle;
    public bool canFire;
    public bool canDestroy;

    public Transform firingPoint;
    public GameObject projectile;    
    public GameObject player;
    public GameObject boom;

   
    // Start is called before the first frame update
    void Start()
    {
        gun.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetDir = player.transform.position - firingPoint.position;
        angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        firingPoint.rotation = Quaternion.RotateTowards(firingPoint.rotation, q, 180 * Time.deltaTime);


        timer += Time.deltaTime;

        if(timer >= gunSpawnTime) //Spawn Gun
        {
            gun.SetActive(true);
          //  SoundManagerScript.PlaySound("CLUBGUN");
        }

        if(timer >= fireBulletTime && !canDestroy) //Fire Bullet Prep
        {
            canFire = true;
        }

        if (canFire) //Actually fires the bullet only once.
        {
            //SoundManagerScript.PlaySound("CLUBSHOOT");
            GameObject newBullet = Instantiate(projectile, firingPoint.position, firingPoint.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletForce));
            canDestroy = true;
            canFire = false;
        }

        if(timer >= boomTime)
        {
            Debug.Log("boom!");
           //SoundManagerScript.PlaySound("CLUBDESPAWN");
            Instantiate(boom, transform.position, transform.rotation);
        }
        if(timer >= despawnTime && canDestroy) //Despawn
        {
            
            Destroy(gameObject);
        }


    }
}
