using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapState : BaseState
{
    public override void EnterState()
    {
        Debug.Log("Entering State MapState" );
    }
    

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StateManager.Instance.SwitchState(StateManager.Instance.Test);
        }
    }

    public override void LeaveState()
    {
        Debug.Log("Leave State MapState");
    }
}
