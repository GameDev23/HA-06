using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schmumpkin : Enemy
{
    
    private Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        animator.SetTrigger("triggerAttack");
    }

    public override void Defend()
    {
        animator.SetTrigger("triggerDefend");
    }

    public override void Charge()
    {
        animator.SetTrigger("triggerCharge");
    }

    public override void EnterAnimation()
    {
        base.EnterAnimation();
    }

    public override void ChargeAnimation()
    {
        base.ChargeAnimation();
    }

    public override void DieAnimation()
    {
        base.DieAnimation();
    }
}
