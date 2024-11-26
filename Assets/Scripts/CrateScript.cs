using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public int health;
    public bool cardShield;
    public float timer;
    public float timerMax;
    public SpriteRenderer sr;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(FlashRed());
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (cardShield)
        {
            timer += Time.deltaTime;
            if(timer >= timerMax)
            {
                Destroy(gameObject);
                timer = 0;
            }
        }
    }

    public IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.125f);
        sr.color = Color.white;
    }


}
