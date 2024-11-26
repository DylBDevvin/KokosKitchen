using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript3 : MonoBehaviour
{
    public GameObject shopUI2;
    public float maxMoneyMult = 100;
    public float maxXpMult = 100;
    public float currentMoneyMult = 1;
    public float currentXpMult = 1;
    public bool shopping;
    public PlayerMovement pm;
    public LevelSystem ls;

    public MoneyBank mb;

    public PlayerInteract pi;
    //public ArrowScript aScript;

    public int cost;
    public int cost2;
    public int multiplier;
    public Text item1Text;
    public Text item2Text;
    public int multiplier2;



    // Start is called before the first frame update
    public void OpenShop()
    {
        shopUI2.SetActive(true);
        pm.rb.velocity = Vector2.zero;
        shopping = true;
        pm.GRANDERLOCK = true;
    }

    public void LoadCost()
    {
        item2Text.text = "$" + cost2.ToString();
        item1Text.text = "$" + cost.ToString();
    }
    public void CloseShop()
    {
        shopUI2.SetActive(false);
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        pi.isShopping = false;
        pm.grandLock = false;
        pm.holdDownTime = 0f;
        shopping = false;
        pm.shotCharge = 0f;
        pm.GRANDERLOCK = false;
    }

    void Start()
    {
        SetDefs();
        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();
        ls = FindObjectOfType<LevelSystem>();

        item2Text.text = "$" + cost2.ToString();
        item1Text.text = "$" + cost.ToString();
        //aScript = FindObjectOfType<ArrowScript>();


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
        if (Input.GetKeyDown(KeyCode.Alpha2) && shopping)
        {
            buyMoneyMult();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && shopping)
        {
            buyXPMult();

        }

        mb.moneyMult = currentMoneyMult;
        ls.XPMult = currentXpMult;
    }

    void SetDefs()
    {
        // mb.Money = cash;
        mb.moneyText.text = "$" + mb.Money;
       // currentMoneyMult = PlayerPrefs.GetFloat("M Mult", 1);
       // currentXpMult = PlayerPrefs.GetFloat("XP Mult", 1);



    }

    public void buyMoneyMult()
    {
        if (currentMoneyMult <= maxMoneyMult)
        {
            if (mb.Money >= cost2)
            {
                mb.Money -= cost2;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentMoneyMult += 0.1f;
                //aScript.damage = currentStrength;
               // PlayerPrefs.SetFloat("M Mult", currentMoneyMult);
                Debug.Log("M Mult upgraded");
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
            Debug.Log("M Mult full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void buyXPMult()
    {
        if (currentXpMult < maxXpMult)
        {
            if (mb.Money >= cost)
            {
                mb.Money -= cost;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentXpMult += .25f;
               // PlayerPrefs.SetFloat("XP Mult", currentXpMult);
                Debug.Log("XP Mult upgraded");
                Debug.Log(mb.Money);
                cost *= multiplier;
                item1Text.text = "$" + cost.ToString();
            }
            else
            {
                Debug.Log("Not enough money, play SE or summ");
                Debug.Log(mb.Money);
                SoundManagerScript.PlaySound("nobuy");
            }
        }
        else
        {
            Debug.Log("XP Mult full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }
}
