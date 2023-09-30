using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickUpObjects : MonoBehaviour
{
    public itemObject objectToPickUp;
    public itemObject objectPickedUp;
    public CharacterHand characterHand;
    public CharacterCameraRotate characterCameraRotate;
    public Vector3 originalScale;
    public bool grabbedObject = false;
    public float throwingForce = 5;
    public float maxThrowingForce = 40;
    public float forceIncreaseSpeed = 8;
    public bool isChargingThrow = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (isChargingThrow && throwingForce < maxThrowingForce)
        {
            throwingForce += Time.deltaTime * forceIncreaseSpeed; 
        }
    }

    public void GrabObject()
    {
        grabbedObject = true;
        objectPickedUp = objectToPickUp;
        
        objectPickedUp.transform.SetParent(characterHand.transform);
        objectPickedUp.transform.localScale = new Vector3(3f, 3f, 0.6f);
        objectPickedUp.transform.position = characterHand.transform.position;
        objectPickedUp.transform.rotation = characterHand.transform.rotation;
        objectPickedUp.GetComponent<Rigidbody>().useGravity = false;
        objectPickedUp.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void DropObject()
    {
        grabbedObject = false;
        
        objectPickedUp.transform.SetParent(null);
        objectPickedUp.GetComponent<Rigidbody>().useGravity = true;
        objectPickedUp.GetComponent<Rigidbody>().isKinematic = false;
        objectPickedUp = null;
    }

    public void ThrowObject()
    {
        grabbedObject = false;
        
        objectPickedUp.transform.SetParent(null);
        objectPickedUp.GetComponent<Rigidbody>().useGravity = true;
        objectPickedUp.GetComponent<Rigidbody>().isKinematic = false;
        objectPickedUp.GetComponent<Rigidbody>().AddForce(characterCameraRotate.transform.forward * throwingForce, ForceMode.Impulse);
        objectPickedUp = null;
    }
}
