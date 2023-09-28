using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public CharacterJump characterJump;
    //public ObjectToGrab objectToGrab;
    //public CharacterPickableObject characterPickableObject;
    public CharacterPickUpObjects characterPickUpObjects;
    //public ObjectInRange objectInRange;
    public float mouseX, mouseY;
    public float x, y;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (characterJump.canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterJump.Jump();
            }
        }


        if (characterPickUpObjects.objectPickedUp != null && Cursor.lockState == CursorLockMode.Locked)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                characterPickUpObjects.DropObject();
            }
        }

        if (characterPickUpObjects.grabbedObject == true && Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked)
        {
            characterPickUpObjects.isChargingThrow = true;
        }

        if (characterPickUpObjects.grabbedObject == true && Input.GetMouseButtonUp(0) && Cursor.lockState == CursorLockMode.Locked)
        {
            characterPickUpObjects.isChargingThrow = false;
            characterPickUpObjects.ThrowObject();
            characterPickUpObjects.throwingForce = 4;
        }

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        characterMovement.Movement();
    }
}
