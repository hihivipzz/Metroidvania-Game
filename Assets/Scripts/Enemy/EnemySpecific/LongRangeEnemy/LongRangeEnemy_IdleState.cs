using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_IdleState : IdleState
{
    private LongRangeEnemy lREnemy;

    public LongRangeEnemy_IdleState(FiniteStateMachine stateMachine, Enemy enemy, D_IdleState stateData, LongRangeEnemy lREnemy) : base(stateMachine, enemy, stateData)
    {
        this.lREnemy= lREnemy;
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(lREnemy.playerDetectiveState);
        }

        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(lREnemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
