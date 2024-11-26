using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopScript2 : MonoBehaviour
{
    public GameObject shopUI2;
    public float maxSpeed;
    public float maxCooldown;
    public float currentSpeed;
    public float currentCooldown;
    public PlayerMovement pm;
    public PlayerInteract pi;
    public bool shopping;

    public MoneyBank mb;
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
        shopping = false;
        pm.canChargeShot = true;
        pm.grandLock = false;
        pi.isShopping = false;
        pm.holdDownTime = 0f;
        pm.shotCharge = 0f;
        pm.GRANDERLOCK = false;
    }

    void Start()
    {
        SetDefs();
        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();

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
            buySpeed();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && shopping)
        {
            buyCooldown();

        }
    }

    void SetDefs()
    {
        // mb.Money = cash;
        mb.moneyText.text = "$" + mb.Money;
       // currentSpeed = PlayerPrefs.GetInt("Speed", 0);
        //currentCooldown = PlayerPrefs.GetFloat("Cooldown", 0);
        


    }

    public void buySpeed( )
    {
        if (currentSpeed <= maxSpeed)
        {
            if (mb.Money >= cost2)
            {
                mb.Money -= cost2;
                mb.moneyText.text = "$" + mb.Money;
                SoundManagerScript.PlaySound("buy");
                currentSpeed += 0.3f;
                //aScript.damage = currentStrength;
               // PlayerPrefs.SetInt("Speed", currentSpeed);
                Debug.Log("Speed upgraded");
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
            Debug.Log("Speed full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void buyCooldown()
    {
        if (currentCooldown < maxCooldown)
        {
            if (mb.Money >= cost)
            {
                mb.Money -= cost;
                mb.moneyText.text = "$" + mb.Money;
                currentCooldown += .025f;
                SoundManagerScript.PlaySound("buy");
                //PlayerPrefs.SetFloat("Cooldown", currentCooldown);
                Debug.Log("Cooldown upgraded");
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
            Debug.Log("Cooldown full, play a SE here or summ");
            SoundManagerScript.PlaySound("nobuy");
        }
    }

    public void speedUpgrade()
    {   
        if (currentSpeed <= maxSpeed)
        {
            currentSpeed += 0.18f;
            //aScript.damage = currentStrength;
            //PlayerPrefs.SetInt("Speed", currentSpeed);
            Debug.Log("Speed upgraded");
        }
        else
        {
            SoundManagerScript.PlaySound("nobuy");
        }
    }
}
