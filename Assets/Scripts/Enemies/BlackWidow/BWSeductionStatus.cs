using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWSeductionStatus : State
{
    public GameObject modelPrefab; //Modelo original
    public GameObject seductionModelPrefab; //Modelo seduction
    private GameObject actualModel; //Modelo actual
    private bool isChangingModel = false;
    private float modelChangeTimer = 0f;
    
    // Logica de inicializacion
    protected override void Start()
    {
        base.Start(); // Llama al metodo Start de la clase base Enemy
        actualModel = Instantiate(modelPrefab, transform.position, transform.rotation); //Instancio modelo original
        actualModel.transform.parent = transform; //El modelo actual es hijo del objeto (BW) que contiene este script
    }

    // Logica de entrada del estado
    public override void EnterState()
    {
        isChangingModel = false;
        modelChangeTimer = 0f; // Reiniciar el temporizador
    }

    // Logica de actualizacion del estado
    public override void UpdateState()
    {
        // Verifica si se debe cambiar de modelo
        if (!isChangingModel){
            modelChangeTimer += Time.deltaTime; // Incrementa el temporizador

            // Si han transcurrido 5 segundos, cambia al modelo
            if (modelChangeTimer >= 5f){
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
    }

    // Logica de salida del estado
    public override void ExitState()
    {   
    }
}
