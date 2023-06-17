using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : BaseState
{
    public bool isPlayerTurn = true;
    
    
    private Enemy enemy;
    private bool isButtonsToggle = false;
    private Animator animator;
    
    public override void EnterState()
    {
        Debug.Log("Entered Fight State");
        enemy = FightHandler.Instance.enemy.GetComponent<Enemy>();
        Debug.Log(enemy.name);

        animator = FightHandler.Instance.enemy.GetComponent<Animator>();

        //Set initial turn to players turn
        isPlayerTurn = true;
    }

    public override void UpdateState()
    {
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        if (!isPlayerTurn)
        {
            Debug.Log("Enemy Turn");
            //disable buttons so that player cant attack during enemies turn
            ToggleButtons(false);
            enemy.Attack();
            isPlayerTurn = true;
            isButtonsToggle = false;
        }
        else if (isPlayerTurn && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Idle")
        {
            
            ToggleButtons(true);
            Debug.Log("its player turn");
            if (Input.GetKeyDown(KeyCode.K))
            {
                //TODO IMPLEMENT ACTIONS FROM BUTTONS
                isPlayerTurn = false;
                isButtonsToggle = false;
            }
        }



    }

    public override void LeaveState()
    {

    }

    public void ToggleButtons(bool state)
    {
        if(isButtonsToggle)
        {
            return;
        }
        FightHandler.Instance.AttackButton.enabled = state;
        FightHandler.Instance.DefendButton.enabled = state;
        FightHandler.Instance.HealButton.enabled = state;
        FightHandler.Instance.RunButton.enabled = state;
        isButtonsToggle = true;
    }
}
