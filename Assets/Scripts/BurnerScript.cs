using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerScript : MonoBehaviour
{
    public Animator anim;

    public float burnRate;
    public float burnDuration;
    public float burnMaxTime;
    public float cooldown;

    public int damage;

    public bool burning;
    public bool canDamage;
    public bool canHit;

    public Collider2D burningCollider;
    public GameObject player;


    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        
        if (cooldown >= burnRate)
        {
            canHit = true;
            cooldown = burnRate;
            anim.SetBool("canBurn", true);
            burningCollider.enabled = true;
            burnDuration += Time.deltaTime;
        }
        else
        {
            canHit = false;
        }
        if (burnDuration >= burnMaxTime)
        {
            anim.SetBool("canBurn", false);
            burningCollider.enabled = false;
            cooldown = 0;
            burnDuration = 0;
        }

        if(burning && canDamage && canHit)
        {
            player.GetComponent<PlayerMovement>().TakeDamage(damage);
            StartCoroutine(DamageWait());
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            burning = true;
            Debug.Log("burning");
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            burning = false;
            Debug.Log("nvm");
        }
    }

    public IEnumerator DamageWait()
    {
        canDamage = false;
        yield return new WaitForSeconds(0.3f);
        canDamage = true;
    }
}
