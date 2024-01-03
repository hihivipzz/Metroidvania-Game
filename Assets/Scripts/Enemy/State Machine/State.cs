using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected FiniteStateMachine stateMachine;

    public float startTime { get; protected set; }

    protected string animBoolName;

    public  State(FiniteStateMachine stateMachine,  string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        DoCheck();
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {

    }
}
