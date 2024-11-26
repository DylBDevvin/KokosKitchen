using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public GameObject player;
    public bool spiked;
    public bool canDamage = true;
    public float damageTime = 0.1f;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        canDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (spiked && canDamage)
        {
            player.GetComponent<PlayerMovement>().TakeDamage(damage);
            StartCoroutine(DamageWait());
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spiked = true;
            Debug.Log("burning");
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spiked = false;
            Debug.Log("nvm");
        }
    }

    public IEnumerator DamageWait()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageTime);
        canDamage = true;
    }
}
