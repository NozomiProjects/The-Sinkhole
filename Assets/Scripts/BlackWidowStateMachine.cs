using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWidowStateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    private IState BWScreamStatus;
    private IState actualState;


    /* void Start()
    {
        ChangeState(new BWScreamStatus());
    } */

    // Update is called once per frame
    void Update()
    {
        if (actualState != null)
        {
            actualState.UpdateState();
        }
    }

   /*  public void ChangeStatus(IState newState){
        if(actualState != null){
            actualState.ExitState();
        }
        actualState = newState;
        actualState.EnterState();
    } */
}
