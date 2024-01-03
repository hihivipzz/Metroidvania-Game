using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNormalState : BossState {
    protected D_BossNormalState stateData;
    protected bool isLookAtPlayer;
    protected float attackStartTime;
    protected float specialStartTime;
    protected bool isAngry;
    protected bool isPlayerInCloseRange;

    public BossNormalState(FiniteStateMachine stateMachine,  Boss boss,D_BossNormalState stateData) : base(stateMachine, stateData.animBoolName, boss)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        isAngry = boss.checkAngry();
        isPlayerInCloseRange = boss.GetPlayerDistance() < stateData.meleeDistance;
        isLookAtPlayer = boss.CheckLookAtPlayer();
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
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
