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

    public void StartCryAnimation()
    {
        // Inicia la anima de seduction
        animator.SetTrigger("cry");
    }
    /* public void StopSeductionAnimation()
    {
        // Detiene la anim
        animator.ResetTrigger("seduction"); // Resetear el trigger o configurar como desees
    } */
    public void StartScreamAnimation()
    {
        // Inicia la anim "scream" 
        animator.SetBool("IsScreaming", true);
    }

    public void StopScreamAnimation()
    {
        // Detiene la anim "scream"
        animator.SetBool("IsScreaming", false);
    }
}
