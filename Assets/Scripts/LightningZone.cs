using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningZone : MonoBehaviour
{
    public float lightningTimer;
    public float lightningLocateTime;
    public float zapTimer;
    public float zapTime;

    public bool canZap;
    public bool canLocate;
    public bool hbActive;
    public bool lightningTime;

    public GameObject target;
    public GameObject LightningMarker;
    public GameObject lightning;
    public GameObject lightningDropper;
    public GameObject lightningHitbox;

    public Animator flashAnim;

    // Start is called before the first frame update
    void Start()
    {
        LightningMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lightningTime)
        {
            Lightning();
        }
    }

    public void Lightning()
    {
        if (hbActive)
        {
            lightningHitbox.SetActive(true);
        }

        if (!hbActive)
        {
            lightningHitbox.SetActive(false);
            //Debug.Log("HB INACTIVE");
        }

        lightningTimer += Time.deltaTime;

        if (lightningTimer >= lightningLocateTime && !canLocate)
        {
            //Drop the marker at the player position, play sound effect ONCE
            LightningMarker.SetActive(true);
            SoundManagerScript.PlaySound("thunder");
            LightningMarker.transform.position = target.transform.position;
            lightningHitbox.transform.position = target.transform.position;
            canLocate = true;
            canZap = true;
        }

        if (canZap)
        {
            zapTimer += Time.deltaTime;
        }

        if (zapTimer >= zapTime)
        {
            //Drop the lightning bolt
            Instantiate(lightning, lightningDropper.transform.position, lightningDropper.transform.rotation);
            StartCoroutine(ActiveHitBox());
            
            zapTimer = 0;
            lightningTimer = 0;
            canZap = false;
            canLocate = false;
            LightningMarker.SetActive(false);
        }
    }

    public IEnumerator ActiveHitBox()
    {
        yield return new WaitForSeconds(0.2f); //LIGHTNING STRUCK
        hbActive = true;
        CameraShake.Instance.ShakeCamera(9f, .2f);
        flashAnim.SetBool("flash", true);
        SoundManagerScript.PlaySound("lightning");

        yield return new WaitForSeconds(0.1f);

        hbActive = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightningTime = true;
            Debug.Log("Player in zone.");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightningTime = false;
            Debug.Log("player not ");
        }
    }
}
