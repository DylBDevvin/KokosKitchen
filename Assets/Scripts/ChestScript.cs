using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestScript : MonoBehaviour
{
    public InteractionObject io;
    public bool open;
    public GameObject loot;
    public LevelSystem ls;
    public int expToGive;

    public SlimeBallScript sb;
    public SlimeBallScript sb2;
    public PlayerInteract pi;
    public PlayerMovement pm;

    public bool ratChest;
    public bool scoreChest;
    public bool scoreChest2;
    public bool locked;
    public bool SUITCASE;
    public GameObject blackener;

    public int ratReq;
    public int scoreReq;
    public GameObject canvas;
    public GameObject player;
    public Camera cam;

    public bool CANCREDIT;
    public GameObject ugh;
    
    // Start is called before the first frame update
    void Start()
    {
        io = GetComponent<InteractionObject>();
        ls = FindObjectOfType<LevelSystem>();
        sb = FindObjectOfType<SlimeBallScript>();
        pi = FindObjectOfType<PlayerInteract>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChest()
    {
        if (SUITCASE)
        {
            blackener.SetActive(true);
            pm.GRANDERLOCK = true;
            canvas.SetActive(false);
            CANCREDIT = true;
            ugh.SetActive(true);
            

            //SceneManager.LoadSceneAsync("CREDITS");
        }
        if (!locked)
        {
            Instantiate(loot, transform.position, transform.rotation);
            ls.GainExperienceFlatRate(expToGive);
            SoundManagerScript.PlaySound("chestSE");
            open = true;
            Debug.Log("man");
            gameObject.SetActive(false);
        }

        if (ratChest)
        {
            if (pi.ratCount >= ratReq)
            {
                Instantiate(loot, transform.position, transform.rotation);
                ls.GainExperienceFlatRate(expToGive);
                SoundManagerScript.PlaySound("chestSE");
                open = true;
                Debug.Log("man");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("NOT ENOUGH RAT!!!");
            }
        }

        if (scoreChest)
        {
            if (sb.maxScore >= scoreReq)
            {
                Instantiate(loot, transform.position, transform.rotation);
                ls.GainExperienceFlatRate(expToGive);
                SoundManagerScript.PlaySound("chestSE");
                open = true;
                Debug.Log("man");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("NOT ENOUGH  UHHHH HIGH SCHORE");
            }
        }

        if (scoreChest2)
        {
            if (sb2.maxScore >= scoreReq)
            {
                Instantiate(loot, transform.position, transform.rotation);
                ls.GainExperienceFlatRate(expToGive);
                SoundManagerScript.PlaySound("chestSE");
                open = true;
                Debug.Log("man");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("NOT ENOUGH  UHHHH HIGH SCHORE");
            }


        }
    }
}
