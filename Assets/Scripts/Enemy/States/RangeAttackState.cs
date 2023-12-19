using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : AttackState
{
    protected D_RangeAttackState stateData;

    protected GameObject projectile;
    protected Projectile projectileScipt;

    public RangeAttackState(FiniteStateMachine stateMachine, Enemy enemy,  Transform attackPosition,D_RangeAttackState stateData) : base(stateMachine, enemy, stateData.animBoolName, attackPosition)
    {
        this.stateData = stateData;
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


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        projectile=GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
        projectileScipt = projectile.GetComponent<Projectile>();
        if (projectileScipt)
        {
            projectileScipt.FireProjectTile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
        }
       
    }
}
