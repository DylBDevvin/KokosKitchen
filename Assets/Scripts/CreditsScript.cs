using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class CreditsScript : MonoBehaviour
{
    public Animator rrAnim;
    public GameObject text;
    public Animator anim1;
    public Animator anim2;
    public GameObject lobster;
    public GameObject chicken;
    public GameObject rr;
    public GameObject sad;
    public GameObject GOODBYE;
    public VideoPlayer rr2;
    public VideoPlayer rr3;
    public GameObject img;

    public float timer;
    public float fade1Timer;
    public float fade2Timer;
    public float fade3Timer;
    public float fade4Timer;
    public float fade5Timer;
    public float fade6Timer;
    public float fade7Timer;
    public float fade8timer;
    public float fade0timer;
    public float fadeUghTimer;
    public bool reset;
    public float inactiveRRTime;
    public GameObject tyText;
    public bool done;

    public ushort xVol = 0;
    public float yVol;
    public float yVol2;
    public float decreaser;
    public float increaser;
    public float yVolMax;
    public bool swappin;
    public GameObject guy;
    public ChestScript cs;
    public GameObject blackener;
    public bool h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cs.CANCREDIT)
        {


            if (swappin)
            {
                rr2.SetDirectAudioVolume(xVol, yVol);
                yVol -= decreaser;



            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                reset = true;
                timer = 0;
                text.SetActive(false);
                lobster.SetActive(false);
                chicken.SetActive(false);
                rr.SetActive(false);
                sad.SetActive(false);
                tyText.SetActive(false);
                guy.SetActive(false);

                rrAnim.SetBool("FINAL", true);


                GOODBYE.SetActive(true);
                StartCoroutine(LoadTitleScreen());


            }
            if (!reset)
            {


                timer += Time.deltaTime;

                if (timer >= fade0timer && !h)
                {
                    text.SetActive(true);
                    img.SetActive(true);
                    rr.SetActive(true);
                    text.SetActive(true);
                    img.SetActive(true);

                }

                if (timer >= fadeUghTimer)
                {
                    guy.SetActive(false);
                }
                if (timer >= fade1Timer)
                {
                    blackener.SetActive(false);
                    rrAnim.SetBool("toFade1", true);
                }

                if (timer >= fade2Timer)
                {
                    rrAnim.SetBool("fade", true);
                    text.SetActive(true);
                }

                if (timer >= fade3Timer)
                {
                    rrAnim.SetBool("fade2", true);
                }

                if (timer >= fade4Timer)
                {
                    lobster.SetActive(true);
                }

                if (timer >= fade5Timer)
                {
                    chicken.SetActive(true);
                    anim1.SetBool("out", true);
                }

                if (timer >= fade6Timer)
                {
                    anim2.SetBool("out", true);
                }

                if (timer >= fade7Timer)
                {
                    if (!done)
                    {
                        h = true;
                        rr.SetActive(false);
                        StartCoroutine(SmoothInactivate());
                        sad.SetActive(true);
                        rr.SetActive(false);
                        done = true;
                    }

                }

                if (timer >= fade8timer)
                {
                    swappin = true;
                }
            }
        }


    }

    public IEnumerator LoadTitleScreen()
    {
        yield return new WaitForSeconds(9f);

        //Load Title screen
        blackener.SetActive(true);
        reset = false;
        Debug.Log("welp...");
        Application.Quit();
    }

    public IEnumerator SmoothInactivate()
    {
        if (!reset)
        {


            yield return new WaitForSeconds(inactiveRRTime);
            tyText.SetActive(true);
            rr.SetActive(false);
           // Application.Quit();
        }
    }
}

    



