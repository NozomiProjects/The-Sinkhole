using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWScreamStatus : IState
{
    // Start is called before the first frame update
    private BlackWidowStateMachine blackWidowStateMachine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public BWScreamStatus(BlackWidowStateMachine blackWidowStateMachine){
        this.blackWidowStateMachine = blackWidowStateMachine;
    }

    public void EnterState()
    {
        Debug.Log("Viuda entra en estado Scream");
    }
    public void UpdateState()
    {
        // Logica de actualizacion del estado Scream
        // Esto se ejecutara en cada fotograma mientras este en este estado
    }

    public void ExitState()
    {
        Debug.Log("Viuda sale del estado Scream.");
    }
}
