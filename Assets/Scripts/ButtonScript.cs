using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void OnAttack()
    {
        
    }

    public void OnDefend()
    {
        
    }

    public void OnHeal()
    {
        
    }

    public void OnRun()
    {
        StateManager.Instance.SwitchState(StateManager.Instance.LeaveFight);
    }
}
