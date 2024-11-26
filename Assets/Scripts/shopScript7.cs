using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class shopScript7 : MonoBehaviour
{
    public GameObject shopUI;
    public PlayerMovement pm;
    public bool shopping;
    public MoneyBank mb;
    public PlayerInteract pi;


    public int cost;
    public Text item1Text;


    //ShopScript7 Exclusive Stuff//

    public Transform spawnSpot;
    public GameObject smallCoin;
    public GameObject biggerCoin;
    public GameObject bigCoin;
    public GameObject rat;
    public GameObject taco;
    public GameObject vineBoomSound;
    public GameObject explosion;

    public bool vbGot;

    public int rngNum;





    // Start is called before the first frame update
    public void OpenShop()
    {    
        shopUI.SetActive(true);
        pm.rb.velocity = Vector2.zero;
        shopping = true;
        pm.GRANDERLOCK = true;    
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        pm.GRANDERLOCK = false;   
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

        pm = FindObjectOfType<PlayerMovement>();
        mb = FindObjectOfType<MoneyBank>();

        item1Text.text = "$" + cost.ToString();
   

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
 
            CloseShop();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && shopping)
        {
            buyGacha();
        }

  
    }

   

    public void buyGacha()
    {
       
        if (mb.Money >= cost)
        {
            mb.Money -= cost;
            mb.moneyText.text = "$" + mb.Money;
            SoundManagerScript.PlaySound("buy");
            RNGGacha();
            CloseShop();

        }
        else
        {
            Debug.Log("not enough moni");
            SoundManagerScript.PlaySound("nobuy");
            //PLAY SE HERE TOO BOSS!!!!
        }
        
    }

    public void RNGGacha()
    {
        rngNum = Random.Range(0, 101);
        if(rngNum <= 30)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            Instantiate(smallCoin, spawnSpot.position, spawnSpot.rotation);
        }
        if(rngNum >= 31 && rngNum <= 50)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            Instantiate(biggerCoin, spawnSpot.position, spawnSpot.rotation);
        }
        if (rngNum >= 51 && rngNum <= 80)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            Instantiate(taco, spawnSpot.position, spawnSpot.rotation);
        }
        if (rngNum >= 81 && rngNum <= 90)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            Instantiate(biggerCoin, spawnSpot.position, spawnSpot.rotation);
        }
        if (rngNum >= 91 && rngNum <= 95)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            Instantiate(rat, spawnSpot.position, spawnSpot.rotation);
        }
        if (rngNum >= 96 && vbGot == false)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            GameObject loot = Instantiate(vineBoomSound, spawnSpot.position, spawnSpot.rotation);
            rngNum = 0;
            vbGot = true;

        }
        if (rngNum >= 96 && vbGot == true)
        {
            SoundManagerScript.PlaySound("boom");
            explosion.SetActive(true);
            GameObject loot = Instantiate(bigCoin, spawnSpot.position, spawnSpot.rotation);
        }

        StartCoroutine(DestroyReset());
    }

    public IEnumerator DestroyReset()
    {
        yield return new WaitForSeconds(0.77f);
        explosion.SetActive(false);
    }
}
