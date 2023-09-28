using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWSeductionStatus : MonoBehaviour
{
    public GameObject modelPrefab; //Modelo original
    public GameObject seductionModelPrefab; //Modelo seduction
    private GameObject actualModel; //Modelo actual
    private bool isChangingModel = false;
    private float modelChangeTimer = 0f;

    public event Action SeductionStarted; // Evento que notifica el inicio de Seduction
    
    // Logica de inicializacion
    void Start()
    {
        actualModel = Instantiate(modelPrefab, transform.position, transform.rotation); //Instancio modelo original
        actualModel.transform.parent = transform; //El modelo actual es hijo del objeto (BW) que contiene este script
    }

    // Logica de entrada del estado
    public void StartSeduction()
    {
        isChangingModel = false;
        modelChangeTimer = 0f; // Reiniciar el temporizador
    }

    // Logica de actualizacion del estado
    public void UpdateSeduction()
    {
        // Verifica si se debe cambiar de modelo
        if (!isChangingModel){
            modelChangeTimer += Time.deltaTime; // Incrementa el temporizador

            // Si han transcurrido 3 segundos, cambia al modelo
            if (modelChangeTimer >= 3f){
                ChangeToSeductionModel(); // Cambia al modelo de seduccion
                isChangingModel = true; // Establece isChangingModel como verdadero para evitar cambios
            }
        }

    }

    // Metodo para cambiar al modelo de seduccion
    public void ChangeToSeductionModel()
    {
        Destroy(actualModel); // Destruye el modelo actual

        // Instancia el modelo de seduccion en lugar del original
        actualModel = Instantiate(seductionModelPrefab, transform.position, transform.rotation);
        actualModel.transform.parent = transform;

        // Notificar que Seduction ha comenzado
        SeductionStarted?.Invoke();
    }

}
