using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFight : BaseState
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        
    }
    
    public override void EnterState()
    {
        Debug.Log("Entered LeaveFight State");
        
        //TODO Pass background, music etc to fighthandler

        //Enable player movement
        Player.SetActive(true);
        
        //Reset player health
        Manager.Instance.PlayerHp = Manager.Instance.PlayerMaxHealth;
        
        //After the transition to fight is done then switch to Fight state
        FightHandler.Instance.CanvasFight.SetActive(false);
        Destroy(FightHandler.Instance.enemy);
        StateManager.Instance.SwitchState(StateManager.Instance.Map);

        
    }

    public override void UpdateState()
    {
        
    }

    public override void LeaveState()
    {
        
    }
}
