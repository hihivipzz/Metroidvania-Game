using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Boss bossData;

    public int facingDirection { get; private set; }

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public BossAnimationToStateMachine atsm { get; private set; }

    public float currentHealth;

    protected bool isDead;

    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform sprite;

    protected Player player;

    public virtual void Start()
    {
        currentHealth = bossData.maxHealth;
        facingDirection = 1;
        isDead= false;

        stateMachine = new FiniteStateMachine();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        atsm = GetComponent<BossAnimationToStateMachine>();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        this.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        if (!isDead)
        {
            currentHealth -= attackDetails.damageAmount;
            if(attackDetails.damageAmount >0)
            {
                sprite.GetComponent<FlashEffect>()?.Flash();
            }
            

            if (currentHealth <= 0.0f)
            {
                isDead = true;
            }
        }
    }

    public virtual bool CheckPlayerInRange()
    {
        RaycastHit2D hit= Physics2D.Raycast(playerCheck.position, gameObject.transform.right, bossData.detectDistance,bossData.whatIsPlayer);
        if(hit != false)
        {
            player = hit.transform.GetComponent<Player>();
            return true;
        }
        return false;
    }

    public virtual bool CheckLookAtPlayer()
    {
        float xDis = player.GetComponent<Transform>().position.x - transform.position.x;
        if(xDis * facingDirection > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual float GetPlayerDistance()
    {
        return Math.Abs(player.GetComponent<Transform>().position.x - transform.position.x);
    }

    public virtual bool checkAngry()
    {
        if (currentHealth / bossData.maxHealth <= bossData.hpRateToAngry)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 getPlayerPositon()
    {
        return player.transform.position; ;
    }


    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(playerCheck.position, playerCheck.position+ (Vector3)(Vector2.right * bossData.detectDistance));
    }
   

}
