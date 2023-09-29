using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour
{
    [SerializeField] public slot[] slots = new slot[40];
    [SerializeField] GameObject inventoryUI;
        
   

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemInSlot == null)
            {
                for (int k = 0; k < slots[i].transform.childCount; k++)
                {
                    slots[i].transform.GetChild(k).gameObject.SetActive(false); 
                }
            }
        }
    }

    private void Update()
    {
        if (!inventoryUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Tab))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            inventoryUI.SetActive(true);
           
        }
         else if(inventoryUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            inventoryUI.SetActive(false);
            
        }
    }

    public void pickUpItem(itemObject obj)
    {
        
        
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemInSlot != null && slots[i].itemInSlot.id == obj.itemStats.id && slots[i].amountInSlot != slots[i].itemInSlot.maxStack)
                {
                    if (!willHitMaxStack(i, obj.amount))
                    {
                        slots[i].amountInSlot += obj.amount;
                        slots[i].SetStats();
                        slots[i].description = obj.description;
                        Destroy(obj.gameObject);
                        return;
                    }
                    else
                    {
                        int result = neededToFill(i);
                        obj.amount = remainingAmount(i, obj.amount);
                        slots[i].amountInSlot += result;
                        slots[i].SetStats();
                        slots[i].description = obj.description;
                        pickUpItem(obj);
                        return;
                    }
                }
                else if (slots[i].itemInSlot == null)
                {
                    slots[i].itemInSlot = obj.itemStats;
                    slots[i].amountInSlot += obj.amount;
                    slots[i].SetStats();
                    slots[i].description = obj.description;
                    Destroy(obj.gameObject);
                    return;
                }
            }
        
    }

    bool willHitMaxStack(int index, int amount)
    {
        if (slots[index].itemInSlot.maxStack <= slots[index].amountInSlot + amount)
            return true;
        else 
            return false;
    }

    int neededToFill(int index)
    {
        return slots[index].itemInSlot.maxStack - slots[index].amountInSlot;
    }

    int remainingAmount(int index, int amount)
    {
        return (slots[index].amountInSlot + amount) - slots[index].itemInSlot.maxStack;
    }
}
