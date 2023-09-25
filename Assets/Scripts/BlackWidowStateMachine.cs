using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidowStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public State BWManifestationStatus;
    public State BWScreamStatus;

    public State InitialState;
    private State actualState;


    void Start()
    {
        actualState = InitialState;
        actualState.EnterState();
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
