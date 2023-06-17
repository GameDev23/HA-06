using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    #region Methods
    // Called when state is entered
    
    public virtual void EnterState()
    {

    }
    

    // Called when in state, to check for actions within
    public virtual void UpdateState()
    {

    }

    // Called when leaving the state
    public virtual void LeaveState()
    {

    }
    #endregion

}
