using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;



public class slot : MonoBehaviour, IDropHandler   
{
    public items itemInSlot;
    public int amountInSlot;
    public string description;
 

    RawImage icon;                                              

  

    public void SetStats()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);

        }

        icon = GetComponentInChildren<RawImage>();


        if (itemInSlot == null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                
            }

            return;
        }
       
        icon.texture = itemInSlot.icon;

    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        inventoryUIInteraction draggableItem = dropped.GetComponent<inventoryUIInteraction>();
        slot slot0 = draggableItem.draggedItemParent.GetComponent<slot>();

        if (slot0 == this)
            return;
        if (itemInSlot != null)
            return;

        itemInSlot = slot0.itemInSlot;
        amountInSlot = slot0.amountInSlot;
        description = slot0.description;

        slot0.itemInSlot = null;
        slot0.amountInSlot = 0;
        slot0.description = null;

        SetStats();
    }
}
