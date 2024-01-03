using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_AngryState : BossNormalState
{
    public BossMechaGolem sBoss;

    public BossMechaGolem_AngryState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossNormalState stateData) : base(stateMachine, sBoss, stateData)
    {
        this.sBoss = sBoss;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        if (!isLookAtPlayer)
        {
            sBoss.Flip();
        }

        if (Time.time > attackStartTime + stateData.timeBetweenAttack)
        {
            attackStartTime = Time.time;
            stateMachine.ChangeState(sBoss.areaAttackState);
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
