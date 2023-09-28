using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidowZoneController : MonoBehaviour
{
    public BWManifestationStatus bwManifestationStatus;
    public BWSeductionStatus bwSeductionStatus;
    
    private void Start()
    {
        bwManifestationStatus = GetComponent<BWManifestationStatus>();
        bwSeductionStatus = GetComponent<BWSeductionStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zone1"))
        {
            // La Viuda Negra esta en la Zona 1, activa el comportamiento de manifestación
            bwManifestationStatus.StartManifestation();
        }
        else if (other.CompareTag("Zone2"))
        {
            // La Viuda Negra esta en la Zona 2, activa el comportamiento de seducción
            bwSeductionStatus.StartSeduction();
        }
    }
}
