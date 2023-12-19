using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_IdleState : IdleState
{
    private MeleeEnemy mEnemy;

    public MeleeEnemy_IdleState(FiniteStateMachine stateMachine, Enemy enemy,  D_IdleState stateData, MeleeEnemy mEnemy) : base(stateMachine, enemy,  stateData)
    {
        this.mEnemy= mEnemy;
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

        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(mEnemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
