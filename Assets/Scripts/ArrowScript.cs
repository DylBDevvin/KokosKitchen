using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public int damage;
    public ShopScript ss;
    public float aliveTime;
    public float aliveDuration;

    public bool chargeShot;
    public float csDamageMult;

    public ShopScript4 ss4;

    public PlayerMovement pm;
    public int damageBonus;
    public bool bouncy;
    public int count;
    public int maxCount;
    public Animator anim;
    public Rigidbody2D rb;

    public Collider2D col1;
    public Collider2D col2;

   // public GameObject damNum;



    private void Start()
    {
        ss = FindObjectOfType<ShopScript>();
        ss4 = FindObjectOfType<ShopScript4>();
        pm = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        
        
        // fs = FindObjectOfType<Flasher>();
    }

    private void Update()
   {

      aliveTime += Time.deltaTime;
      if (aliveTime >= aliveDuration)
       {
            anim.SetBool("pop", true);
            rb.bodyType = RigidbodyType2D.Static;
          
            aliveTime = 0;
       }

        csDamageMult = ss4.currentDmult;
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player") || other.CompareTag("EnemyBullet")) {

            if (!chargeShot)
            {
                if (pm.dmgBuffed)
                {
                    damage = damage + ss.currentStrength + damageBonus;
                    if(damage >= 35)
                    {
                        damage = 35;
                        Debug.Log("HEY WTF WAS THAT");
                    }
                    other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    damage = damage + ss.currentStrength;
                    if (bouncy)
                    {
                        damage = damage / 3;
                        damage = Mathf.CeilToInt(damage);


                    }
                    if (damage >= 30)
                    {
                        damage = 30;
                        Debug.Log("HEY WTF WAS THAT");
                    }
                    other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                }
                
            }

            if (chargeShot)
            {
                


                    if (pm.dmgBuffed)
                    {
                        damage = damage + ss.currentStrength + damageBonus;
                        if (damage >= 35)
                        {
                            damage = 35;
                        Debug.Log("HEY WTF WAS THAT");

                        
                        }
                        other.SendMessage("TakeDamage", Mathf.Ceil(damage * ss4.currentDmult), SendMessageOptions.DontRequireReceiver);
                    }
                    if (chargeShot && !pm.dmgBuffed)
                    {
                        damage = damage + ss.currentStrength;
                        damage = Mathf.CeilToInt(damage * ss4.currentDmult);
                        Debug.Log(ss4.currentDmult);
                        Debug.Log(damage);

                        if (damage >= 35)
                        {
                            damage = 35;
                        Debug.Log("HEY WTF WAS THAT");
                        }
                        other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                    }
                
            }
            //Instantiate(damNum, other.transform.position, Quaternion.identity);
            // fs = other.gameObject.GetComponent<Flasher>();

            if (!bouncy && !chargeShot)
            {                            
                anim.SetBool("pop", true);
                rb.bodyType = RigidbodyType2D.Static;
            }

            if (chargeShot)
            {
                if (!other.CompareTag("EnemyBullet"))
                {
                    
                    anim.SetBool("pop", true);
                    rb.bodyType = RigidbodyType2D.Static;
                }
            }

            if (bouncy)
            {
                count += 1;
                if(count >= maxCount)
                {
                    anim.SetBool("pop", true);
                    rb.bodyType = RigidbodyType2D.Static;
                }
            }
        }

    }
    
    

    // public void DestroyBullet()
    //{
    // aliveTime += Time.deltaTime;
    // if(aliveTime >= 1.5)
    // {
    //   Debug.Log("DestroyTime");
    //   aliveTime = 0;
    // }
    // }

}
