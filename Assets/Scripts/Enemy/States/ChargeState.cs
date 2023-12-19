using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    private D_ChargeState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectedLedge;
    protected bool isDetectedWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public ChargeState(FiniteStateMachine stateMachine, Enemy enemy, D_ChargeState stateData) : base(stateMachine, enemy, stateData.animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
        isDetectedLedge = enemy.CheckLedge();
        isDetectedWall = enemy.CheckWall();

        performCloseRangeAction = enemy.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver= false;

        enemy.SetVelocity(stateData.chargeSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver= true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
