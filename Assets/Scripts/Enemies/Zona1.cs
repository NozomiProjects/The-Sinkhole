using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona1 : MonoBehaviour
{
    public event Action ViudaEnterZoneEvent;

    public void OnViudaEnterZone()
    {
        ViudaEnterZoneEvent?.Invoke();
    }
}
