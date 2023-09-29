using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraRotate : MonoBehaviour
{
    public CharacterInput characterInput;
    public CharacterCamera characterCamera;
    public CharacterPickUpObjects characterPickUpObjects;
    public float camRotate;

    private void Update()
    {
        //camRotate -= characterInput.mouseY * characterCamera.speedCam * Time.deltaTime;
        //camRotate = Mathf.Clamp(camRotate, -75, 75);
        //characterCamera.cam.localRotation = Quaternion.Euler(new Vector3(camRotate, 0, 0));

        if (characterPickUpObjects.grabbedObject == true)
        {
            camRotate -= characterInput.mouseY * characterCamera.speedCam * Time.deltaTime;
            camRotate = Mathf.Clamp(camRotate, -75, 35);
            characterCamera.cam.localRotation = Quaternion.Euler(new Vector3(camRotate, 0, 0));
        }
        else
        {
            camRotate -= characterInput.mouseY * characterCamera.speedCam * Time.deltaTime;
            camRotate = Mathf.Clamp(camRotate, -75, 75);
            characterCamera.cam.localRotation = Quaternion.Euler(new Vector3(camRotate, 0, 0));
        }
    }
}
