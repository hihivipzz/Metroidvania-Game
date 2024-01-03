using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class MoveState : EnemyState {
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public MoveState(FiniteStateMachine stateMachine, Enemy enemy,  D_MoveState stateData) : base(stateMachine, enemy, stateData.animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isPlayerInMinAgroRange = enemy.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(stateData.movementSpeed);
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
