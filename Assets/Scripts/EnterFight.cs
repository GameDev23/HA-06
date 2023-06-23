using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFight : BaseState
{


    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Player " + Player.name);
        //Disable playermovement
        Player.SetActive(false);
        Manager.Instance.Player.SetActive(false);
        Debug.Log("Entered EnterFight State");
        
        //TODO Pass background, music etc to fighthandler
        FightHandler.Instance.EnterFight();


        
        //After the transition to fight is done then switch to Fight state
        StateManager.Instance.SwitchState(StateManager.Instance.Fight);
        
    }
    

    public override void UpdateState()
    {

    }

    public override void LeaveState()
    {

    }
}
