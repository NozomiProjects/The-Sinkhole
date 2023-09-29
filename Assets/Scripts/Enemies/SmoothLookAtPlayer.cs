using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtPlayer : MonoBehaviour
{
    public CharacterCamera characterCamera;
    public float speed = 5f;

    private void Update()
    {
        if (characterCamera != null)
        {
            Vector3 direction = characterCamera.cam.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
}
