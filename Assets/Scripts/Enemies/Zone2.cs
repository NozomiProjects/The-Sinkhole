using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone2 : MonoBehaviour
{
    public event Action ViudaEnterZoneEvent2;

    public void OnViudaEnterZone()
    {
        ViudaEnterZoneEvent2?.Invoke();
    }
}
