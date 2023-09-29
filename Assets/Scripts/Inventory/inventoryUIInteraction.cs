using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class inventoryUIInteraction : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject clickedItemUI;

    public Transform draggedItemParent;
    public Transform draggedItem;
    public CordureSystem cordure;

  
    public Light flashlight;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.GetComponent<slot>().itemInSlot == null)
            return;

        print("Begin Drag");
        draggedItemParent = transform;
        draggedItem = draggedItemParent.GetComponentInChildren<RawImage>().transform;
        draggedItemParent.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        draggedItem.parent = FindObjectOfType<Canvas>().transform;
  
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerClick.GetComponent<slot>().itemInSlot == null || clickedItemUI.activeInHierarchy)
            return;
        print("Dragging");
        draggedItem.position = Input.mousePosition;
        draggedItem.GetComponent<RawImage>().raycastTarget = false;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        

        draggedItem.parent = draggedItemParent;
        draggedItem.localPosition = new Vector3(0, 0, 0);
        draggedItem.GetComponent<RawImage>().raycastTarget = true;
        draggedItemParent.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        draggedItemParent.GetComponent<slot>().SetStats();
        draggedItem = null;
        draggedItemParent = null;
        print("End Drag ");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.pointerClick.GetComponent<slot>().itemInSlot == null || clickedItemUI.activeInHierarchy)
                return;
            
            clickedItemUI.transform.position = Input.mousePosition + new Vector3(clickedItemUI.GetComponent<RectTransform>().rect.width * 1.5f / 2 + 1, -(clickedItemUI.GetComponent<RectTransform>().rect.height * 1.5f / 2 - 1), 0);
            clickedItemUI.GetComponent<clickedItem>().clickedSlot = eventData.pointerClick.GetComponent<slot>();
            clickedItemUI.SetActive(true);
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (eventData.pointerClick.GetComponent<slot>().itemInSlot == null || clickedItemUI.activeInHierarchy)
                return;


            switch (eventData.pointerClick.GetComponent<slot>().itemInSlot.id)
            {
                case 0:
                    print("Battery Recharged");
                    flashlight.intensity = 7;
                    eventData.pointerClick.GetComponent<slot>().itemInSlot = null;
                    eventData.pointerClick.GetComponent<slot>().amountInSlot = 0;
                    eventData.pointerClick.GetComponent<slot>().SetStats();
                    eventData.pointerClick.GetComponent<slot>().description = null;
                    break;
                case 1:                  
                    
                    break;
                case 2:
                    break;
                case 3:
                    cordure.cordureActual = 1000;
                    eventData.pointerClick.GetComponent<slot>().itemInSlot = null;
                    eventData.pointerClick.GetComponent<slot>().amountInSlot = 0;
                    eventData.pointerClick.GetComponent<slot>().SetStats();
                    eventData.pointerClick.GetComponent<slot>().description = null;
                    break;
            }
                        
        }
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        clickedItemUI.SetActive(false);
    }

    
}
