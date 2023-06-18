using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Schmumpkin : Enemy
{
    
    
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        this.Healthpoints = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        animator.SetTrigger("triggerAttack");
        int rand = Random.Range(1, 4);
        Manager.Instance.PlayerHp = Manager.Instance.PlayerHp - rand < 0 ? 0 : Manager.Instance.PlayerHp - rand;
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
