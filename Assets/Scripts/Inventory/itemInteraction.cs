using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemInteraction : MonoBehaviour
{
    Transform cam;
    [SerializeField] LayerMask itemLayer;
    inventorySystem invSystem;

    [SerializeField] TextMeshProUGUI txtHoveredItem;
    [SerializeField] CharacterPickUpObjects pickupScript;

    private void Start()
    {
        cam = Camera.main.transform;
        invSystem = GetComponent<inventorySystem>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 2, itemLayer))
        {
            if (!hit.collider.GetComponent<itemObject>())
                return;

            if(hit.collider.GetComponent<itemObject>().itemStats.id == 1)
            {
                if (!pickupScript.grabbedObject)
                {
                    txtHoveredItem.text = $"Presiona 'E' para recoger {hit.collider.GetComponent<itemObject>().itemStats.name}";
                }
                else
                {
                    txtHoveredItem.text = "Ya tienes una roca en la mano";
                }
                    
            }
            else
            {
                txtHoveredItem.text = $"Presiona 'E' para recoger {hit.collider.GetComponent<itemObject>().itemStats.name}";
            }
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.GetComponent<itemObject>().itemStats.id == 1)
                {
                    if (pickupScript.grabbedObject == false)
                    {
                        pickupScript.objectToPickUp = hit.collider.GetComponent<itemObject>();
                        pickupScript.GrabObject();
                        
                    }
                    else
                        return;                   
                }
                else
                {
                    invSystem.pickUpItem(hit.collider.GetComponent<itemObject>());
                }
            }

        }
        else
        {
            txtHoveredItem.text = string.Empty;
        }
 
    }
}

