using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript5 : MonoBehaviour
{
    public GameObject GlubGlubUI;
    public GameObject shopUI2;

    public int maxSlimeAttack = 100;
    public float maxSlimeCooldown  = 0.1f;
    public int currentSlimeAttack = 3;
    public float currentSlimeCooldown;
    public PlayerMovement pm;
    public bool shopping;


    public MoneyBank mb;
    public PlayerInteract pi;
    //public ArrowScript aScript;

    public int cost;
    public int cost2;
    public int gCost = 50;
    public int multiplier;
    public Text item1Text;
    public Text item2Text;
    public Text item3Text;
    public int multiplier2;

    public GGBULLETSCRIPT ggbs;
    public GlubGlubScript ggs;

    public bool glubbed;
    public GameObject GlubGlubOWSprite;



    // Start is called before the first frame update
    public void OpenShop()
    {
        if (!glubbed)
        {
            GlubGlubUI.SetActive(true);
            pm.rb.velocity = Vector2.zero;
            shopping = true;
            pm.GRANDERLOCK = true;
        }
        if (glubbed)
        {
            shopUI2.SetActive(true);
            pm.rb.velocity = Vector2.zero;
            shopping = true;
            pm.GRANDERLOCK = true;
        }
        
    }
    public void LoadCost()
    {
        item2Text.text = "$" + cost2.ToString();
        item1Text.text = "$" + cost.ToString();
    }
    public void CloseShop()
    {
        if (!glubbed)
        {
            GlubGlubUI.SetActive(false);
            pm.GRANDERLOCK = false;
        }

        if (glubbed)
        {
            shopUI2.SetActive(false);
            pm.GRANDERLOCK = false;
        }   
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        pi.isShopping = false;
        pm.grandLock = false;
        pm.holdDownTime = 0f;
        pm.shotCharge = 0f;
        shopping = false;
    }

    void Start()
    {
        SetDefs();
        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();
        ggbs = FindObjectOfType<GGBULLETSCRIPT>();
        ggs = FindObjectOfType<GlubGlubScript>();
        item2Text.text = "$" + cost2.ToString();
        item1Text.text = "$" + cost.ToString();
        item3Text.text = "$" + gCost.ToString();

    }

    void Update()
    {// Maybe get rid of this when finished
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && shopping)
        {
            //Change inventory button to be like, b.
            Debug.Log("bs");
            CloseShop();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && shopping && glubbed)
        {
            buySlimeAttack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && shopping && glubbed)
        {
            buySlimeCooldown();
        }

        //Upload The STats
    }

    void SetDefs()
    {
        // mb.Money = cash;
        mb.moneyText.text = "$" + mb.Money;
        //currentSlimeAttack = PlayerPrefs.GetInt("Attack Slime", currentSlimeAttack);
        //currentSlimeCooldown = PlayerPrefs.GetFloat("Attack Slime Cooldown", 0);



    }

    public void buySlimeAttack()
    {
        if (currentSlimeAttack <= maxSlimeAttack)
        {
            if (mb.Money >= cost2)
            {
                mb.Money -= cost2;
                mb.moneyText.text = "$" + mb.Money;

                currentSlimeAttack += 2;
                SoundManagerScript.PlaySound("buy");
                //aScript.damage = currentStrength;
               // PlayerPrefs.SetInt("Attack Slime", currentSlimeAttack);
                Debug.Log("Attack SLime upgraded");
                Debug.Log(mb.Money);
                cost2 *= multiplier2;
                item2Text.text = "$" + cost2.ToString();
            }
            else
            {
                Debug.Log("Not enough money, play SE or summ");
                SoundManagerScript.PlaySound("nobuy");
                Debug.Log(mb.Money);
            }
        }
        else
        {
            Debug.Log("Attack Slime full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void buySlimeCooldown()
    {
        if (ggs.glubCooldown > maxSlimeCooldown)
        {
            if (mb.Money >= cost)
            {
                mb.Money -= cost;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                ggs.glubCooldown -= .3f;
              //  PlayerPrefs.SetFloat("Slime Cooldown", ggs.glubCooldown);
                Debug.Log("Slime Cooldown upgraded");
                Debug.Log(mb.Money);
                cost *= multiplier;
                item1Text.text = "$" + cost.ToString();
            }
            else
            {
                Debug.Log("Not enough money, play SE or summ");
                SoundManagerScript.PlaySound("nobuy");
                Debug.Log(mb.Money);
            }
        }
        else
        {
            Debug.Log("Slime Cooldown full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void buyGlub()
    {
        if (!glubbed)
        {
            if(mb.Money >= cost)
            {
                mb.Money -= cost;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                pm.obtainedGlub = true;
                GlubGlubOWSprite.SetActive(false);
                GlubGlubUI.SetActive(false);
                shopUI2.SetActive(true);
                glubbed = true;

            }
            else
            {
                Debug.Log("no glub flubs");
                SoundManagerScript.PlaySound("nobuy");
                //PLAY SE HERE TOO BOSS!!!!
            }
        }
    }
}
