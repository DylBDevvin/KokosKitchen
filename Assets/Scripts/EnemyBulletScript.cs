using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    public int damage;
    public bool canDamage = true;
    public Rigidbody2D rb;

    public bool bouncy;
    public int bounces;
    public int maxBounces;

    public bool heart;
    public float time;
    public float maxTime;
    public GameObject boom;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    public void Update()
    {
        if (heart)
        {
            time += Time.deltaTime;
            if(time >= maxTime)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    public void Destroyer()
    {
        Invoke("DestroyBullet", 0.05f);
    }

    public void DestroyBullet()
    {
        rb.velocity = Vector3.zero;
        canDamage = false;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage)
        {

            if (other.CompareTag("KokoBullet"))
            {
                if (other.GetComponent<ArrowScript>().chargeShot)
                {
                    Destroy(gameObject);
                }
            }

            if (!other.CompareTag("KokoBullet"))
            {


                if (other.transform != this.transform && !other.CompareTag("interObject") && !bouncy)
                {
                    if (!other.CompareTag("Parrier"))
                    {
                        other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                       
                        Destroy(gameObject);
                    }
                }

                if (bouncy)
                {
                    if (!other.CompareTag("Parrier"))
                    {
                        if (other.CompareTag("Player"))
                        {
                            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

                            Destroy(gameObject);
                        }
                        if(!other.CompareTag("Player"))
                        {
                            Debug.Log("hit wall, the nugget did i mean.");
                            bounces++;
                        }

                        if(bounces >= maxBounces)
                        {
                            Destroy(gameObject);
                        }
                    }

                }
            }
        }
    }
}
