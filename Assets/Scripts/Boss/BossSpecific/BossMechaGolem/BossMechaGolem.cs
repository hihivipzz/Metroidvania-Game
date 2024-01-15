using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolem : Boss
{
    [SerializeField] private Transform meleeAttackPosition;
    [SerializeField] private Transform longRangeAttackPosition;
    [SerializeField] private Transform laserAttackPosition;
    [SerializeField] private Transform laserDamagePointA;
    [SerializeField] private Transform laserDamagePointB;
    [SerializeField] private Transform areaAttackPosition;
    [SerializeField] private Transform afterAngryAttackPosition;

    public BossMechaGolem_BossSleepState sleepState { get; private set; }
    public BossMechaGolem_BossAwakeState awakeState { get; private set; }
    public BossMechaGolem_BossNormalState normalState { get; private set; }
    public BossMechaGolem_BossMeleeAttackState meleeAttackState { get; private set; }
    public BossMechaGolem_BossLongRangeAttackState longRangeAttackState { get; private set;}
    public BossMechaGolem_BossSpecialAttackState specialAttackState { get; private set; }
    public BossMechaGolem_AngryState angryState { get; private set; }
    public BossMechaGolem_BossAreaAttackState areaAttackState { get; private set; }
    public BossMechaGolem_BossAngrySpecialAttackState angrySpecialAttackState { get; private set; }
    public BossMechaGolem_BossDeadState deadState { get; private set; }
    public BossMechaGolem_BossAngryMeleeAttack angryMeleeAttackState { get; private set; }
    public BossMechaGolem_BossLongRangeAttackState affterAngryMeleeAttackState { get; private set; }

    [SerializeField] private D_BossSleepState sleepStateData;
    [SerializeField] private D_BossAwakeState awakeStateData;
    [SerializeField] private D_BossNormalState normalStateData;
    [SerializeField] private D_BossMeleeAttackState meleeAttackStateData;
    [SerializeField] private D_BossLongRangeAttackState longRangeAttackStateData;
    [SerializeField] private D_BossSpecialAttackState specialAttackStateData;
    [SerializeField] private D_BossNormalState angryStateData;
    [SerializeField] private D_BossLongRangeAttackState areaAttackStateData;
    [SerializeField] private D_BossSpecialAttackState angrySpecialAttackStateData;
    [SerializeField] private D_BossDeadState deadStateData;
    [SerializeField] private D_BossMeleeAttackState angryMeleeAttackStateData;
    [SerializeField] private D_BossLongRangeAttackState afterAngryMeleeAttackStateData;
    

     public override void Start()
    {
        base.Start();

        sleepState = new BossMechaGolem_BossSleepState(stateMachine,this,sleepStateData);
        awakeState = new BossMechaGolem_BossAwakeState(stateMachine,this,awakeStateData);
        normalState = new BossMechaGolem_BossNormalState(stateMachine,this,normalStateData);
        meleeAttackState = new BossMechaGolem_BossMeleeAttackState(stateMachine, this, meleeAttackStateData, meleeAttackPosition);
        longRangeAttackState = new BossMechaGolem_BossLongRangeAttackState(stateMachine,this,longRangeAttackStateData,longRangeAttackPosition);
        specialAttackState = new BossMechaGolem_BossSpecialAttackState(stateMachine,this,specialAttackStateData,laserAttackPosition, laserDamagePointA, laserDamagePointB);
        angryState = new BossMechaGolem_AngryState(stateMachine,this,angryStateData);
        areaAttackState = new BossMechaGolem_BossAreaAttackState(stateMachine, this, areaAttackStateData, areaAttackPosition);
        angrySpecialAttackState = new BossMechaGolem_BossAngrySpecialAttackState(stateMachine,this,angrySpecialAttackStateData,laserAttackPosition,laserDamagePointA,laserDamagePointB);
        deadState = new BossMechaGolem_BossDeadState(stateMachine,this,deadStateData);
        angryMeleeAttackState = new BossMechaGolem_BossAngryMeleeAttack(stateMachine,this, angryMeleeAttackStateData, meleeAttackPosition);
        affterAngryMeleeAttackState = new BossMechaGolem_BossLongRangeAttackState(stateMachine, this, afterAngryMeleeAttackStateData, afterAngryAttackPosition);

        stateMachine.Initialize(sleepState);
    }

    public override void Update()
    {
        base.Update();
    }

    public void CheckPlayerAlive()
    {
        if (player.isDead && !isDead)
        {
            stateMachine.ChangeState(sleepState);
            this.currentHealth = bossData.maxHealth;
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);

    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if(isDead)
        {
            this.stateMachine.ChangeState(deadState);
        }
    }
}
