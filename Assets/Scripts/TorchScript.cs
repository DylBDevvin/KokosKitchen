using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    public bool canHeat;
    public Animator anim;

    public float rekindleWaitTime = 5;
    public float idleWaitTime = 0.15f;

    public GameObject torchLight;
        
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canHeat = true;
 
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KokoBullet"))
        {
            anim.SetBool("Blown", true);
            anim.SetBool("Idle", false);
            StartCoroutine(Rekindle());
        }
    }

    public IEnumerator Rekindle()
    {
        canHeat = false;
        yield return new WaitForSeconds(rekindleWaitTime);
        anim.SetBool("Rekindle", true);
        anim.SetBool("Blown", false);
        StartCoroutine(ToIdle());
    }

    public IEnumerator ToIdle()
    {
        yield return new WaitForSeconds(idleWaitTime);
        anim.SetBool("Rekindle", false);
        anim.SetBool("Idle", true);
        canHeat = true;
        torchLight.SetActive(true);
    }
}
