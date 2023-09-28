using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWScreamStatus : MonoBehaviour
{
    //cuando el personaje esta a una distancia de 10f 
    //la bruja corre hacia el por 2 segundos y desaparece
    public Transform player;
    public float startMoveDistance = 10.0f;
    public float moveSpeed = 18.0f;
    public float moveDuration = 0.3f;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= startMoveDistance)
        {
           StartCoroutine(MoveAndDisappear());
        }
    }

    private IEnumerator MoveAndDisappear()
{
    // Guarda la pos inicial de la bruja
    Vector3 initialPosition = transform.position;

    // Calcula la pos final hacia adelante 
    Vector3 targetPosition = transform.position + transform.forward * moveSpeed * moveDuration;

    // Inicia el movimiento hacia adelante
    float startTime = Time.time;
    while (Time.time - startTime < moveDuration)
    {
        // Calcula la posicion intermedia durante el movimiento
        float t = (Time.time - startTime) / moveDuration;
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        yield return null;
    }

    // Desactiva el objeto de la bruja desp del mov
    gameObject.SetActive(false);
}
}
