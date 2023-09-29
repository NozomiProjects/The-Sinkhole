using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWSeductionStatus : MonoBehaviour
{
    public Transform player;
    public float cryStartDistance = 35.0f;
    //public float cryStopDistance = 5.0f;
    public float disappearDistance = 5.0f; //distancia de desaparicion
    
    //cuadno el jugador se acerque deja de hacer animaxcion y desaparece
    private Animator animator;
    private bool isSeducing = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= cryStartDistance)
        {
            if (!isSeducing)
            {
                Debug.Log("Iniciando anim de atraccion");
                GetComponent<EnemyAnimator>().StartCryAnimation();
                isSeducing = true;
            }
            // Verifica si el jugador esta dentro de la distancia de desaparicion
            if (distanceToPlayer <= disappearDistance)
            {
                // Si el jugador esta dentro de la distancia de desaparicion, desactiva el objeto de BlackWidow.
                gameObject.SetActive(false);
            }
        }
        /* else if (distanceToPlayer > cryStopDistance && isSeducing)
        {
            Debug.Log("Deteniendo anim de cryn");
            GetComponent<EnemyAnimator>().StopCryAnimation();
            isSeducing = false;
        } */
    }

}
