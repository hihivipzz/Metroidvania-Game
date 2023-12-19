using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State {
    private D_LookForPlayerState stateData;

    protected bool turnImediately;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;

    protected int amountOfTurnDone;

    public LookForPlayerState(FiniteStateMachine stateMachine, Enemy enemy, D_LookForPlayerState stateData) : base(stateMachine, enemy, stateData.animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerInMinAgroRange = enemy.CheckPlayerInManAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime= startTime;
        amountOfTurnDone = 0;
        enemy.SetVelocity(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(turnImediately)
        {
            enemy.Flip();
            lastTurnTime = Time.time;
            amountOfTurnDone++;
            turnImediately = false;
        }else if(Time.time >= lastTurnTime + stateData.timeBetweenTurn && !isAllTurnsDone) 
        {
            enemy.Flip();
            lastTurnTime = Time.time;
            amountOfTurnDone++;
        }

        if(amountOfTurnDone >= stateData.amountOfTurn)
        {
            isAllTurnsDone= true;
        }

        if(Time.time >= lastTurnTime + stateData.timeBetweenTurn && isAllTurnsDone)
        {
            isAllTurnsTimeDone= true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImmediately(bool flip)
    {
        turnImediately = flip;
    }
}
