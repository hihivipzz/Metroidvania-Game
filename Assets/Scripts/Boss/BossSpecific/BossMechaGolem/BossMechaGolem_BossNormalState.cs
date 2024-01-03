using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossNormalState : BossNormalState
{
    public BossMechaGolem sBoss;
    public BossMechaGolem_BossNormalState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossNormalState stateData) : base(stateMachine, sBoss, stateData)
    {
        this.sBoss = sBoss;
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
        if(!isLookAtPlayer)
        {
            sBoss.Flip();
        }

        if(isAngry)
        {
            stateMachine.ChangeState(sBoss.angryState);
        }

        else if(Time.time > specialStartTime + stateData.timeBetweenSpecial)
        {
            specialStartTime= Time.time;
            stateMachine.ChangeState(sBoss.specialAttackState);
        }
        else if(Time.time > attackStartTime + stateData.timeBetweenAttack)
        {
            if (isPlayerInCloseRange)
            {
                attackStartTime= Time.time;
                stateMachine.ChangeState(sBoss.meleeAttackState);
            }
            else
            {
                attackStartTime= Time.time;
                stateMachine.ChangeState(sBoss.longRangeAttackState);
            }
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
