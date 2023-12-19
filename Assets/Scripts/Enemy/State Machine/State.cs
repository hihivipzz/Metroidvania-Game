using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected FiniteStateMachine stateMachine;
    protected Enemy enemy;

    public float startTime { get; protected set; }

    protected string animBoolName;

    public  State(FiniteStateMachine stateMachine, Enemy enemy, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.enemy = enemy;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        enemy.anim.SetBool(animBoolName, true);
        DoCheck();
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolName,false);
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
