using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Image characterImage;
    public Text dialogueText;
    public Animator animator;

    public Queue<string> sentences;
    public Queue<string> names;
    public Queue<Sprite> images;
    public SpriteRenderer sr;
   
    public PlayerMovement pm;
    public bool isTalking = false;
    public bool canOpen = true;
    public PlayerInteract pi;

    public GameObject diaCanvas;
    
    public int num;

    public Rigidbody2D rb;
    public bool canProceed;
    public float counter;
    public float counterMax;
    public cutscene cuts;
    public cutscene cuts2;
    public cutscene cuts3;
    public GameObject KokoUI;

    public cheriBossScript cbs;

    public MusicController mc;
    public AudioClip cheriBossTheme;
    public bool isPopped;
    public GameObject diaPop;
    public MenuScript ms;



    // Start is called before the first frame update
    void Start()
    {
        pi = FindObjectOfType<PlayerInteract>();
        
        sentences = new Queue<string>();
        names = new Queue<string>();
        images = new Queue<Sprite>();
        pm = FindObjectOfType<PlayerMovement>();
        canProceed = true;
        
    }

    private void Update()
    {

        if (pi.interLocked)
        {
           ToIdle();
           
        }
        

        if (!pi.interLocked)
        {


            if (!cuts2.inCutscene)
            {
                if ((Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.F)) && pi.npcInRange)
                {
                    pm.GRANDERLOCK = true;
                    rb.isKinematic = true;
                    if (canProceed)
                    {
                        DisplayNextSentence();
                    }

                }
            }
        }

            if (cuts2.inCutscene)
            {
                if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.F))
                {
                    pm.GRANDERLOCK = true;
                    rb.isKinematic = true;
                    if (canProceed)
                    {
                        DisplayNextSentence();
                    }

                }
            }

            if (cuts3.inCutscene)
            {
                if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.F))
                {
                    pm.GRANDERLOCK = true;
                    rb.isKinematic = true;
                    if (canProceed)
                    {
                        DisplayNextSentence();
                    }

                }
            }

       
        
    }

    public void StartDialogue (Dialogue dialogue)
    {
        if (!pi.interLocked)
        {
            ms.canOpenMenu = false;
            pm.animator.SetBool("moving", false);
            pm.animator.SetBool("running", false);
            pm.rb.velocity = Vector2.zero;
            pi.canInteract = false;
            isTalking = true;
            pm.canMove = false;
            pm.canShoot = false;
            pm.canChargeShot = false;
            pi.talking = true;



            animator.SetBool("isOpen", true);




            sentences.Clear();
            names.Clear();
            images.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);

            }

            foreach (string name in dialogue.names)
            {
                names.Enqueue(name);

            }

            foreach (Sprite image in dialogue.images)
            {
                images.Enqueue(image);

            }
        }
      
    }

    public void DisplayNextSentence()
    {
        if (!pi.interLocked)
        {


            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            string name = names.Dequeue();
            Sprite image = images.Dequeue();
            nameText.text = name;
            characterImage.sprite = image;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

        }
    }



    

    IEnumerator TypeSentence (string sentence)
    {
        canProceed = false;
        
        dialogueText.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            if (dialogueText.text.Length >= 1)
            {
                canProceed = true;
            }

            if (letter % 8 == 0)
            {
                num = UnityEngine.Random.Range(0, 3);
                if(num == 1)
                {
                    SoundManagerScript.PlaySound("tapSE");
                }
                if (num == 0)
                {
                    SoundManagerScript.PlaySound("gramsSpeak");
                }
                if (num == 2)
                {
                    SoundManagerScript.PlaySound("kokoSpeak");
                }

            }
            yield return null;
        }

        
            
    }

    void EndDialogue()
    {
        if (!pi.interLocked)
        {
            if (pi.talking)
            {


                rb.isKinematic = false;
                ms.canOpenMenu = true;
                diaPop.SetActive(true);
                pi.interLocked = true;
                StartCoroutine(InteractReset());
                diaCanvas.SetActive(false);
                Debug.Log("End of conversation");
                animator.SetBool("isLoop", false);
                animator.SetBool("isPop", true);
                SoundManagerScript.PlaySound("pop");
                pi.talking = false;
                sentences.Clear();
                names.Clear();
                images.Clear();

                if (cuts.inCutscene)
                {
                    cuts.cinemaFadeAnim.SetBool("idle", false);
                    cuts.inCutscene = false;
                    cuts.cutsceneViewed = true;
                    KokoUI.SetActive(true);
                }

                if (cuts2.inCutscene)
                {
                    cuts2.cinemaFadeAnim.SetBool("idle", false);
                    cuts2.inCutscene = false;
                    cuts2.cutsceneViewed = true;
                    KokoUI.SetActive(true);
                    cbs.canStartAttackRolling = true;
                    mc.CrossFade(cheriBossTheme);
                }

                if (cuts3.inCutscene)
                {
                    cuts3.cinemaFadeAnim.SetBool("idle", false);
                    cuts3.inCutscene = false;
                    cuts3.cutsceneViewed = true;
                    KokoUI.SetActive(true);
                    cbs.canStartAttackRolling = false;

                }
            }
        }
        // maybe clear it or something, but hide it in inspector after? With code. Think theres code for that
    }

    public void StartLoop()
    {
        animator.SetBool("isLoop", true);
        animator.SetBool("isOpen", false);
    }

    public void ToIdle()
    {
        diaCanvas.SetActive(true);
        animator.SetBool("isPop", false);
        
        Debug.Log("IDLE!!!!");
    }

    public IEnumerator InteractReset()
    {
        yield return new WaitForSeconds(1.1f);

       
        pi.interLocked = false;
        isPopped = false;
        canOpen = true;
        pi.canInteract = true;
        isTalking = false;
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        pm.GRANDERLOCK = false;
        rb.isKinematic = false;

    }

    public void TalkReset()
    {
        StartCoroutine(InteractReset());
    }
}


