using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Animator anim;
    public Animator KUI;

    public bool toOpen;
    public bool toClose;
    public bool canOpenMenu;

    public GameObject StatUIHolder;
    public GameObject FastTravelUIHolder;
    public GameObject SaveUIHolder;
    public GameObject ShopUIHolder;

    public Text HPtext;
    public Text LVtext;
    public Text PWRtext;
    public Text Speedtext;
    public Text CDtext;
    public Text moneyMulttext;
    public Text EXPMulttext;
    public Text parryPointtext;
    public Text slimePWRtext;
    public Text slimeCDtext;
    public Text chargePWRtext;

    public Text cityShopText;
    public Text cityShopText2;
    public Text shoregroveShopText;
    public Text shoregroveShopText2;
    public Text oceangrandShopText;
    public Text foreverfluShopText;

    public PlayerMovement pm;
    public PlayerInteract pi;
    public MoneyBank mb;
    public LevelSystem ls;
    public Parrier p;
    public ShopScript ss;
    public ShopScript2 ss2;
    public ShopScript4 ss4;
    public ShopScript3 ss3;
    public GlubGlubScript ggs;
    public ShopScript5 ss5;

    public GameObject player;
    public Animator faderAnim;

    public Transform cityFT;
    public Transform beachTownFT;
    public Transform royalCityFT;
    public Transform caveFT;
    public Transform wrongNeighborhoodFT;
    public Transform coldTownFT;
    public Transform raidenEXTFT;
    public Transform raidenINTFT;
    public bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();
        ls = FindObjectOfType<LevelSystem>();
        
        p = FindObjectOfType<Parrier>();
        ss = FindObjectOfType<ShopScript>();
        ss2 = FindObjectOfType<ShopScript2>();
        ss4 = FindObjectOfType<ShopScript4>();

        ggs = FindObjectOfType<GlubGlubScript>();
        ss5 = FindObjectOfType<ShopScript5>();
        anim = GetComponent<Animator>();

        canOpenMenu = true;
        DisplayStats();


    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();

        if (canOpenMenu)
        {
            if (Input.GetKeyDown(KeyCode.M) && !toOpen)
            {
                StartCoroutine(MenuPause());
                anim.SetBool("toClose", false);
                Debug.Log("menuOpen");
                pm.canShoot = false;
                menuOpen = true;
            }
            if (Input.GetKeyDown(KeyCode.M) && toOpen)
            {

                StartCoroutine(MenuPauseClose());
                Debug.Log("menuClose");
                pm.canShoot = true;
                menuOpen = false;
                pm.canShoot = true;
                
            }
        }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("toClose", false);
        anim.SetBool("toIdle", true);
        KUI.SetBool("toIn", false);
        toClose = false;
        toOpen = false;
        Debug.Log("menuReset");
    }

    public IEnumerator MenuPause()
    {

        yield return new WaitForSeconds(0.1f);
        
        anim.SetBool("toOpen", true);
        anim.SetBool("toIdle", false);
        anim.SetBool("toClose", false);
        KUI.SetBool("toOut", true);
        toOpen = true;

    }

    public IEnumerator MenuPauseClose()
    {

        yield return new WaitForSeconds(0.1f);
        KUI.SetBool("toOut", false);
        KUI.SetBool("toIn", true);
        anim.SetBool("toOpen", false);
        anim.SetBool("toClose", true);
        toOpen = false;

    }

    public void OpenUnJammer()
    {
        canOpenMenu = true;
    }
    public void OpenJammer()
    {
        canOpenMenu = false;
    }

    public void DisplayStats()
    {
        StatUIHolder.SetActive(true);
        FastTravelUIHolder.SetActive(false);
        SaveUIHolder.SetActive(false);
        ShopUIHolder.SetActive(false);
    }

    public void DisplayFastTravels()
    {
        StatUIHolder.SetActive(false);
        FastTravelUIHolder.SetActive(true);
        SaveUIHolder.SetActive(false);
        ShopUIHolder.SetActive(false);
    }

    public void DisplaySavePoint()
    {
        StatUIHolder.SetActive(false);
        FastTravelUIHolder.SetActive(false);
        SaveUIHolder.SetActive(true);
        ShopUIHolder.SetActive(false);
    }

    public void DisplayShopPoint()
    {
        Debug.Log("shop list should be open...");
        StatUIHolder.SetActive(false);
        FastTravelUIHolder.SetActive(false);
        SaveUIHolder.SetActive(false);
        ShopUIHolder.SetActive(true);
    }

    public void TextUpdate()
    {
        HPtext.text = "HP: " + pm.maxHealth.ToString();
        LVtext.text = "Level: " + ls.level.ToString();
        PWRtext.text = "PWR: " + ss.currentStrength.ToString();
        Speedtext.text = "Speed: " + ss2.currentSpeed.ToString();
        CDtext.text = "Fire CD: " + ss2.currentCooldown.ToString();
        moneyMulttext.text = "Money Mult: " + mb.moneyMult.ToString();
        EXPMulttext.text = "EXP Mult: " + ls.XPMult.ToString();
        parryPointtext.text = "Parry Points: " + p.pCount.ToString();
        slimePWRtext.text = "SlimePWR: " + ss5.currentSlimeAttack.ToString();
        slimeCDtext.text = "Slime CD: " + ggs.glubCooldown.ToString();
        chargePWRtext.text = "Charge PWR: " + ss4.currentDmult.ToString();

        if (pi.d1)
        {
            cityShopText.text = "City Shop";
        }
        if (pi.d2)
        {
            cityShopText2.text = "City Shop 2";
        }
        if (pi.d3)
        {
            oceangrandShopText.text = "Oceangrand Shop";
        }
        if (pi.d4)
        {
            shoregroveShopText.text = "Shoregrove Shop";
        }
        if (pi.d5)
        {
            shoregroveShopText2.text = "Shoregrove Shop 2";
        }
        if (pi.d6)
        {
            foreverfluShopText.text = "Foreverflu Shop";
        }
    }

    public void ToIdle()
    {
        faderAnim.SetBool("toWhite", false);
    }
    public void CityFastTravel()
    {
        if (pm.cityUnlocked)
        {


            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(CityMover());
            StartCoroutine(MenuPauseClose());
        }
    }
    public void BeachTownFastTravel()
    {
        if (pm.beachUnlocked)
        {


            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(BeachTownMover());
            StartCoroutine(MenuPauseClose());
        }
    }

    public void RoyalTownFastTravel()
    {
        if (pm.royalUnlocked)
        {


            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(RoyalCityMover());
            StartCoroutine(MenuPauseClose());
        }
    }

    public void CaveFastTravel()
    {
        if (pm.caveUnlocked)
        {


            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(CaveMover());
            StartCoroutine(MenuPauseClose());
        }
    }
    
    public void WrongNeighborhoodFastTravel()
    {
        if (pm.wrongNeighborhoodUnlocked)
        {


            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(WrongNeighborhoodMover());
            StartCoroutine(MenuPauseClose());
        }
    }

    public void ColdTownFastTravel()
    {
        if (pm.coldUnlocked)
        {


            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(ColdTownMover());
            StartCoroutine(MenuPauseClose());
        }
    }

    public void RaidenEXTFastTravel()
    {
        if (pm.raidEXTunlocked)
        {
            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(RaidenEXTMover());
            StartCoroutine(MenuPauseClose());
        }
    }

    public void RaidenINTFastTravel()
    {
        if (pm.raidINTunlocked)
        {
            faderAnim.SetBool("toBlack", true);
            pm.GRANDERLOCK = true;
            StartCoroutine(RaidenINTMover());
            StartCoroutine(MenuPauseClose());
        }
    }

    public void CityShop()
    {
        if (pi.d1)
        {
            StartCoroutine(MenuPauseClose());
            ss.OpenShop();
        }
        else
        {
           
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void CityShop2()
    {
        if (pi.d2)
        {
            StartCoroutine(MenuPauseClose());
            ss2.OpenShop();
        }
        else
        {

            SoundManagerScript.PlaySound("nobuy");
        }

    }

    public void OceangrandShop()
    {
        if (pi.d3)
        {
            StartCoroutine(MenuPauseClose());
            ss3.OpenShop();
        }
        else
        {

            SoundManagerScript.PlaySound("nobuy");
        }

    }

    public void ShoregroveShop()
    {
        if (pi.d4)
        {
            StartCoroutine(MenuPauseClose());
            ss4.OpenShop();
        }
        else
        {
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void ShoregroveShop2()
    {
        if (pi.d5)
        {
            StartCoroutine(MenuPauseClose());
            ss5.OpenShop();
        }
        else
        {

            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void ForeverFluShop()
    {
        if (pi.d6)
        {
          StartCoroutine(MenuPauseClose());
          //ss6.OpenShop();
        }
        else
        {
            SoundManagerScript.PlaySound("nobuy");
        }
    }
    public IEnumerator CityMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = cityFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;

    }
    public IEnumerator BeachTownMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = beachTownFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }

    public IEnumerator RoyalCityMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = royalCityFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }

    public IEnumerator CaveMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = caveFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }

    public IEnumerator WrongNeighborhoodMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = wrongNeighborhoodFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }

    public IEnumerator ColdTownMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = coldTownFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }

    public IEnumerator RaidenEXTMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = raidenEXTFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }

    public IEnumerator RaidenINTMover()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = raidenINTFT.position;
        yield return new WaitForSeconds(1);
        faderAnim.SetBool("toWhite", true);
        faderAnim.SetBool("toBlack", false);
        yield return new WaitForSeconds(1.5f);
        ToIdle();
        pm.GRANDERLOCK = false;
    }


}

