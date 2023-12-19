using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_PlayerDetectiveState : PlayerDetectiveState
{
    private LongRangeEnemy lREnemy;

    public LongRangeEnemy_PlayerDetectiveState(FiniteStateMachine stateMachine, Enemy enemy, D_PlayerDetectiveState stateData, LongRangeEnemy lREnemy) : base(stateMachine, enemy, stateData)
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

        if (performShortRangeAction)
        {
            if(Time.time >= lREnemy.dodgeState.startTime + lREnemy.dodgeStateData.dodgeCooldown)
            {
                stateMachine.ChangeState(lREnemy.dodgeState);
            }
            else
            {
                stateMachine.ChangeState(lREnemy.meleeAttackState);
            }   
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(lREnemy.rangeAttackState);
        }
        else if(!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(lREnemy.lookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
