using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : BaseState
{
    
    
    
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
        Manager.Instance.isPlayerTurn = true;
    }

    public override void UpdateState()
    {
        //Get current Playerhealth
        FightHandler.Instance.HpBar.fillAmount = (float) Manager.Instance.PlayerHp / (float) Manager.Instance.PlayerMaxHealth;
        FightHandler.Instance.HpTextMesh.text = "HP " + Manager.Instance.PlayerHp;
        FightHandler.Instance.EnemyHP.text = "HP " + enemy.Healthpoints;

        if (enemy.Healthpoints <= 0)
        {
            //TODO exit fight because player has defeated enemy
            enemy.DieAnimation();
            StateManager.Instance.SwitchState(StateManager.Instance.LeaveFight);
        }
        if (Manager.Instance.PlayerHp <= 0)
        {
            //TODO SHOW DEFEATED SCREEN
            
            StateManager.Instance.SwitchState(StateManager.Instance.LeaveFight);
        }
        
        //if enemy has turn
        if (!Manager.Instance.isPlayerTurn && animator.GetBool("isIdle"))
        {
            //disable buttons so that player cant attack during enemies turn
            ToggleButtons(false);
            enemy.Attack();
            Manager.Instance.isPlayerTurn = true;
            isButtonsToggle = false;
        }
        //if player has turn
        else if (Manager.Instance.isPlayerTurn && animator.GetBool("isIdle"))
        {
            
            ToggleButtons(true);
            if (Input.GetKeyDown(KeyCode.K))
            {
                //TODO IMPLEMENT ACTIONS FROM BUTTONS
                Manager.Instance.isPlayerTurn = false;
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
