using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWManifestationStatus : State
{
    public GameObject BWPrefab;

    public float manifestationDuration = 2f; //Duracion de la manifestacion
    private float manifestationTimer = 0f; //Temporizador para rastrear el tiempo de la manifestacion
    private bool isManifested = false; //Es6ta siendo manifestada en falso

    //public List<Transform> spawnPoints; //Lista de puntos de aparicion
    /* [SerializeField]
    private Transform[] WayPoints; */
    public Transform[] WayPoints;//Este array contiene los waiPoints
    private GameObject currentBWInstance; // Variable para mantener una referencia a la instancia actual
    
    protected override void Start()
    {
        // Logica de inicializacion especifica de BWManifestationStatus
        base.Start(); // Llama al metodo Start de la clase base
    }
    public override void EnterState()
    {
        manifestationTimer = 0f;
        isManifested = false;

        //Metodo para manifestar viuda
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

    public override void ExitState()
    {
        
    }
    private void ManifestBlackWidow()
    {
        if (WayPoints.Length > 0)
        {
            int ramdomSpawnIndex = Random.Range(0, WayPoints.Length);
            Transform WayPoint = WayPoints[ramdomSpawnIndex];
            
            // Destruir la instancia actual si existe
            if (currentBWInstance != null)
            {
                Destroy(currentBWInstance);
            }

            currentBWInstance = Instantiate(BWPrefab, WayPoint.position, WayPoint.rotation);

            isManifested = true;
        }
    }
    private void DisappearBlackWidow()
    {
        // Destruir la instancia actual si existe
        if (currentBWInstance != null)
        {
            Destroy(currentBWInstance);
        }
        
        isManifested = false; // Cambiar a falso para que pueda manifestarse de nuevo en el siguiente ciclo
    }
}
