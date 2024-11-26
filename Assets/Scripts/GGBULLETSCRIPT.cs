using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGBULLETSCRIPT : MonoBehaviour
{

    public int damage;
    public float aliveTime;
    public float aliveDuration;

    public ShopScript5 ss5;

    // Start is called before the first frame update
    void Start()
    {
        ss5 = FindObjectOfType<ShopScript5>();
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime += Time.deltaTime;
        if (aliveTime >= aliveDuration)
        {
            Destroy(gameObject);

            aliveTime = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || other.CompareTag("EnemyBullet"))
        {
            //damage = damage + ss.currentStrength;
            other.SendMessage("TakeDamage", damage + ss5.currentSlimeAttack, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
