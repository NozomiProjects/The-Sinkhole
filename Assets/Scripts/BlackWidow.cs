using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidow : Enemy
{
    
    protected override void Start()
    {
        base.Start();// Llama al metodo Start de la clase base

        // Inicializa atributos especificos de BlackWidow si es necesario
    }
    void Update()
    {
       
        // Implementa el comportamiento de BlackWidow, como moverse y atacar
        EnemyMove();
        EnemyDie();
    }

    public override void EnemyMove()
    {
        // Logica de movimiento especifica de BlackWidow
    }
    public override void EnemyAttack()
    {
        // Logica de ataque especifica de BlackWidow
    }
    public override void EnemyDie()
    {
        // Logica de movimiento especifica de BlackWidow
    }
}
