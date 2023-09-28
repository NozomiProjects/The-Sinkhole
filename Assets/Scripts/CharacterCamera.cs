using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Transform cam;
    public float speedCam = 350;

    private void Start()
    {
        cam = this.transform;   
    }
}
