using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour
{
    public CharacterInput characterInput;
    public CharacterCamera characterCamera;

    private void LateUpdate()
    {
        transform.Rotate(new Vector3(0, characterInput.mouseX, 0) * characterCamera.speedCam * Time.deltaTime);
    }
}
