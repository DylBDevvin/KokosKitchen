using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormButtonScript : MonoBehaviour
{

    public GameObject e1;
    public GameObject e2;
    public GameObject e3;
    public GameObject e4;
    public GameObject e5;
    public GameObject e6;
    public GameObject e7;
    public GameObject e8;
    public GameObject e9;

    public GameObject se1;
    public GameObject se2;
    public GameObject se3;
    public GameObject se4;
    public GameObject se5;
    public GameObject se6;
    public GameObject se7;
    public GameObject se8;
    public GameObject se9;

    public bool pressed;
    public PlayerMovement pm;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.dead)
        {
            pressed = false;
        }
    }

    

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Lightning")
        {
            Debug.Log("Lightning did in fact hit");
        }

        if (other.gameObject.tag == "Lightning")
        {
            Debug.Log("Player did in fact hit");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lightning"))
        {
            Debug.Log("Lightning did in fact hit11111um");
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player did in fact hit11111um");
        }
    }

    public void ScreenNuke()
    {
        if (!pressed)
        {


            if (e1 != null)
            {
                if (e1.activeSelf == true)
                {
                    e1.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e1.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e2 != null)
            {
                if (e2.activeSelf == true)
                {
                    e2.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e2.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e3 != null)
            {
                if (e3.activeSelf == true)
                {
                    e3.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e3.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e4 != null)
            {
                if (e4.activeSelf == true)
                {
                    e4.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e4.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e5 != null)
            {
                if (e5.activeSelf == true)
                {
                    e5.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e5.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e6 != null)
            {
                if (e6.activeSelf == true)
                {
                    e6.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e6.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e7 != null)
            {
                if (e7.activeSelf == true)
                {
                    e7.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e7.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e8 != null)
            {
                if (e8.activeSelf == true)
                {
                    e8.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e8.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (e9 != null)
            {
                if (e9.activeSelf == true)
                {
                    e9.GetComponent<MeleeEnemy1>().canTakeDmg = true;
                    e9.GetComponent<MeleeEnemy1>().ZapDeathEffect();
                }

            }
            if (se1 != null)
            {
                if (se1.activeSelf == true || se1.transform.parent == true)
                {
                    if (se1.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se1.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se2 != null)
            {
                if (se2.activeSelf == true || se2.transform.parent == true)
                {
                    if (se2.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se2.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se3 != null)
            {
                if (se3.activeSelf == true || se3.transform.parent == true)
                {
                    if (se3.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se3.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se4 != null)
            {
                if (se4.activeSelf == true || se4.transform.parent == true)
                {
                    if (se4.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se4.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se5 != null)
            {
                if (se5.activeSelf == true || se5.transform.parent == true)
                {
                    if (se5.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se5.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se6 != null)
            {
                if (se6.activeSelf == true || se6.transform.parent == true)
                {
                    if (se6.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se6.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se7 != null)
            {
                if (se7.activeSelf == true || se7.transform.parent == true)
                {
                    if (se7.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se7.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se8 != null)
            {
                if (se8.activeSelf == true || se8.transform.parent == true)
                {
                    if (se8.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se8.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            if (se9 != null)
            {
                if (se9.activeSelf == true || se9.transform.parent == true)
                {
                    if (se9.GetComponent<PatrollingAI>().zapped != true)
                    {
                        se9.GetComponent<PatrollingAI>().ZapDeathEffect();
                    }

                }

            }
            pressed = true;

        }
    }
}
