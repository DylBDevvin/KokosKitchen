using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript6 : MonoBehaviour
{
    public GameObject shopUI2;
    public int maxSpeed;
    public float maxCooldown;
    public int currentSpeed;
    public float currentCooldown;
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



    // Start is called before the first frame update
    public void OpenShop()
    {
        shopUI2.SetActive(true);
        pm.rb.velocity = Vector2.zero;
        shopping = true;
    }

    public void CloseShop()
    {
        shopUI2.SetActive(false);
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        pm.grandLock = false;
        pi.isShopping = false;
        pm.holdDownTime = 0f;
        pm.shotCharge = 0f;
        shopping = false;
    }

    void Start()
    {
        SetDefs();
        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();
        //aScript = FindObjectOfType<ArrowScript>();


    }

    void Update()
    {// Maybe get rid of this when finished
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void SetDefs()
    {
        // mb.Money = cash;
        mb.moneyText.text = "$" + mb.Money;
        currentSpeed = PlayerPrefs.GetInt("Speed", 0);
        currentCooldown = PlayerPrefs.GetFloat("Cooldown", 0);



    }

    public void buySpeed(int price)
    {
        if (currentSpeed <= maxSpeed)
        {
            if (mb.Money >= price)
            {
                mb.Money -= price;
                mb.moneyText.text = "$" + mb.Money;

                currentSpeed += 99;
                //aScript.damage = currentStrength;
                PlayerPrefs.SetInt("Speed", currentSpeed);
                Debug.Log("Speed upgraded");
                Debug.Log(mb.Money);
            }
            else
            {
                Debug.Log("Not enough money, play SE or summ");
                Debug.Log(mb.Money);
            }
        }
        else
        {
            Debug.Log("Speed full, play a SE here or summ");
        }
    }

    public void buyCooldown(int price)
    {
        if (currentCooldown < maxCooldown)
        {
            if (mb.Money >= price)
            {
                mb.Money -= price;
                mb.moneyText.text = "$" + mb.Money;
                currentCooldown += .99f;
                PlayerPrefs.SetFloat("Cooldown", currentCooldown);
                Debug.Log("Cooldown upgraded");
                Debug.Log(mb.Money);
            }
            else
            {
                Debug.Log("Not enough money, play SE or summ");
                Debug.Log(mb.Money);
            }
        }
        else
        {
            Debug.Log("Cooldown full, play a SE here or summ");
        }
    }
}
