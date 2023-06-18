using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Schmumpkin : Enemy
{

    public GameObject ChargeSystem;
    public GameObject LampSystem;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        this.Healthpoints = 15;
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
        StartCoroutine(AttackRoutine());
    }

    public override void Defend()
    {
        animator.SetTrigger("triggerDefend");
    }

    public override void Charge()
    {
        animator.SetTrigger("triggerCharge");
        StartCoroutine(ChargeRoutine());
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

    IEnumerator ChargeRoutine()
    {
        
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Charge"))
        {
            yield return null;
        }
        
        //End of charging  now do dmg
        if (!Manager.Instance.isPlayerDefending)
            Manager.Instance.PlayerHp -= Manager.Instance.PlayerHp;
        Manager.Instance.isPlayerDefending = false;
    }

    IEnumerator AttackRoutine()
    {
        
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            yield return null;
        }
        
        
        //End of charging  now do dmg
        int rand = Random.Range(1, 4);
        if (!Manager.Instance.isPlayerDefending)
            Manager.Instance.PlayerHp = Manager.Instance.PlayerHp - rand < 0 ? 0 : Manager.Instance.PlayerHp - rand;
        Manager.Instance.isPlayerDefending = false;
    }
}
