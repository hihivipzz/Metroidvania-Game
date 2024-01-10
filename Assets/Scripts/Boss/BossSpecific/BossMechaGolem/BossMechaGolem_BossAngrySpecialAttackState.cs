using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem_BossAngrySpecialAttackState : BossSpecialAttackState {
    protected BossMechaGolem sBoss;
    Transform recPointA;
    Transform recPointB;
    public BossMechaGolem_BossAngrySpecialAttackState(FiniteStateMachine stateMachine, BossMechaGolem sBoss, D_BossSpecialAttackState stateData, Transform attackPosition, Transform dameAreaPointA, Transform dameAreaPointB) : base(stateMachine, sBoss, stateData, attackPosition)
    {
        this.sBoss = sBoss;
        this.recPointA = dameAreaPointA;
        this.recPointB = dameAreaPointB;
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
            stateMachine.ChangeState(sBoss.angryState);
        }
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        Vector3 direction = sBoss.getPlayerPositon() - attackPosition.position;
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        attackPosition.rotation =  Quaternion.Slerp(attackPosition.rotation, rotation, stateData.speed*Time.deltaTime);
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void damePlayerOverTime()
    {
        if (Time.time >= lastPlayerDamagedTime + stateData.timeBeetweenDame)
        {
            Collider2D[] detectedObjects = Physics2D.OverlapAreaAll(recPointA.position, recPointB.position, stateData.whatIsPlayer);
            foreach (Collider2D collider2D in detectedObjects)
            {
                collider2D.transform.SendMessage("Damage", attackDetails);
            }
            lastPlayerDamagedTime = Time.time;
        }

    }
}
