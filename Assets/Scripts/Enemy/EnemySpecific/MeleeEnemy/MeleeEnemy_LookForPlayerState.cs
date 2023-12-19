using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_LookForPlayerState : LookForPlayerState {

    private MeleeEnemy mEnemy;

    public MeleeEnemy_LookForPlayerState(FiniteStateMachine stateMachine, Enemy enemy, D_LookForPlayerState stateData, MeleeEnemy mEnemy) : base(stateMachine, enemy, stateData)
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
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(mEnemy.playerDetectiveState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(mEnemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
