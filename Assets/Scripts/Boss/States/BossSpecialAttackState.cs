using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttackState : BossAttackState {
    protected D_BossSpecialAttackState stateData;
    protected bool isDamaging;
    protected float lastPlayerDamagedTime;
    protected AttackDetails attackDetails;

    public BossSpecialAttackState(FiniteStateMachine stateMachine, Boss boss, D_BossSpecialAttackState stateData,Transform attackPosition) : base(stateMachine, stateData.animBoolName, boss, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        attackDetails.position = boss.transform.position;
        attackDetails.damageAmount = stateData.dame;
        isDamaging = false;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        if(isDamaging)
        {
            damePlayerOverTime();
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        isDamaging= true;
    }

    public virtual void damePlayerOverTime()
    {
       
    }
}
