using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaBoxAnimHandler : MonoBehaviour
{

    public Animator animator;
    public PlayerMovement pm;
    public PlayerInteract pi;
    public DialogueManager dm;
    public GameObject diaCanvas;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pm = FindObjectOfType<PlayerMovement>();
        pi = FindObjectOfType<PlayerInteract>();
        dm = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLoop()
    {
        animator.SetBool("isLoop", true);
        animator.SetBool("isOpen", false);
    }

    public void ToIdle()
    {
        animator.SetBool("isPop", false);
        StartCoroutine(DialogueResetWait());
    }

    public IEnumerator DialogueResetWait()
    {
        yield return new WaitForSeconds(0.1f);
        diaCanvas.SetActive(true);        
        pi.canInteract = true;
        dm.isTalking = false;
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        pm.GRANDERLOCK = false;
        dm.isPopped = true;
        Debug.Log("DIA BOX ANIM 2");


    }

    public void Popper()
    {
        dm.TalkReset();

    }
}
