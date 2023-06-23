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
        isAnimation = true;
        animator.SetTrigger("triggerAttack");
        StartCoroutine(AttackRoutine());
    }

    public override void Charge()
    {
        isAnimation = true;
        animator.SetTrigger("triggerCharge");
        StartCoroutine(ChargeRoutine());

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
        
        Manager.Instance.isPlayerTurn = true;
        //End of charging  now do dmg
        if (!Manager.Instance.isPlayerDefending)
            Manager.Instance.PlayerHp -= Manager.Instance.PlayerHp;
        Manager.Instance.isPlayerDefending = false;
        Debug.Log("Players turn");
        isAnimation = false;

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
        
        Manager.Instance.isPlayerTurn = true;
        //End of charging  now do dmg
        int rand = Random.Range(1, 4);
        if (!Manager.Instance.isPlayerDefending)
            Manager.Instance.PlayerHp = Manager.Instance.PlayerHp - rand < 0 ? 0 : Manager.Instance.PlayerHp - rand;
        Manager.Instance.isPlayerDefending = false;
        Debug.Log("Players turn");
        isAnimation = false;

    }


}
