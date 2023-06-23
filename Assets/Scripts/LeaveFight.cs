using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFight : BaseState
{
    private GameObject Player;

    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        elapsedTime = 0f;
    }
    
    public override void EnterState()
    {
        Debug.Log("Entered LeaveFight State");
        
        Destroy(FightHandler.Instance.enemy);
        StartCoroutine(exitFight());


    }

    public override void UpdateState()
    {
        
    }

    public override void LeaveState()
    {
        
    }

    IEnumerator exitFight()
    {
        if(Manager.Instance.PlayerHp <= 0)
            FightHandler.Instance.ShowDialog("You have lost the battle....\n Pathetic..");
        else
            FightHandler.Instance.ShowDialog("You have defeated the enemy!");

        FightHandler.Instance.enemy.SetActive(false);
        while(elapsedTime <= 2f)
        {
            Debug.Log("In Enumerator " + elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        //Enable player movement
        Player.SetActive(true);
        
        //After the transition to fight is done then switch to Fight state
        AudioManager.Instance.SourceBGM.clip = AudioManager.Instance.DungeonBGM;
        AudioManager.Instance.SourceBGM.Play();

        FightHandler.Instance.CanvasFight.SetActive(false);
    
        //Reset player health
        Manager.Instance.PlayerHp = Manager.Instance.PlayerMaxHealth;
        StateManager.Instance.SwitchState(StateManager.Instance.Map);
        
    }
}
