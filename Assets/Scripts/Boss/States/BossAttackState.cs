using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState {
    protected Transform attackPosition;

    protected bool isAnimationFinish;
    public BossAttackState(FiniteStateMachine stateMachine, string animBoolName, Boss boss, Transform attackPosition) : base(stateMachine, animBoolName, boss)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        isAnimationFinish = false;
        boss.atsm.attackState = this;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationFinish= true;
    }
}
