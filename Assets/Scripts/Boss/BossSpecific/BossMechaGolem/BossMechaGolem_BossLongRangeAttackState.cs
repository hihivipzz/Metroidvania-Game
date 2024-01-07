using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossLongRangeAttackState : BossLongRangAttackState
{
    BossMechaGolem sBoss;
    protected GameObject projectile;
    protected BossMechaGolemArmProjectile projectileScript;
    bool isAngry;
    public BossMechaGolem_BossLongRangeAttackState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossLongRangeAttackState stateData, Transform attackPosition) : base(stateMachine, sBoss, stateData, attackPosition)
    {
        this.sBoss= sBoss;
    }

    public override void DoCheck()
    {
        isAngry = sBoss.checkAngry();
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
        if (isAnimationFinish)
        {
            if (isAngry)
            {
                stateMachine.ChangeState(sBoss.angryState);
            }
            else
            {
                stateMachine.ChangeState(sBoss.normalState);
            }  
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
        projectileScript = projectile.GetComponent<BossMechaGolemArmProjectile>();
        if (projectileScript)
        {
            projectileScript.FireProjectTile(stateData.projectTileSpeed, stateData.projectTileDame);
        }
    }
}
