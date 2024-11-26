using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleCardScript : MonoBehaviour
{
    public Text titleText;
    public Text buttText;
    

    public string placeName;


    public bool teleports;
    public bool teleportUnlocked;
    public bool changesMusic;

    public AudioClip areaSong;

    public Animator tCardAnim;
    public Animator tUnlockAnim;

    public MusicController mc;

    public bool City;
    public bool Beach;
    public bool Royal;
    public bool Cave;
    public bool WrongN;
    public bool Cold;
    public bool Cold2;
    public bool RaidEXT;
    public bool RaidINT;
    public bool chicken;
    public bool creamy;
    public bool goop;
    public bool cave2;
    public bool everautumn;
    public bool spring;
    public bool caveEntrance;
    public bool caveExit;
    public bool cheri2ndHalf;
    public bool goop2;
    public bool spring2;
    public bool cold3;
    public bool stealthCave;
    public bool cheriStealth;
    public bool chickenPart;
    public bool cheriFinalSec;
    public bool royalRoad;
    public bool arena;
    

    public PlayerMovement pm;
    public ChickenScript cs;

    public GameObject creamcheese;

    public ParticleSystem snowParticles;
    public ParticleSystem rainParticles;
    public ParticleSystem rainParticles2;

    public GameObject CityObjects;
    public GameObject BeachObjects;
    public GameObject RoyalObjects;
    public GameObject CaveObjects;
    public GameObject WrongNObjects;
    public GameObject ColdObjects;
    public GameObject raidObjects;
    public GameObject goopObjects;
    public GameObject stealthSkellies1;
    public GameObject stealthSkellies2;
    public GameObject springObjects;
    public GameObject royalRoadObjects;
    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        cs = FindObjectOfType<ChickenScript>();
        mc = FindObjectOfType<MusicController>();
        rainParticles.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            if (teleports && !teleportUnlocked) // Plays Unlock Teleport Text Animation ONCE.
            {
                tUnlockAnim.SetBool("canFade", true);
              //  buttText.text = placeName;
                teleportUnlocked = true;
                StartCoroutine(ResetTCARDUnlock());
                if (City)
                {
                    pm.cityUnlocked = true;

                }
                if (Beach)
                {
                    pm.beachUnlocked = true;

                }
                if (Royal)
                {
                    pm.royalUnlocked = true;

                }
                if (Cave)
                {
                    pm.caveUnlocked = true;

                }
                if (WrongN)
                {
                    pm.wrongNeighborhoodUnlocked = true;

                }
                if (Cold2)
                {
                    pm.coldUnlocked = true;

                }
                if (RaidEXT)
                {
                    pm.raidEXTunlocked = true;

                }
                if (RaidINT)
                {
                    pm.raidINTunlocked = true;

                }

                if (creamy)
                {

                }
            }

            titleText.text = placeName;
            tCardAnim.SetBool("canFade", true);
            StartCoroutine(ResetTCARD());

            if (changesMusic)
            {
                mc.MuteButton();
                StartCoroutine(SwitchWait());
            }

            if (Cold)
            {
                snowParticles.Play();
            }
 
                if (City)
                {
                    
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(true);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                    stealthSkellies1.SetActive(false);
                    stealthSkellies2.SetActive(false);
                    springObjects.SetActive(false);
                    royalRoadObjects.SetActive(false);


                pm.respawnTransform = pm.cityTransform;
                }
                if (Beach)
                {
  
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(true);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                    stealthSkellies1.SetActive(false);
                    stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.beachTransform;
                }
                if (Royal)
                {        
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(true);
                    goopObjects.SetActive(false);
                    stealthSkellies1.SetActive(false);
                    stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);


                pm.respawnTransform = pm.royalTransform;
                }
                if (Cave)
                {
                
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(true);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.caveTransform;
                }
                if (WrongN)
                {
                   
                    WrongNObjects.SetActive(true);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);
            }
                if (Cold)
                {
                  
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(true);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.winter;
                }

            if (Cold2)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(true);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                 springObjects.SetActive(false);
                    royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.winter2;
            }
                if (RaidEXT)
                {
                 
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(true);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);


                pm.respawnTransform = pm.cheri;
                
                }
                if (RaidINT)
                {
                  
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.cheriFinale;
                }

                if (goop)
                {
                    rainParticles.Play();
                    WrongNObjects.SetActive(false);
                    ColdObjects.SetActive(false);
                    raidObjects.SetActive(false);
                    CaveObjects.SetActive(false);
                    CityObjects.SetActive(false);
                    BeachObjects.SetActive(false);
                    RoyalObjects.SetActive(false);
                    goopObjects.SetActive(true);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);


                pm.respawnTransform = pm.doomGoop;
                }

            if (goop2)
            {
                rainParticles.Play();
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(true);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.doomGoop2;
            }
                if (RaidEXT)
                {
                    rainParticles2.Play();
                }

            if (cave2)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(true);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.caveTransform2;
            }

            if (everautumn)
            {
                WrongNObjects.SetActive(true);
                ColdObjects.SetActive(true);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);
                pm.respawnTransform = pm.foreverAutumn;
            }

            if (caveEntrance)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(true);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(false);
                pm.respawnTransform = pm.beachTransform;
            }

            if (spring)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(true);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(true);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.spring;
            }

            if (cheri2ndHalf)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(true);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);

                pm.respawnTransform = pm.cheri2ndHalf;
            }
            if (spring2)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(true);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(true);
                royalRoadObjects.SetActive(false);

                pm.respawnTransform = pm.spring2;
            }

            if (cold3)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(true);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);

                pm.respawnTransform = pm.winter3;
            }

            if (stealthCave)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(true);
                stealthSkellies2.SetActive(false);
            }

            if (cheriStealth)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(true);

                pm.respawnTransform = pm.cheriStealthRespawn;
            }

            if (cheriFinalSec)
            {
                pm.respawnTransform = pm.cheriFinalSectionRespawn;

                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(true);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
            }

            if (chickenPart)
            {
                pm.respawnTransform = pm.chickenRespawn;

                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(true);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(false);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
            }

            if (royalRoad)
            {
                WrongNObjects.SetActive(false);
                ColdObjects.SetActive(false);
                raidObjects.SetActive(false);
                CaveObjects.SetActive(false);
                CityObjects.SetActive(false);
                BeachObjects.SetActive(false);
                RoyalObjects.SetActive(true);
                goopObjects.SetActive(false);
                stealthSkellies1.SetActive(false);
                stealthSkellies2.SetActive(false);
                springObjects.SetActive(false);
                royalRoadObjects.SetActive(true);
            }

            if (arena)
            {
                pm.respawnTransform = pm.ArenaRespawn;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            if (chicken)
            {
                cs.hit = false;
                cs.ChickenReset();
            }
            if (creamy)
            {

            }

            if (Cold || Cold2)
            {
                snowParticles.Stop();
            }
            if (goop)
            {
                rainParticles.Stop();
            }
            if (RaidEXT)
            {
                rainParticles2.Stop();
            }
        }
    }

    public IEnumerator ResetTCARD()
    {
        yield return new WaitForSeconds(2.99f);
        tCardAnim.SetBool("canFade", false);
    }

    public IEnumerator ResetTCARDUnlock()
    {
        yield return new WaitForSeconds(2.99f);
        tUnlockAnim.SetBool("canFade", false);
    }

    public IEnumerator SwitchWait()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("SWITCHING SONGS NOW!");
        mc.CrossFade(areaSong);
    }
    
}
