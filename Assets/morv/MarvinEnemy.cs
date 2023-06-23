using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarvinEnemy : Enemy
{
    public override void Attack()
    {
        animator.SetTrigger("triggerAttack");
    }

    public override void Charge()
    {
        animator.SetTrigger("triggerCharge");
    }

    public override void ChargeAnimation()
    {
        base.ChargeAnimation();

    }

    public override void Defend()
    {
        animator.SetTrigger("triggerDefend");
    }

    public override void DieAnimation()
    {
        base.DieAnimation();
    }

    public override void EnterAnimation()
    {
        base.EnterAnimation();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.Healthpoints = 10;
    }
}
