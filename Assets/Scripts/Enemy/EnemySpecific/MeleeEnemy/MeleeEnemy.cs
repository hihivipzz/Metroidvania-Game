using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public MeleeEnemy_IdleState idleState { get; private set; }
    public MeleeEnemy_MoveState moveState { get; private set; }
    public MeleeEnemy_PlayerDetectiveState playerDetectiveState { get; private set; }
    public MeleeEnemy_ChargeState chargeState { get; private set; }
    public MeleeEnemy_LookForPlayerState lookForPlayerState { get; private set; }  
    public MeleeEnemy_MeleeAttackState meleeAttackState { get; private set; }
    public MeleeEnemy_DeadState deadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetectiveState playerDetectiveStateData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField] private D_MeleeAttackState meleeAttackStateData;
    [SerializeField] private D_DeadState deadStateData;


    [SerializeField] private Transform meleeAtackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new MeleeEnemy_MoveState(stateMachine, this,  moveStateData, this);
        idleState = new MeleeEnemy_IdleState(stateMachine, this,  idleStateData, this);
        playerDetectiveState = new MeleeEnemy_PlayerDetectiveState(stateMachine, this,  playerDetectiveStateData, this);
        chargeState = new MeleeEnemy_ChargeState(stateMachine, this, chargeStateData, this);
        lookForPlayerState = new MeleeEnemy_LookForPlayerState(stateMachine,this,lookForPlayerStateData,this);
        meleeAttackState = new MeleeEnemy_MeleeAttackState(stateMachine, this, meleeAtackPosition,meleeAttackStateData, this);
        deadState = new MeleeEnemy_DeadState(stateMachine, this, deadStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if(isDead)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAtackPosition.position, meleeAttackStateData.attackRadius);
        
    }
}
