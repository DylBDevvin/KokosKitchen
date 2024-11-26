using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBulletScript : MonoBehaviour
{
    public GameObject heartPattern1;
    public GameObject heartPattern2;
    public GameObject heartPattern3;
    public GameObject heartPattern4;
    public GameObject heartPattern5;
    public GameObject heartPattern6;
    public GameObject heartPattern7;

    public GameObject heartSpawnLocation;

    public bool canFire;
    public int ranNum;

    public float wait1;
    public float wait2;
    public float wait3;

    public bool w1;
    public bool w2;
    public bool w3;
    public bool w4;

    public MeleeEnemy1 me1;
    public cheriBossScript cbs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (me1.dead)
        {
            canFire = false;
            gameObject.SetActive(false);
        }
        if (canFire)
        {
            if (w1)
            {               
                StartCoroutine(Wait0());
            }
            if (w2)
            {
                StartCoroutine(Wait1());
            }
            if (w3)
            {
                StartCoroutine(Wait2());
            }
            if (w4)
            {
                StartCoroutine(Wait3());
            }
        }
        
    }

    public void HeartFire()
    {
        if (canFire)
        {

            if (!cbs.warp7ing)
            {
                if (!cbs.warp8ing)
                {
                    ranNum = Random.Range(1, 7);

                    if (ranNum == 1)
                    {
                        Instantiate(heartPattern1, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                    if (ranNum == 2)
                    {
                        Instantiate(heartPattern2, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                    if (ranNum == 3)
                    {
                        Instantiate(heartPattern3, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                    if (ranNum == 4)
                    {
                        Instantiate(heartPattern4, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                    if (ranNum == 5)
                    {
                        Instantiate(heartPattern5, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                    if (ranNum == 6)
                    {
                        Instantiate(heartPattern6, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                    if (ranNum == 7)
                    {
                        Instantiate(heartPattern7, heartSpawnLocation.transform.position, heartSpawnLocation.transform.rotation);
                    }
                }
            }
            
        }     
       
    }

    public IEnumerator Wait0()
    {
        w1 = false;
        yield return new WaitForSeconds(0.1f);
        HeartFire();
        SoundManagerScript.PlaySound("HEARTSPAWN");
        w2 = true;
    }
    public IEnumerator Wait1()
    {
        w2 = false;
        yield return new WaitForSeconds(wait1);
        HeartFire();
        SoundManagerScript.PlaySound("HEARTSPAWN");
        w3 = true;
    }

    public IEnumerator Wait2()
    {
        w3 = false;
        yield return new WaitForSeconds(wait2);
        HeartFire();
        SoundManagerScript.PlaySound("HEARTSPAWN");
        w4 = true;
    }

    public IEnumerator Wait3()
    {
        w4 = false;
        yield return new WaitForSeconds(wait3);
        HeartFire();
        SoundManagerScript.PlaySound("HEARTSPAWN");
        canFire = false;
    }

    public void OpenHeart()
    {
        canFire = true;
        w1 = true;
    }



}
