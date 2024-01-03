using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossAwakeState : BossAwakeState
{
    public BossMechaGolem sBoss;

    public BossMechaGolem_BossAwakeState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossAwakeState stateData) : base(stateMachine, sBoss, stateData)
    {
        this.sBoss= sBoss;
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

    public override void FinishAwake()
    {
        base.FinishAwake();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isFinish)
        {
            sBoss.stateMachine.ChangeState(sBoss.normalState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
