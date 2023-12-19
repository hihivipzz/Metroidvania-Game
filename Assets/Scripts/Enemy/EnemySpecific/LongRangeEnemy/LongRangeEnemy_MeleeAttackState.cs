using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_MeleeAttackState : MeleeAttackState
{
    private LongRangeEnemy lREnemy;

    public LongRangeEnemy_MeleeAttackState(FiniteStateMachine stateMachine, Enemy enemy, Transform attackPosition, D_MeleeAttackState stateData,LongRangeEnemy lREnemy) : base(stateMachine, enemy, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinish)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(lREnemy.playerDetectiveState);
            }
            else
            {
                stateMachine.ChangeState(lREnemy.lookForPlayerState);
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
