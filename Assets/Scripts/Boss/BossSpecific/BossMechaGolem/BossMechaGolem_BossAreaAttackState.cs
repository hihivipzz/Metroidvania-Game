using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossAreaAttackState : BossLongRangAttackState
{
    BossMechaGolem sBoss;
    protected GameObject projectile;
    protected BossMechaGolemArmProjectile projectileScript;

    private int numberOfProjectile = 7;
    private float distanceBetweenProjectile = 5;


    public BossMechaGolem_BossAreaAttackState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossLongRangeAttackState stateData, Transform attackPosition) : base(stateMachine, sBoss, stateData, attackPosition)
    {
        this.sBoss= sBoss;
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
        if (isAnimationFinish)
        {
            stateMachine.ChangeState(sBoss.angryState);
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        for(int i = 0; i <= numberOfProjectile / 2; i++)
        {
            Vector3 projecttilePostion = attackPosition.position + new Vector3(i*distanceBetweenProjectile, 0, 0);
            projectile = GameObject.Instantiate(stateData.projectile, projecttilePostion, attackPosition.rotation);
            projectileScript = projectile.GetComponent<BossMechaGolemArmProjectile>();
            if (projectileScript)
            {
                projectileScript.FireProjectTile(stateData.projectTileSpeed, stateData.projectTileDame);
            }

            projecttilePostion = attackPosition.position + new Vector3(-i * distanceBetweenProjectile, 0, 0);
            projectile = GameObject.Instantiate(stateData.projectile, projecttilePostion, attackPosition.rotation);
            projectileScript = projectile.GetComponent<BossMechaGolemArmProjectile>();
            if (projectileScript)
            {
                projectileScript.FireProjectTile(stateData.projectTileSpeed, stateData.projectTileDame);
            }
        }
        base.TriggerAttack();
    }
}
