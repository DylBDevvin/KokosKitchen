using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdZoneScript : MonoBehaviour
{
    public bool accumulatingFrost;
    public bool canCount;
    public float timer;
    public float timeLimit;
    public float damageCD;
    public float damageCDlimit;
    public int damage;

    public GameObject coldMeter;
    public Image coldFill;
    public GameObject player;

    public Animator meterAnim;
    public Animator snowflakeAnim;
    public Animator bgAnim;

    public bool canPlaySE = true;
    // Start is called before the first frame update
    void Start()
    {
        meterAnim.SetBool("Idle", true);
        snowflakeAnim.SetBool("Idle", true);
        bgAnim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            StartCoroutine(MeterOn());
            timer += Time.deltaTime;
            coldFill.fillAmount = timer / timeLimit;
        }
        if(timer >= timeLimit)
        {
            meterAnim.SetBool("Freezing", true);
            meterAnim.SetBool("Idle", false);
            snowflakeAnim.SetBool("Idle", false);
            bgAnim.SetBool("Idle", false);
            timer = timeLimit;
            if (canPlaySE)
            {
                SoundManagerScript.PlaySound("freeze");
                canPlaySE = false;
            }
            damageCD += Time.deltaTime;
            
        }
        if(timer < timeLimit && accumulatingFrost)
        {     
            meterAnim.SetBool("Meter", true);
            meterAnim.SetBool("Freezing", false);
            meterAnim.SetBool("Idle", false);
            snowflakeAnim.SetBool("Idle", false);
            bgAnim.SetBool("Idle", false);
            canPlaySE = true;
        }
        if(damageCD >= damageCDlimit)
        {
            player.GetComponent<PlayerMovement>().TakeDamage(damage);
            damageCD = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canCount = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject != null)
        {


            if (other.CompareTag("Player"))
            {
                meterAnim.SetBool("FadeOut", true);
                snowflakeAnim.SetBool("FadeOut", true);
                bgAnim.SetBool("FadeOut", true);
                meterAnim.SetBool("FadeIn", false);
                meterAnim.SetBool("Freezing", false);
                if (gameObject != null)
                {


                    StartCoroutine(IdleOn());
                }
                canCount = false;
                timer = 0;
                damageCD = 0;
            }
        }
    }

    public IEnumerator MeterOn()
    {
        meterAnim.SetBool("FadeIn", true);
        snowflakeAnim.SetBool("FadeIn", true);
        bgAnim.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1f);
        accumulatingFrost = true;
        meterAnim.SetBool("FadeIn", false);
        snowflakeAnim.SetBool("FadeIn", false);
        bgAnim.SetBool("FadeIn", false);
        meterAnim.SetBool("Meter", true);
    }

    public IEnumerator IdleOn()
    {
        yield return new WaitForSeconds(1f);
        accumulatingFrost = false;
        meterAnim.SetBool("FadeOut", false);
        snowflakeAnim.SetBool("FadeOut", false);
        bgAnim.SetBool("FadeOut", false);
        meterAnim.SetBool("Idle", true);
        snowflakeAnim.SetBool("Idle", true);
        bgAnim.SetBool("Idle", true);
    }

}
