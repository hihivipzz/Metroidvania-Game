using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell
{
    public static event EventHandler OnSpellTrigger;
    protected bool isTrigger = false;
    protected Transform attackPos;
    protected AttackDetails attackDetails;
    GameObject projectile;
    PlayerSpellSO data;

    public PlayerSpell(PlayerSpellSO data, Transform attackPos)
    {
        this.data = data;
        this.attackPos = attackPos;
    }

    public virtual void TriggerAttack()
    {
        isTrigger= true;
        OnSpellTrigger?.Invoke(this, EventArgs.Empty);
    }

   public virtual void PerformAttack()
   {
        projectile = GameObject.Instantiate(data.projectile, attackPos.position, attackPos.rotation);
        projectile.GetComponent<PlayerProjectile>()?.FireProjectTile(data.Projectilespeed, data.travelTime, data.ProjectileDame);
   }

    public bool GetCurrentStatus()
    {
        return isTrigger;
    }

    public virtual void FinishAttack()
    {
        isTrigger= false;
    }

    public Vector3 GetAttackPos()
    {
        return attackPos.position;
    }
}
