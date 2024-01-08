using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossAngryMeleeAttack : BossMeleeAttackState {
    BossMechaGolem sBoss;
    public BossMechaGolem_BossAngryMeleeAttack(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossMeleeAttackState stateData, Transform attackPosition) : base(stateMachine, sBoss, stateData, attackPosition)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        if(isAnimationFinish)
        {
            stateMachine.ChangeState(sBoss.affterAngryMeleeAttackState);
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
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider2D in detectedObjects)
        {
            collider2D.transform.SendMessage("Damage", attackDetails);
        }
    }
}
