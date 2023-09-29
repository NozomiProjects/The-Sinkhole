using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWManifestationStatus : MonoBehaviour
{

    public Transform[] WayPoints;//Este array contiene los waiPoints
    //public GameObject BWPrefab;
    private GameObject BWInstance;

    public float manifestationDuration = 2f; //Duracion de la manifestacion
    private float manifestationTimer = 1f; //Temporizador para rastrear el tiempo de la manifestacion
    private bool isManifested = false; //Indica si la manifestacion esta ocurriendo o no

    private int currentWaypointIndex = 0; // Mantiene un seguimiento del indice del Waypoint actual
    //Metodo de inicializacion
    public void Start()
    {
 
    }

    //Metodo para manifestar a BlackWidow
    public void StartManifestation()
    {
        if (!isManifested && WayPoints.Length > 0)
        {
            int randomSpawnIndex = UnityEngine.Random.Range(0, WayPoints.Length); //variable int que genera un num entero aleatorio, dentro del rango de puntos disponibles
            Transform WayPoint = WayPoints[randomSpawnIndex];
            
            if(BWInstance == null)
            {
                BWInstance = GameObject.Find("BlackWidow-M"); //Si BWInstance es nulo, busca el objeto de BlackWidow en la escena y la coloca
            }
            
            if(BWInstance != null)
            {
                BWInstance.SetActive(true); // Activa a BlackWidow en escena
                BWInstance.transform.position = WayPoint.position; // Mueve BlackWidow en posicion del waypoint
                BWInstance.transform.rotation = WayPoint.rotation; // Mueve BlackWidow en rotacion del waypoint
                isManifested = true;
                manifestationTimer = 0f; //Temporizador de manifestacion
            }
            
        }
    }
    // Metodo para activar el evento de estado de manifestacion
    /* private void InvokeManifestationEvent()
    {
        ManifestationStatusEvent?.Invoke();
    } */
    //Metodo de actualizacion
    public void Update()
    {
        if (isManifested)
        {
            manifestationTimer += Time.deltaTime;

            if (manifestationTimer >= manifestationDuration)
            {
                MoveToNextWaypoint(); 
                manifestationTimer = 0f;
            }
        }
    }

    private void MoveToNextWaypoint()
    {
        if (WayPoints.Length == 0)
        {
            return; // No hay Waypoints, no hay movimiento.
        }

    currentWaypointIndex = (currentWaypointIndex + 1) % WayPoints.Length; // Avanzar al siguiente Waypoint o volver al primero si llegamos al final

    Transform nextWaypoint = WayPoints[currentWaypointIndex];
    
        if (BWInstance != null)
        {
            BWInstance.transform.position = nextWaypoint.position; // Mover BlackWidow al siguiente Waypoint
            BWInstance.transform.rotation = nextWaypoint.rotation; // Actualizar la rotacian si es necesario
        }
    }

    //Metodo para desaparecer a BlackWidow
    public void DisappearBlackWidow()
    {
        if(BWInstance != null)
        {
            BWInstance.SetActive(false); //Desaparece a BlackWidow
            isManifested = false; // Cambiar a falso para que pueda manifestarse de nuevo en el siguiente ciclo
        }
        // Llama a StartManifestation para la proxima manifestacion
        //StartManifestation();
    }
}
