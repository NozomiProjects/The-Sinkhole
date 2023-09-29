using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CordureSystem : MonoBehaviour
{
    public Image cordureStatus;
    public float cordureActual;
    public float cordureMax;

    void Update()
    {
        cordureStatus.fillAmount = cordureActual / cordureMax;

    }
    public void LessCordure()
    {
        cordureActual -= 10;
        if (cordureActual < 0)
        {
            // grito y muero
        }
    }

}