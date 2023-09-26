using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour, IState
{
    protected BlackWidowStateMachine blackWidowStateMachine;

    protected virtual void Start()
    {
        blackWidowStateMachine = GetComponent<BlackWidowStateMachine>();
    }

    public virtual void EnterState()
    {
        // Implementa la entrada al estado
    }

    public virtual void UpdateState()
    {
        // Implementa la actualizacion del estado
    }

    public virtual void ExitState()
    {
        // Implementa la salida del estado
    }
}
