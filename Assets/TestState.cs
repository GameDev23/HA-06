using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : BaseState
{
    public override void EnterState()
    {
        Debug.Log("Entering State TestState" );
    }

    public override void UpdateState()
    {
    }

    public override void LeaveState()
    {
        Debug.Log("Leave State TestState");
    }
}
