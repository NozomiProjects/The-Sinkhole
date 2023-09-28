using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidow : MonoBehaviour
{
    public BWManifestationStatus bwManifestationStatus;
    public BWSeductionStatus bwSeductionStatus;
    public GameObject zone1;
    public GameObject zone2;
    private bool isInZone1 = false;
    private bool isInZone2 = false;
    void Start()
    {
        
        // Inicializa atributos especificos de BlackWidow si es necesario
        bwManifestationStatus = GetComponent<BWManifestationStatus>();
        bwSeductionStatus = GetComponent<BWSeductionStatus>();
        // Verifica las zonas y activa el comportamiento
        CheckZoneAndActivateScript();
    }
    private void CheckZoneAndActivateScript()
    {
        bool activateManifestation = IsInZone("Zone1");
        bool activateSeduction = IsInZone("Zone2");
        if (activateManifestation)
        {
            // BlackWidow esta en la Zona1
            isInZone1 = true;
            bwManifestationStatus.StartManifestation();
        }
        else
        {
            // BlackWidow no esta en la Zona1
            isInZone1 = false;
            
        }
        if (activateSeduction)
        {
            // BlackWidow esta en la Zona1
            isInZone2 = true;
            bwSeductionStatus.StartSeduction();
        }
        else
        {
            // BlackWidow no esta en la Zona1
            isInZone2 = false;
            
        }
    }

    private bool IsInZone(string zoneTag)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); //Crea esfera invisible en el espacio alrededor del objeto que pertenece a este script con radio1
        //Collider[] colliders almacena todos los colisionadores (colliders) de los objetos que estan dentro de la esfera 
        foreach (Collider collider in colliders) //recorre todos los collider que estan dentro de la esfera
        {
            if (collider.CompareTag(zoneTag)) //verifica si el collider actual tiene una etiqueta (tag) que coincida con el valor de zoneTag.
            {
                return true; //Si encuentra un collider con la etiqueta correcta, el codigo devuelve true
            }
        }
        return false; //no se encontro ningun objeto en la zona deseada
    }
    // Metodo para activar el comportamiento de ManifestationStatus
    public void StartManifestation()
    {
        if (bwManifestationStatus != null && isInZone1)
        {
            bwManifestationStatus.StartManifestation();
        }
    }
    
    // Metodo para activar el comportamiento de SeductionStatus
    public void StartSeduction()
    {
        if (bwSeductionStatus != null && isInZone2)
        {
            bwSeductionStatus.StartSeduction();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Detecta si entra en una zona
        if (other.CompareTag("Zone1"))
        {
            isInZone1 = true;
            CheckZoneAndActivateScript();
            
        }
        else if (other.CompareTag("Zone2"))
        {
            isInZone2 = true;
            CheckZoneAndActivateScript();
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        // Detecta si sale de una zona
        if (other.CompareTag("Zone1"))
        {
            isInZone1 = false;
        }
        else if (other.CompareTag("Zone2"))
        {
            isInZone2 = false;
        }
      
    }


}
