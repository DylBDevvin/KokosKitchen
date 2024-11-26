using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KokoLaserScript : MonoBehaviour
{
    public int damage;
    public ShopScript ss;

    public bool canDamage;
    public bool hitting;

    public float damageCooldown;

    // Start is called before the first frame update
    void Start()
    {
        canDamage = true;
        ss = FindObjectOfType<ShopScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Shooting AI"))
        {
            Debug.Log("ENEMY IN FRICKIN RANGE GAHDAMN");
            if (other.gameObject.CompareTag("Shooting AI") && canDamage)
            {
                other.GetComponent<PatrollingAI>().TakeDamage(damage + ss.currentStrength);
                canDamage = false;
                StartCoroutine(DamageWait());
            }

            if (other.gameObject.CompareTag("Enemy") && canDamage)
            {
                other.GetComponent<MeleeEnemy1>().TakeDamage(damage + ss.currentStrength);
                canDamage = false;
                StartCoroutine(DamageWait());
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Shooting AI"))
        {
            Debug.Log("ENEMY IN FRICKIN RANGE GAHDAMN");
            if (other.gameObject.CompareTag("Shooting AI") && canDamage)
            {
                other.GetComponent<PatrollingAI>().TakeDamage(damage + ss.currentStrength);
                canDamage = false;
                StartCoroutine(DamageWait());            
            }

            if (other.gameObject.CompareTag("Enemy") && canDamage)
            {
                other.GetComponent<MeleeEnemy1>().TakeDamage(damage + ss.currentStrength);
                canDamage = false;
                StartCoroutine(DamageWait());
            }
        }
    }
    public IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(damageCooldown);
        damage = 1;
        canDamage = true;
    }

} 

