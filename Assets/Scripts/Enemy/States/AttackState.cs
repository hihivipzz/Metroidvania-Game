using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    protected Transform attackPosition;

    protected bool isAnimationFinish;
    protected bool isPlayerInMinAgroRange;

    public AttackState(FiniteStateMachine stateMachine, Enemy enemy, string animBoolName,Transform attackPosition) : base(stateMachine, enemy, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.atsm.attackState = this; 
        isAnimationFinish = false;
        enemy.SetVelocity(0);
        enemy.SetApplyKnockBack(false);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetApplyKnockBack(true);
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
        enemy.SetApplyKnockBack(true);
    }

    public virtual void FinishAttack() 
    {
        isAnimationFinish= true;
    }
}
