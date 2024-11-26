using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public DialogueTrigger dt;
    public Inventory inventory;
    public ShopScript shopScript = null;
    public ShopScript2 shopScript2 = null;
    public ShopScript3 shopScript3 = null;
    public ShopScript4 shopScript4 = null;
    public ShopScript5 shopScript5 = null;
    public ShopScript6 shopScript6 = null;
    public shopScript7 shopScript7 = null;
    public ChestScript chestScript = null;
    public PlayerMovement pm;
    public CinemachineVirtualCamera vcam;
    public bool tutelAnim = false;
    public bool tutelTextAnim = true;
    public Transform tutelObj;
    public Transform playerObj;
    public Animator anim;
    public Animator tutelText;
    public GameObject textBox;
    public GameObject healthText;
    public TutelSongScript tss;
    public bool canInteract = true;
    public bool isShopping = false;
    public bool talking;

    public int ratCount;
    public bool ratting;
    public Text ratText;

    public bool npcInRange;

    public Parrier p;
    public bool parryPointIncreaseUnlocked;
    public bool parryPointIncreaser2Unlocked;
    public ShopScript ss;
    public ShopScript2 ss2;

    public bool d1;
    public bool d2;
    public bool d3;
    public bool d4;
    public bool d5;
    public bool d6;

    public bool interLocked;
   

   

    

    // public GameObject moneyText;
    // public GameObject expTypeBeat;

    private void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        p = FindObjectOfType<Parrier>();
        anim = vcam.GetComponent<Animator>();

    }


    public void Update()
    {
        if (!interLocked)
        {


            if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.F)) && currentInterObj && canInteract == true)
            {
                // Check if object is to be stored in inventory
                if (currentInterObjScript.inventory)
                {
                    inventory.AddItem(currentInterObj);
                    SoundManagerScript.PlaySound("itemSE");
                }

                if (currentInterObjScript.rat && !ratting)
                {
                    currentInterObjScript.RatFade();
                    ratting = true;
                    pm.GRANDERLOCK = true;
                    StartCoroutine(RatSound());
                }

                //Check if object can be opened
                if (currentInterObjScript.openable)
                {
                    if (currentInterObjScript.locked)
                    {
                        //check to see if we have the object needed to unlock
                        //Search our inventory for the item needed if found, unulock object
                        if (inventory.FindItem(currentInterObjScript.itemNeeded))
                        {

                            currentInterObjScript.locked = false;
                            Debug.Log(currentInterObj.name + " was unlocked");


                            //We found the item needed

                        }
                        else
                        {
                            Debug.Log(currentInterObj.name + " was not unlocked");
                        }

                    }
                    else
                    {
                        //object is not locked - open the object
                        Debug.Log(currentInterObj.name + "is open");
                        currentInterObjScript.Open();
                        if (currentInterObjScript.chest)
                        {
                            chestScript.OpenChest();
                        }

                        //currentInterObj.SetActive(false);
                        //Destroy(currentInterObj);

                    }
                }

                if (currentInterObjScript.tutel && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.F)))
                {

                    TutelTime();

                }

                // if (currentInterObjScript.shop && Input.GetKeyDown(KeyCode.Z))
                //  {
                //  isShopping = !isShopping;

                //  if(isShopping == true)
                // {
                //  pm.canMove = false;
                // pm.canShoot = false;
                //  pm.canChargeShot = false;
                //   }
                //   }
                //Check to see if this object talks and has a message
                if (currentInterObjScript.talks)
                {
                    // Tell the object to give its message
                    dt.TriggerDialogue();

                }

                if (currentInterObjScript.egg)
                {
                    pm.LaserUnlock();
                    currentInterObj.SetActive(false);
                    //Sound effect
                }

                if (currentInterObjScript.pearl1)
                {
                    pm.HealUnlock();
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl2)
                {
                    p.ParryPointIncreaserUnlock();
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl3)
                {
                    pm.HealAndSpeedUnlock();
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl4)
                {
                    p.ParryPointIncreaser2Unlock();
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl5)
                {
                    pm.HealAndSpeedAndAttackUnlock();
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl6)
                {
                    pm.mashPotatUnlocked = true;
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl7)
                {
                    pm.BouncyBubbleUnlock();
                    currentInterObj.SetActive(false);
                }
                if (currentInterObjScript.pearl8)
                {
                    pm.VineBoomUnlock();
                    currentInterObj.SetActive(false);
                }

                if (currentInterObjScript.permPowerPotion)
                {
                    SoundManagerScript.PlaySound("itemSE");
                    ss.UpgradeStrength();
                    currentInterObj.SetActive(false);
                }

                if (currentInterObjScript.speedPowerPotion)
                {
                    SoundManagerScript.PlaySound("itemSE");
                    ss2.speedUpgrade();
                    currentInterObj.SetActive(false);
                }

                if (currentInterObjScript.orangePotion)
                {
                    SoundManagerScript.PlaySound("itemSE");
                    p.pCount += 5;
                    currentInterObj.SetActive(false);
                }





                if (currentInterObjScript.shop && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.F)))
                {
                    ShopStuff();
                }
                //Use an item
                if (currentInterObjScript.potion)
                {
                    SoundManagerScript.PlaySound("itemSE");
                    pm.health += 3;
                    pm.healthText.text = pm.health.ToString();
                    currentInterObjScript.DoInteraction();
                }
                if (currentInterObjScript.redPotion)
                {
                   
                    currentInterObjScript.DoInteraction();
                }
                if (currentInterObjScript.bluePotion)
                {
                   
                    currentInterObjScript.DoInteraction();
                }
            }
        }
       
      

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!interLocked)
        {


            if (other.CompareTag("interObject"))
            {

                Debug.Log(other.name);
                currentInterObj = other.gameObject;
                currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
                dt = currentInterObj.GetComponent<DialogueTrigger>();
                shopScript = currentInterObj.GetComponent<ShopScript>();
                shopScript2 = currentInterObj.GetComponent<ShopScript2>();
                shopScript3 = currentInterObj.GetComponent<ShopScript3>();
                shopScript4 = currentInterObj.GetComponent<ShopScript4>();
                shopScript5 = currentInterObj.GetComponent<ShopScript5>();
                shopScript6 = currentInterObj.GetComponent<ShopScript6>();
                shopScript7 = currentInterObj.GetComponent<shopScript7>();
                chestScript = currentInterObj.GetComponent<ChestScript>();
                if (currentInterObjScript.talks)
                {
                    npcInRange = true;
                }



            }
        }

       

      
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

            if (currentInterObjScript.talks)
            {
                npcInRange = false;
            }
        }
    }

    public void CloseUpShop()
    {
        isShopping = false;
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        pm.grandLock = false;
        shopScript.CloseShop();
        
    }

    public void CloseUpShop2()
    {
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        isShopping = false;
        pm.grandLock = false;
        shopScript2.CloseShop();
        
    }

    public void CloseUpShop3()
    {
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        isShopping = false;
        pm.grandLock = false;
        shopScript3.CloseShop();

    }

    public void CloseUpShop4()
    {
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        isShopping = false;
        pm.grandLock = false;
        shopScript4.CloseShop();

    }

    public void CloseUpShop5()
    {
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        isShopping = false;
        pm.grandLock = false;
        shopScript5.CloseShop();

    }

    public void CloseUpShop6()
    {
        pm.canMove = true;
        pm.canShoot = true;
        pm.canChargeShot = true;
        isShopping = false;
        pm.grandLock = false;
        shopScript6.CloseShop();

    }

    public void ButtonUse()
    {
       
            //Check the inventory for a potion
            GameObject potion = inventory.FindItemByType("Health Potion");
            if (potion != null)
            {
                //Use the potion
                //remove the potion from inventory
                Debug.Log("program a thingy to happen here");
                pm.health += 3;
                pm.healthText.text = "Health: " + pm.health.ToString();
                inventory.RemoveItem(potion);
            }
        
    }

    private void SetBoolBack()
    {
        tutelAnim = !tutelAnim;
    }

    public void TutelTime()
    {
        tutelAnim = !tutelAnim;


        if (tutelAnim)
        {
            textBox.SetActive(true);
            vcam.Follow = tutelObj;
            tss.playSong();
            tutelText = currentInterObj.GetComponentInChildren<Animator>(); // Gets the animation for the zooming in text????
            Debug.Log("tutel!!!!");
            pm.canMove = false;
            pm.canShoot = false;
            pm.canChargeShot = false;
            anim.SetBool("canPlay", true);
            tutelText.SetBool("canReset", true);
            healthText.SetActive(false);
            // moneyText.SetActive(false);
            //expTypeBeat.SetActive(false);
        }
        else
        {
            vcam.Follow = playerObj;
            Debug.Log("back to normal?");
            tss.noPlaySong();
            pm.canMove = true;
            pm.canShoot = true;
            pm.canChargeShot = true;
            pm.grandLock = false;
            anim.SetBool("canPlay", false);
            tutelText.SetBool("canReset", false);
            textBox.SetActive(false);
            healthText.SetActive(true);
            //   moneyText.SetActive(true);
            //  expTypeBeat.SetActive(true);
        }
    }

    public void ShopStuff()
    {
        isShopping = true;

        if (currentInterObj.name == "Shopkeeper")
        {
            Debug.Log("yes");
            shopScript.OpenShop();
            d1 = true;
            
        }
        if (currentInterObj.name == "Shopkeeper2")
        {
            Debug.Log("yes");
            shopScript2.OpenShop();
            d2 = true;
           
        }
        if (currentInterObj.name == "Shopkeeper3")
        {
            Debug.Log("yes");
            shopScript3.OpenShop();
            d3 = true;
           
        }
        if (currentInterObj.name == "Shopkeeper4")
        {
            Debug.Log("yes");
            shopScript4.OpenShop();
            d4 = true;

            
        }
        if (currentInterObj.name == "Shopkeeper5")
        {
            Debug.Log("yes");
            shopScript5.OpenShop();
            d5 = true;
            
        }
        if (currentInterObj.name == "Shopkeeper6")
        {
            Debug.Log("yes");
            shopScript6.OpenShop();
            d6 = true;
           
        }
        if (currentInterObj.name == "Shopkeeper7")
        {
            Debug.Log("yes");
            shopScript7.OpenShop();

        }
    }

    public IEnumerator RatSound()
    {
        yield return new WaitForSeconds(0.72f);
        SoundManagerScript.PlaySound("rat");
    }
}

