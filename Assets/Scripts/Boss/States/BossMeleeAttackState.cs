using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttackState : BossAttackState {
    protected D_BossMeleeAttackState stateData;
    protected AttackDetails attackDetails;

    public BossMeleeAttackState(FiniteStateMachine stateMachine,  Boss boss, D_BossMeleeAttackState stateData,Transform attackPosition) : base(stateMachine, stateData.animBoolName, boss, attackPosition)
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
        attackDetails.damageAmount = stateData.attackDame;
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
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
