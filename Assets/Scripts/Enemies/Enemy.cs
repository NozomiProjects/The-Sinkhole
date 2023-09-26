using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{

    protected virtual void Start()
    {
        // Inicializa atributos comunes de los enemigos si es necesario
    }

    public virtual void EnemyMove()
    {
        // Implementa el movimiento comun para todos los enemigos
    }

    public virtual void EnemyAttack()
    {
        // Implementa el ataque comun para todos los enemigos
    }

    public virtual void EnemyDie()
    {
        // Implementa la muerte comun para todos los enemigos
    }
}
