using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_AngryState : BossNormalState
{
    public BossMechaGolem sBoss;

    public BossMechaGolem_AngryState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossNormalState stateData) : base(stateMachine, sBoss, stateData)
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
        if (!isLookAtPlayer)
        {
            sBoss.Flip();
        }

        if(Time.time > specialStartTime + stateData.timeBetweenSpecial)
        {
            specialStartTime= Time.time;
            stateMachine.ChangeState(sBoss.angrySpecialAttackState);
        }
        else if (Time.time > attackStartTime + stateData.timeBetweenAttack)
        {
            if(isPlayerInCloseRange)
            {
                stateMachine.ChangeState(sBoss.angryMeleeAttackState);
            }
            else
            {
                stateMachine.ChangeState(sBoss.areaAttackState);
            }
            attackStartTime = Time.time;
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
