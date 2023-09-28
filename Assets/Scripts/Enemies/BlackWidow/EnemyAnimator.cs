using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartSeductionAnimation()
    {
        // Inicia la anima de seduction
        animator.SetTrigger("seduction");
    }
    /* public void StopSeductionAnimation()
    {
        // Detiene la anim
        animator.ResetTrigger("seduction"); // Resetear el trigger o configurar como desees
    } */
}
