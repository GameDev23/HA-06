using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolperdinger : Enemy
{
    private void Awake()
    {
        if(animator == null)
            animator = gameObject.GetComponentInChildren<Animator>();

    }
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
        base.Defend();
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


}
