using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite offSprite;
    public Sprite onSprite;

    public float countdown;
    public float limit;

    public bool on;
    public bool off;
    public bool hit;

    public bool staysOn;
    public bool solver;

    public bool resetter;

    public PlayerMovement pm;
    
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = offSprite;
        off = true;
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resetter)
        {
            off = true;
            on = false;
            countdown = 0;
            sr.sprite = offSprite;
            solver = false;
            hit = false;
        }

        if (pm.dead)
        {
            on = false;
            off = true;
            countdown = 0;
            sr.sprite = offSprite;
            solver = false;
            hit = false;
        }

        if (!pm.dead)
        {


            if (hit == true && !pm.dead)
            {
                on = true;
                off = false;
                countdown += Time.deltaTime;
                sr.sprite = onSprite;
            }

            if (!staysOn)
            {
                if (countdown >= limit)
                {
                    off = true;
                    on = false;
                    hit = false;
                    countdown = 0;
                    sr.sprite = offSprite;
                }
            }

            if (solver)
            {
                on = true;
                hit = true;
                off = false;
            }

            if (hit == false)
            {
                sr.sprite = offSprite;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KokoBullet") || other.CompareTag("EnemyBullet"))
        {
            hit = true;
        }
    }
}
