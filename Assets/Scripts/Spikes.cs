using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public bool spiked;
    public bool canDamage = true;
    public GameObject player;
    public int damage = 2;

    public SpikeManager sm;

    public SpriteRenderer sr;
    public Sprite onSprite;
    public Sprite offSprite;
    public Collider2D spikeCollider;
    public bool rLaser;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<SpikeManager>();
        sr = GetComponent<SpriteRenderer>();
        spikeCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!rLaser)
        {


            if (sm.spikesOff)
            {

                spikeCollider.enabled = false;
                sr.sprite = offSprite;
            }
            else
            {

                spikeCollider.enabled = true;
                sr.sprite = onSprite;
            }
        }

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
        if (!rLaser)
        {


            canDamage = false;
            yield return new WaitForSeconds(0.3f);
            canDamage = true;
        }

        if (rLaser)
        {
            canDamage = false;
            yield return new WaitForSeconds(0.1f);
            canDamage = true;
        }
    }
}
