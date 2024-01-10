using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossMeleeAttackState : BossMeleeAttackState {
    BossMechaGolem sBoss;
    public BossMechaGolem_BossMeleeAttackState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossMeleeAttackState stateData, Transform attackPosition) : base(stateMachine, sBoss, stateData, attackPosition)
    {
        this.sBoss = sBoss;
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
            stateMachine.ChangeState(sBoss.normalState);
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
            if (collider2D.transform.GetComponent<Player>())
            {
                Player player = collider2D.transform.GetComponent<Player>();
                player.OnDamage(attackDetails);
            }
        }
    }
}
