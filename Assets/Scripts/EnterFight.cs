using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFight : BaseState
{
    public GameObject enemy;

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
        Debug.Log("YOU HAVE TO PUT AN ENEMY INSIDE THE PARAMETER");
    }

    public override void EnterStateWithEnemy(GameObject enemy = null)
    {
        Debug.Log("Starting fight with enemy " + enemy.name);
        this.enemy = enemy;
        
        //TODO Pass Enemy, background, music etc to fighthandler
        FightHandler.Instance.enemy = enemy;
        FightHandler.Instance.EnterFight();
            
        Player.SetActive(false);
        
    }

    public override void UpdateState()
    {

    }

    public override void LeaveState()
    {

    }
}
