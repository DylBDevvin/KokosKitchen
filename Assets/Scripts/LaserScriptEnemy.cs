using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptEnemy : MonoBehaviour
{

    public int damage;
    public bool canDamage;

    // Start is called before the first frame update
    void Start()
    {
        canDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (canDamage)
            {
                other.GetComponent<PlayerMovement>().TakeDamage(damage);
                canDamage = false;
                StartCoroutine(DamageWait());
            }
        }
    }

    public IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(0.05f);
        canDamage = true;
    }
}
