using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidowZoneController : MonoBehaviour
{
    public BWManifestationStatus bwManifestationStatus;
    
    private void Start()
    {
        bwManifestationStatus = GetComponent<BWManifestationStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zone1"))
        {
            // La Viuda Negra esta en la Zona 1, activa el comportamiento de manifestación
            bwManifestationStatus.StartManifestation();
        }
    }
}
