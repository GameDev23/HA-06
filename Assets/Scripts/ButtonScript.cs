using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void OnAttack()
    {
        if(Manager.Instance.isPlayerTurn && FightHandler.Instance.enemy.GetComponent<Enemy>().animator.GetBool("isIdle"))
        {
            Debug.Log(FightHandler.Instance.enemy.name + " has " + FightHandler.Instance.enemy.GetComponent<Enemy>().Healthpoints + " HP");
        
            //start hit animation
            FightHandler.Instance.enemy.GetComponent<Enemy>().animator.SetBool("isIdle", false);
            FightHandler.Instance.enemy.GetComponent<Enemy>().animator.SetTrigger("triggerHit");
            
        
            //Decrease enemy hp
            int rand = Random.Range(1, 4);
            FightHandler.Instance.enemy.GetComponent<Enemy>().Healthpoints =
                FightHandler.Instance.enemy.GetComponent<Enemy>().Healthpoints - rand <= 0
                    ? 0
                    : FightHandler.Instance.enemy.GetComponent<Enemy>().Healthpoints - rand;
            
            //change turn to enemy
            Manager.Instance.isPlayerTurn = false;
        }
    }

    public void OnDefend()
    {
        if(Manager.Instance.isPlayerTurn && FightHandler.Instance.enemy.GetComponent<Enemy>().animator.GetBool("isIdle"))
        {
            //change turn to player
            Manager.Instance.isPlayerTurn = false;
            Manager.Instance.isPlayerDefending = true;
        }
        
    }

    public void OnHeal()
    {
        Debug.Log("Healing");
        if(Manager.Instance.isPlayerTurn && FightHandler.Instance.enemy.GetComponent<Enemy>().animator.GetBool("isIdle"))
        {
            Debug.Log(Manager.Instance.isPlayerTurn);
            int HealAmount = 5;
            Manager.Instance.PlayerHp = Manager.Instance.PlayerHp + HealAmount > Manager.Instance.PlayerMaxHealth
                ? Manager.Instance.PlayerMaxHealth
                : Manager.Instance.PlayerHp + HealAmount;
            FightHandler.Instance.ShowDialog("Healed " + HealAmount + " HP");
            Manager.Instance.isPlayerTurn = false;
        }
    }

    public void OnRun()
    {
        StateManager.Instance.SwitchState(StateManager.Instance.LeaveFight);
    }
}
