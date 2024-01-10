using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour {
    [SerializeField] GameInput gameInput;
    [SerializeField] private float inputTimer;

    [SerializeField] private PlayerAttackDataSO attack1Data;
    [SerializeField] private PlayerAttackDataSO attack2Data;
    [SerializeField] private PlayerAttackDataSO attack3Data;

    [SerializeField] private PlayerSpellSO spell1Data;

    [SerializeField] private Transform attack1Pos;
    [SerializeField] private Transform attack2Pos;
    [SerializeField] private Transform attack3Pos;
    [SerializeField] private Transform guardCounterAttackPos;
    [SerializeField] private Transform spellAttackTransform;
    private PlayerAttack[] combo;

    public PlayerAttack playerAttack1 { get; private set; }
    public PlayerAttack playerAttack2 { get; private set; }
    public PlayerAttack playerAttack3 { get; private set; }

    private int nextComboIndex;
    private PlayerAttack currentAttack;

    public PlayerSpell playerSpell1 { get; private set; }
    public PlayerSpell currentSpell;

    public bool combatEnabled { get; private set; }

    public bool gotInput;
    public bool isAttacking { get; private set; }
    public bool isFirstAttack { get; private set; }
    public bool isGuard { get; private set; }
    public bool isUsingSpell { get; private set; }

    private float lastInputTime;
    private float lastGuardInputTime;

    public event EventHandler OnPerformAttack1;
    public event EventHandler OnDamage;

    private Rigidbody2D rb;
    private PlayerMovementController movementController;
    private Player player;

    private void Start()
    {
        combatEnabled = true;
        isAttacking = false;
        isGuard = false;
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnGuardStart += GameInput_OnGuardStart;
        gameInput.OnGuardCancel += GameInput_OnGuardCancel;
        gameInput.OnSpellAction += GameInput_OnSpellAction;
        initCombo();
        initSpell();
        rb=GetComponent<Rigidbody2D>();
        movementController= rb.GetComponent<PlayerMovementController>();
        player = rb.GetComponent<Player>();
        
    }

    private void GameInput_OnSpellAction(object sender, EventArgs e)
    {
        HandleSpellInput();
    }

    private void GameInput_OnGuardCancel(object sender, EventArgs e)
    {
        HandleGuardCancel();
    }

    private void GameInput_OnGuardStart(object sender, EventArgs e)
    {
        HandleGuardInput();
    }

    private void initCombo()
    {

        playerAttack1 = new PlayerAttack(attack1Data,attack1Pos);
        playerAttack2 = new PlayerAttack(attack2Data,attack2Pos);
        playerAttack3 = new PlayerAttack(attack3Data,attack3Pos);

        combo = new PlayerAttack[3];
        combo[0] = playerAttack1;
        combo[1] = playerAttack2;
        combo[2] = playerAttack3;
        nextComboIndex = 0;
    }

    private void initSpell()
    {
        playerSpell1 = new PlayerSpell(spell1Data, spellAttackTransform);
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        HandleCombatInput();
    }

    private void Update()
    {
        CheckAttacks();
        CheckCanAttacks();
    }


    private void HandleCombatInput()
    {
        if(combatEnabled && !movementController.isKnockback&&!movementController.isDashing)
        {
            if(nextComboIndex < combo.Length)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
             
        }
    }

    private void HandleSpellInput()
    {
        if (combatEnabled && !isAttacking && !gotInput)
        {
            isUsingSpell= true;
            currentSpell = playerSpell1;
            currentSpell.TriggerAttack();
        }
    }

    private void HandleGuardInput()
    {
        if(!isAttacking && !movementController.isKnockback && !movementController.isDashing)
        {
            isGuard = true;
            lastGuardInputTime = Time.time;
        }
    }

    private void HandleGuardCancel()
    {
        if (isGuard)
        {
            isGuard = false;
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            if(!isAttacking)
            {
                gotInput = false;
                isAttacking= true;
                currentAttack = combo[nextComboIndex];
                currentAttack.PerformAttack();
                nextComboIndex = (nextComboIndex +1);
            }
        }

        if(Time.time > lastInputTime + inputTimer)
        {
            gotInput= false;
            nextComboIndex= 0;
        }
    }

    private void CheckCanAttacks()
    {
        if(movementController.isKnockback || player.isDead)
        {
            combatEnabled = false;
            isAttacking= false;
            isUsingSpell= false;
            movementController.EnableFlip();
            if (currentAttack != null)
            {
                FinishAttack();
            }
            currentSpell = null;
            if (currentSpell)
            {
                currentSpell.FinishAttack();
            }
        }
        else
        {
            combatEnabled = true;
        }
    }

    private void CheckAttackHitBox()
    {
        currentAttack.CheckAttackHitBox();
    }

    private void FinishAttack()
    {
        isAttacking= false;
        currentAttack.FinishAttack();
        if(!gotInput)
        {
            nextComboIndex = 0;
        }
    }

    private void PerformSpell()
    {
        currentSpell.PerformAttack();
    }

    private void FinishSpell()
    {
        currentSpell.FinishAttack();
        currentSpell = null;
        isUsingSpell = false;
    }

    public void Damage(AttackDetails attackDetail)
    {
        int direction;
        if (attackDetail.position.x < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        if (isGuard)
        {
            if(Time.time > lastGuardInputTime + player.GetData().guardBufferTime)
            {
                float dameTake = attackDetail.damageAmount *(1 - player.GetData().guardDameDecrease);
                player.ChangeHealth(player.currentHealth - dameTake);
                OnDamage?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Collider2D[] detectedObject = Physics2D.OverlapCircleAll(guardCounterAttackPos.position, player.GetData().guardCounterDameRadius, player.GetData().whatIsDamageable);

                foreach (Collider2D collider in detectedObject)
                {
                    if (collider.transform.parent.GetComponent<Enemy>())
                    {
                        Enemy enemy = collider.transform.parent.GetComponent<Enemy>();
                        attackDetail.damageAmount = player.GetData().guardCouterDame;
                        attackDetail.position = guardCounterAttackPos.position;
                        enemy.Damage(attackDetail);
                    }
                    else if (collider.transform.parent.GetComponent<Boss>())
                    {
                        Boss boss = collider.transform.parent.GetComponent<Boss>();
                        attackDetail.damageAmount = player.GetData().guardCouterDame;
                        attackDetail.position = guardCounterAttackPos.position;
                        boss.Damage(attackDetail);
                    }
                }
            }
        }
        else
        {
            player.ChangeHealth(player.currentHealth - attackDetail.damageAmount);
            movementController.KnockBack(direction);
            OnDamage?.Invoke(this, EventArgs.Empty);
        }
       
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1Pos.position, attack1Data.attackRadius);
        Gizmos.DrawWireSphere(attack2Pos.position, attack2Data.attackRadius);
        Gizmos.DrawWireSphere(attack3Pos.position, attack3Data.attackRadius);
        Gizmos.DrawWireSphere(guardCounterAttackPos.position, player.GetData().guardCounterDameRadius);
    }
}
