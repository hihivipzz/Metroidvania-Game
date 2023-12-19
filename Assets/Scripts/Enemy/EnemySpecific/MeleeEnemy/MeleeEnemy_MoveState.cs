using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_MoveState : MoveState {

    private MeleeEnemy mEnemy;

    public MeleeEnemy_MoveState(FiniteStateMachine stateMachine, Enemy enemy,  D_MoveState stateData,MeleeEnemy mEnemy) : base(stateMachine, enemy, stateData)
    {
        this.mEnemy = mEnemy;
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
            stateMachine.ChangeState(mEnemy.playerDetectiveState);
        }

        if(isDetectingWall || !isDetectingLedge)
        {
            mEnemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(mEnemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
