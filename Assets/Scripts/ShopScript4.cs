using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript4 : MonoBehaviour
{
    public GameObject shopUI2;
    public int maxPcount = 100;
    public float maxDmult = 100f;
    public int currentPcount;
    public float currentDmult = 2;
    public PlayerMovement pm;
    public bool shopping;
    public MoneyBank mb;
    public PlayerInteract pi;
    //public ArrowScript aScript;
    public int cost;
    public int cost2;
    public int multiplier;
    public Text item1Text;
    public Text item2Text;
    public int multiplier2;
    

    public Parrier p;





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
        pm.holdDownTime = 0f;
        pm.shotCharge = 0f;
        shopping = false;
        pm.GRANDERLOCK = false;
    }

    void Start()
    {
        SetDefs();
        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();
        item1Text.text = "$" + cost.ToString();
        item2Text.text = "$" + cost2.ToString();
        p = FindObjectOfType<Parrier>();

        maxPcount = 100;
        maxDmult = 100f;
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
            buyDmult();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && shopping)
        {
            buyPcount();

        }

        p.maxPcount = currentPcount;




    }

    void SetDefs()
    {
        // mb.Money = cash;
        mb.moneyText.text = "$" + mb.Money;
       // currentDmult = PlayerPrefs.GetFloat("Current D Mult", 2);
       // currentPcount = PlayerPrefs.GetInt("Current P Count", 5);



    }

    public void buyDmult()
    {



        if (currentDmult <= maxDmult)
        {
            if (mb.Money >= cost2)
            {
                mb.Money -= cost2;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentDmult += 0.20f;
                //aScript.damage = currentStrength;
               // PlayerPrefs.SetFloat("Current D Mult", currentDmult);
                Debug.Log("Current D Mult upgraded");
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
            Debug.Log("Current D Mult full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }



    }

    public void buyPcount()
    {


        if (currentPcount < maxPcount)
        {
            if (mb.Money >= cost)
            {
                mb.Money -= cost;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentPcount += 2;
               // PlayerPrefs.SetInt("Current P Count", currentPcount);
                Debug.Log("Current P Count upgraded");
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
            Debug.Log("Current P Count full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }


    }
}
