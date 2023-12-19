using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_MoveState : MoveState {

    private LongRangeEnemy lREnemy;
    
    public LongRangeEnemy_MoveState(FiniteStateMachine stateMachine, Enemy enemy, D_MoveState stateData,LongRangeEnemy lREnemy ) : base(stateMachine, enemy, stateData)
    {
        this.lREnemy = lREnemy;
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

        if (isDetectingWall || !isDetectingLedge)
        {
            lREnemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(lREnemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
