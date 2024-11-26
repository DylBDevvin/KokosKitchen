using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    public GameObject shopUI;
    public int maxStrength, maxExp;
    public int currentStrength, currentExp;

    public float exp = 100f;

    public bool shopping;

    public MoneyBank mb;
    public LevelSystem ls;
    public PlayerMovement pm;
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
        shopUI.SetActive(true);
        pm.rb.velocity = Vector2.zero;
        pm.GRANDERLOCK = true;

        shopping = true;
    }

   public void CloseShop()
    {
        shopUI.SetActive(false);
        
        pm.canMove = true;
        pm.canShoot = true;
        shopping = false;
        pm.canChargeShot = true;
        pi.isShopping = false;
        pm.grandLock = false;
        pm.holdDownTime = 0f;
        pm.shotCharge = 0f;
        pm.GRANDERLOCK = false;
    }

    void Start()
    {
        SetDefs();

        mb = FindObjectOfType<MoneyBank>();
        ls = FindObjectOfType<LevelSystem>();
        pm = FindObjectOfType<PlayerMovement>();

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
            buyStrength();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && shopping)
        {
            buyEXP();

        }
    }

    void SetDefs()
    {
        // mb.Money = cash;
        mb.moneyText.text = "$" + mb.Money;
        //currentStrength = PlayerPrefs.GetInt("Damage", 1);
        //currentExp = PlayerPrefs.GetInt("exp", 0);


    }

    public void buyStrength()
    {
        if(currentStrength <= maxStrength)
        {
            if (mb.Money >= cost2)
            {
                mb.Money -= cost2;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentStrength += 1;
                //aScript.damage = currentStrength;
              //  PlayerPrefs.SetInt("Damage", currentStrength);
                Debug.Log("Strength upgraded");
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

            Debug.Log("Strength full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
            //Make the text be MAXED or something
        }
    }

    public void buyEXP()
    {
        if (currentExp < maxExp)
        {
            if (mb.Money >= cost)
            {
                mb.Money -= cost;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentExp += 1;
                ls.GainExperienceFlatRate(exp);
               // PlayerPrefs.SetInt("exp", currentExp);
                Debug.Log("Exp upgraded");
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
            Debug.Log("Exp full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void UpgradeStrength()
    {
        if (currentStrength <= maxStrength)
        {
            currentStrength += 1;
           // PlayerPrefs.SetInt("Damage", currentStrength);
            SoundManagerScript.PlaySound("buy");
        }
        else
        {
            Debug.Log("Strength full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void LoadCost()
    {
        item2Text.text = "$" + cost2.ToString();
        item1Text.text = "$" + cost.ToString();
    }

}
