using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_DodgeState : DodgeState {
    private LongRangeEnemy lREnemy;

    public LongRangeEnemy_DodgeState(FiniteStateMachine stateMachine, Enemy enemy,  D_DodgeState stateData, LongRangeEnemy lREnemy) : base(stateMachine, enemy, stateData)
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

        if(isDodgeOver)
        {
            if(isPlayerInMaxAgroRange && performCloseRangeAction)
            {
                stateMachine.ChangeState(lREnemy.meleeAttackState);
            }
            else if (isPlayerInMaxAgroRange && !performCloseRangeAction)
            {
                stateMachine.ChangeState(lREnemy.rangeAttackState);
            }
            else if(!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(lREnemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
