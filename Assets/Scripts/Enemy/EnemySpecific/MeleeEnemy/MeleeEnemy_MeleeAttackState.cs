using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_MeleeAttackState : MeleeAttackState
{
    MeleeEnemy mEnemy;

    public MeleeEnemy_MeleeAttackState(FiniteStateMachine stateMachine, Enemy enemy, Transform attackPosition, D_MeleeAttackState stateData,MeleeEnemy mEnemy) : base(stateMachine, enemy, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinish)
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
