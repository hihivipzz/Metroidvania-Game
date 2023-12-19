using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_ChargeState : ChargeState
{
    private MeleeEnemy mEnemy;

    public MeleeEnemy_ChargeState(FiniteStateMachine stateMachine, Enemy enemy, D_ChargeState stateData, MeleeEnemy mEnemy) : base(stateMachine, enemy, stateData)
    {
        this.mEnemy = mEnemy;
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

        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(mEnemy.meleeAttackState);
        }

        else if (!isDetectedLedge || isDetectedWall)
        {
            stateMachine.ChangeState(mEnemy.lookForPlayerState);
        }else if (isChargeTimeOver)
        {
            
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(mEnemy.playerDetectiveState);
            }
            else
            {
                stateMachine.ChangeState(mEnemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
