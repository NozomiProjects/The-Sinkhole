using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidow : MonoBehaviour
{
    public BWManifestationStatus bwManifestationStatus;
    public GameObject zone1;
    private bool isInZone1 = false;

    void Start()
    {
        // Inicializa atributos especificos de BlackWidow si es necesario
        bwManifestationStatus = GetComponent<BWManifestationStatus>();
        // Verifica las zonas y activa el comportamiento
        CheckZoneAndActivateScript();
    }
    private void CheckZoneAndActivateScript()
    {
        bool activateManifestation = IsInZone("Zone1");
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

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si entra en una zona
        if (other.CompareTag("Zone1"))
        {
            isInZone1 = true;
            CheckZoneAndActivateScript();
            
        }
        else 
        {
            isInZone1 = false;

        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        // Detecta si sale de una zona
        if (other.CompareTag("Zone1"))
        {
            isInZone1 = false;
        }
      
    }


}
