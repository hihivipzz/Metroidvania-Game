using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : Enemy
{
    public LongRangeEnemy_IdleState idleState { get; private set; }
    public LongRangeEnemy_MoveState moveState { get; private set; }
    public LongRangeEnemy_PlayerDetectiveState playerDetectiveState { get; private set; }
    public LongRangeEnemy_MeleeAttackState meleeAttackState { get; private set; }
    public LongRangeEnemy_LookForPlayerState lookForPlayerState { get; private set;}
    public LongRangeEnemy_DeadState deadState { get; private set; }
    public LongRangeEnemy_DodgeState dodgeState { get; private set;}
    public LongRangeEnemy_RangeAttackState rangeAttackState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetectiveState playerDetectiveStateData;
    [SerializeField] private D_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_RangeAttackState rangeAttackStateData;
    public D_DodgeState dodgeStateData;

    [SerializeField]private Transform meleeAttackPosition;
    [SerializeField] private Transform longRangeAttackPosition;

    public override void Start()
    {
        base.Start();

        idleState = new LongRangeEnemy_IdleState(stateMachine, this,idleStateData,this);
        moveState = new LongRangeEnemy_MoveState(stateMachine, this, moveStateData ,this);
        playerDetectiveState = new LongRangeEnemy_PlayerDetectiveState(stateMachine, this, playerDetectiveStateData, this);
        meleeAttackState = new LongRangeEnemy_MeleeAttackState(stateMachine, this, meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new LongRangeEnemy_LookForPlayerState(stateMachine, this, lookForPlayerStateData, this);
        deadState = new LongRangeEnemy_DeadState(stateMachine,this,deadStateData, this);
        dodgeState = new LongRangeEnemy_DodgeState(stateMachine,this,dodgeStateData, this);
        rangeAttackState = new LongRangeEnemy_RangeAttackState(stateMachine, this, longRangeAttackPosition, rangeAttackStateData, this);
        
        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Dead()
    {
        base.Dead();

        
    }
}
