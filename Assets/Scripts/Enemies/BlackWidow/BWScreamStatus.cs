using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWScreamStatus : State
{
    

    public override void EnterState()
    {
        Debug.Log("Viuda entra en estado Scream");
    }
    public override void UpdateState()
    {
        // Logica de actualizacion del estado Scream
        // Esto se ejecutara en cada fotograma mientras este en este estado
    }

    public override void ExitState()
    {
        Debug.Log("Viuda sale del estado Scream.");
    }
}
