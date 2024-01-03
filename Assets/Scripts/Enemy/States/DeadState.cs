using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadState : EnemyState
{
    protected D_DeadState stateData;

    public DeadState(FiniteStateMachine stateMachine, Enemy enemy, D_DeadState stateData) : base(stateMachine, enemy, stateData.animBoolName)
    {
        this.stateData = stateData;
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
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
