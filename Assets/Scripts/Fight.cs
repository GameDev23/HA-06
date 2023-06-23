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
            Debug.Log("enemy defeated leaving");
            enemy.DieAnimation();
            StateManager.Instance.SwitchState(StateManager.Instance.LeaveFight);
        }
        if (Manager.Instance.PlayerHp <= 0)
        {
            //TODO SHOW DEFEATED SCREEN
            Debug.Log("player defeated");

            StateManager.Instance.SwitchState(StateManager.Instance.LeaveFight);
        }
        
        //if enemy has turn
        if (!Manager.Instance.isPlayerTurn && animator.GetBool("isIdle"))
        {
            //disable buttons so that player cant attack during enemies turn
            ToggleButtons(false);
            //check if enemy is charging otherwise get next attack
            if (Manager.Instance.isEnemyCharging)
            {
                //Make charge attack
                enemy.Charge();
                FightHandler.Instance.ShowDialog("TAKE THIS!!! \n-" + enemy.name.Replace("(Clone)", ""));
                Manager.Instance.isEnemyCharging = false;
                
                
            }
            else
            {
                //get percentage to decide wether to attack or to charge
                int attackIndex = Random.Range(0, 100);
                if (attackIndex <= 66)
                {
                    //Make Normal Attack
                    Debug.Log("Enemy is attacking");
                    FightHandler.Instance.ShowDialog("Take this you Wurst \n-" + enemy.name.Replace("(Clone)", ""));
                    enemy.Attack();
                }
                else
                {
                    //Enemy charges
                    Debug.Log("Enemy is charging");
                    FightHandler.Instance.ShowDialog("Time to prepare my Charged attack... \n-" + enemy.name.Replace("(Clone)", ""));
                    Manager.Instance.isEnemyCharging = true;
                
                }
            }
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
