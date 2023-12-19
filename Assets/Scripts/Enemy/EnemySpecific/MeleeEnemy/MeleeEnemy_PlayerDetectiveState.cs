using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_PlayerDetectiveState : PlayerDetectiveState {
    private MeleeEnemy mEnemy;

    public MeleeEnemy_PlayerDetectiveState(FiniteStateMachine stateMachine, Enemy enemy,  D_PlayerDetectiveState stateData,MeleeEnemy mEnemy) : base(stateMachine, enemy,  stateData)
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

        if (performShortRangeAction)
        {
            stateMachine.ChangeState(mEnemy.meleeAttackState);
        }
        else if(performLongRangeAction)
        {
            stateMachine.ChangeState(mEnemy.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(mEnemy.lookForPlayerState);
        }
        else if(isDetectedLedge)
        {
            //
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
