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

    [SerializeField] private Transform attack1Pos;
    [SerializeField] private Transform attack2Pos;
    [SerializeField] private Transform attack3Pos;
    private PlayerAttack[] combo;

    public PlayerAttack playerAttack1 { get; private set; }
    public PlayerAttack playerAttack2 { get; private set; }
    public PlayerAttack playerAttack3 { get; private set; }
    private int nextComboIndex;
    private PlayerAttack currentAttack;

    public bool combatEnabled { get; private set; }

    public bool gotInput;
    public bool isAttacking { get; private set; }
    public bool isFirstAttack { get; private set; }
    public float attackForce;

    private float lastInputTime;

    public event EventHandler OnPerformAttack1;

    private Rigidbody2D rb;

    private void Start()
    {
        combatEnabled = true;
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        initCombo();
        rb=GetComponent<Rigidbody2D>();
        
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

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        handleCombatInput();
    }

    private void Update()
    {
        checkAttacks();
    }

    private void handleCombatInput()
    {
        if(combatEnabled)
        {
            if(nextComboIndex < combo.Length)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
             
        }
    }

    private void checkAttacks()
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1Pos.position, attack1Data.attackRadius);
        Gizmos.DrawWireSphere(attack2Pos.position, attack2Data.attackRadius);
        Gizmos.DrawWireSphere(attack3Pos.position, attack3Data.attackRadius);
    }
}
