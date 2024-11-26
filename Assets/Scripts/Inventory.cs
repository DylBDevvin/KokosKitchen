using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject[] inventory = new GameObject[10];
    public Button[] InventoryButtons = new Button[10];
    public string itemName;
    
    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        // Find first open spot in inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + "was added");
                //Update UI
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;

                itemAdded = true;
                // Do something with the object
                item.SendMessage("DoInteraction");
                break;

            }
        }

        //Inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
               

                //We found the item
                return true;
            }
        }
        //item not found
        return false;
    }

    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            { 
            if (inventory[i].GetComponent<InteractionObject>().itemType == itemType)
            {
                //We found an item of the type we were looking for
                return inventory[i];
            }
        }
    }
        
        //item of type not found
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {

            if (inventory[i] == item)
            {
                //We found an item of the type we were looking for so remove it
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");
                //Update UI

                InventoryButtons[i].image.overrideSprite = null;
                break;
                
            }
        }
    }
}
