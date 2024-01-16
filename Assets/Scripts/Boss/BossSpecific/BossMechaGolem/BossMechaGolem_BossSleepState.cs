using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossSleepState : BossSleepState
{
    public BossMechaGolem sBoss;

    public BossMechaGolem_BossSleepState(FiniteStateMachine stateMachine, BossMechaGolem boss, D_BossSleepState stateData) : base(stateMachine, boss, stateData)
    {
        this.sBoss = boss;
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
        if (isPlayerDetected)
        {
            sBoss.stateMachine.ChangeState(sBoss.awakeState);
            
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
