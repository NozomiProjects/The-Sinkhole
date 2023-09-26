using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWManifestationStatus : State
{
    //public GameObject BWPrefab;
    private GameObject BWInstance;

    public float manifestationDuration = 3f; //Duracion de la manifestacion
    private float manifestationTimer = 0f; //Temporizador para rastrear el tiempo de la manifestacion
    private bool isManifested = false; //Indica si la manifestacion esta ocurriendo o no

    public Transform[] WayPoints;//Este array contiene los waiPoints
    
    // Logica de inicializacion
    protected override void Start()
    {
        base.Start(); // Llama al metodo Start de la clase base Enemy
    }
    public override void EnterState()
    {
        manifestationTimer = 0f;
        isManifested = false;
        ManifestBlackWidow(); 
    }

    public override void UpdateState()
    {
        if (isManifested)
        {
           manifestationTimer += Time.deltaTime;

           if(manifestationTimer >= manifestationDuration)
           {
            DisappearBlackWidow();
            manifestationTimer = 0f; // Reiniciar el temporizador
            ManifestBlackWidow();
           } 
        }   
    }
    // Logica de salida del estado
    public override void ExitState()
    {   
    }

    //Metodo para manifestar a BlackWidow
    private void ManifestBlackWidow()
    {
        if (WayPoints.Length > 0)
        {
            int randomSpawnIndex = Random.Range(0, WayPoints.Length); //variable int que genera un num entero aleatorio, dentro del rango de puntos disponibles
            Transform WayPoint = WayPoints[randomSpawnIndex];
            
            if(BWInstance == null){
                BWInstance = GameObject.Find("BlackWidow"); //Si BWInstance es nulo, busca el objeto de BlackWidow en la escena y la coloca
            }
            
            if(BWInstance != null){
                BWInstance.SetActive(true); // Activa a BlackWidow en escena
                BWInstance.transform.position = WayPoint.position; // Mueve BlackWidow en posicion del waypoint
                BWInstance.transform.rotation = WayPoint.rotation; // Mueve BlackWidow en rotacion del waypoint
            }
            isManifested = true;
        }
    }

    //Metodo para desaparecer a BlackWidow
    private void DisappearBlackWidow()
    {
        BWInstance.SetActive(false); //BlackWidow en escena y desactivado
        isManifested = false; // Cambiar a falso para que pueda manifestarse de nuevo en el siguiente ciclo
    }
}
