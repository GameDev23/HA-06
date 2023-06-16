using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFight : BaseState
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("YOU HAVE TO PUT AN ENEMY INSIDE THE PARAMETER");
    }

    public override void EnterStateWithEnemy(Enemy enemy = null)
    {
        Debug.Log("Starting fight with enemy " + enemy.name);
        this.enemy = enemy;
    }

    public override void UpdateState()
    {

    }

    public override void LeaveState()
    {

    }
}
