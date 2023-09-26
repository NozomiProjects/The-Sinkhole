using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidowStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public State BWManifestationStatus;
    public State BWScreamStatus;
    public State BWSeductionStatus;

    public State InitialState;
    private State actualState;


    void Start()
    {
        if (BWManifestationStatus != null && BWScreamStatus != null && BWSeductionStatus != null && InitialState != null)
            {
                actualState = InitialState;
                actualState.EnterState();
            }
        else
        {
            Debug.LogError("Alguna referencia no esta asignada en el Inspector.");
        }
    }

    public void ChangeState(State newState)
    {
        if (actualState != null)
        {
            actualState.ExitState();
        }

        actualState = newState;
        actualState.EnterState();
    }

    void Update()
    {
        if (actualState != null)
        {
            actualState.UpdateState();
        }
    }
}
