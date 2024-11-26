using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
    public bool cutsceneViewed;
    public bool inCutscene;
    public Animator cinemaFadeAnim;
    public DialogueTrigger dt;
    public PlayerMovement pm;
    public DialogueManager dm;

    public GameObject KokoUI;
    public bool cheriTrigger;
    public cheriBossScript cbs;
    public MeleeEnemy1 me1;
    public PlayerInteract pi;
    public MusicController mc;
    public AudioClip cheriBossTheme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {


        if (!pm.INSTARTSCREEN)
        {


            if (!cutsceneViewed)
            {
                if (other.CompareTag("Player"))
                {
                    KokoUI.SetActive(false);
                    pm.GRANDERLOCK = true;
                    dt.TriggerDialogue();
                    dm.DisplayNextSentence();
                    inCutscene = true;


                    cinemaFadeAnim.SetBool("idle", true);
                    Debug.Log("CUTSCENE INBOUND");
                }
            }

            if (cheriTrigger)
            {


                if (!inCutscene)
                {


                    if (cutsceneViewed)
                    {
                        cbs.canStartAttackRolling = true;
                        mc.CrossFade(cheriBossTheme);
                    }
                }
            }
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inCutscene = false;
        }

        if (cheriTrigger)
        {
            cbs.canStartAttackRolling = false;
            me1.ResetStats();
            cbs.firstLaserTime = true;
            cbs.secondLaserTime = false;
            cbs.warp7security = true;
            cbs.warp8security = true;
            cbs.attackTimer = 1.8f;
        }
    }
}
