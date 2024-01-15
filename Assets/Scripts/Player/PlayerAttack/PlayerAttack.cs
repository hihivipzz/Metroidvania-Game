using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    public static event EventHandler OnPlayerAttack;

    protected bool isTrigger = false;
    protected PlayerAttackDataSO attackData;
    protected Transform attackPos;
    protected AttackDetails attackDetail;

    public PlayerAttack(PlayerAttackDataSO attackData, Transform pos)
    {
        this.attackData = attackData;
        this.attackPos = pos;
        attackDetail = new AttackDetails();
        attackDetail.damageAmount = attackData.attackDamage; 
    }

    public virtual void PerformAttack() 
    { 
        isTrigger= true;
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }

    public virtual void FinishAttack()
    {
        isTrigger = false;
    }

    public bool GetStatus()
    {
        return isTrigger;
    }

    public void CheckAttackHitBox()
    {
        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attackPos.position, attackData.attackRadius, attackData.whatIsDamageable);

        foreach(Collider2D collider in detectedObject)
        {
            if (collider.transform.parent.GetComponent<Enemy>())
            {
                Enemy enemy = collider.transform.parent.GetComponent<Enemy>();
                attackDetail.damageAmount = attackData.attackDamage;
                attackDetail.position = attackPos.position;
                enemy.Damage(attackDetail);
            }else if (collider.transform.parent.GetComponent<Boss>())
            {
                Boss boss = collider.transform.parent.GetComponent<Boss>();
                attackDetail.damageAmount = attackData.attackDamage;
                attackDetail.position = attackPos.position;
                boss.Damage(attackDetail);
            }
        }
    }

    public Vector3 GetAttackPos()
    {
        return attackPos.position;
    }
}
