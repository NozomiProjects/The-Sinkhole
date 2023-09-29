using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dropItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        inventoryUIInteraction draggableItem = dropped.GetComponent<inventoryUIInteraction>();
        slot slot0 = draggableItem.draggedItemParent.GetComponent<slot>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        GameObject droppedItem = Instantiate(slot0.itemInSlot.prefab, player.transform.position+player.transform.forward*2, Quaternion.identity);
        droppedItem.GetComponent<itemObject>().amount = slot0.amountInSlot;
        droppedItem.GetComponent<itemObject>().description = slot0.description;
        slot0.itemInSlot = null;
        slot0.amountInSlot = 0;
    }
}
