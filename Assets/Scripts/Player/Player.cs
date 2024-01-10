using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler OnPlayerHealthChange;
    public event EventHandler OnPlayerLiveChange;
    public event EventHandler OnPlayerCoinChange;

    [SerializeField] private PlayerDataSO playerData;
    public float currentHealth { get; private set; }
    public int currentLive { get; private set; }
    private PlayerCombatController combatcontroller;
    public bool isDead { get; private set; }
    public int coinNumber { get; private set; }


    private void Awake()
    {
        currentHealth = playerData.maxHealth;
        currentLive = playerData.maxLife;
        coinNumber = 0;
    }

    private void Start()
    {
       
        combatcontroller= GetComponent<PlayerCombatController>();
        isDead = false;
    }

    public void OnDamage(AttackDetails attackDetail)
    {
        if (!isDead)
        {
            combatcontroller.Damage(attackDetail);
        } 
    }

    private void Update()
    {
        CheckIsDead();
    }

    private void CheckIsDead()
    {
        if(currentLive <= 0)
        {
            isDead= true;
        }
        else
        {
            isDead= false;
        }
    }

    public void ChangeHealth(float healthValue)
    {
        currentHealth = healthValue;
        if(currentHealth <= 0)
        {
            ChangeLive(currentLive-1);
            if(currentLive > 0)
            {
                currentHealth = playerData.maxHealth;
            }
        }
        if(currentHealth > playerData.maxHealth)
        {
            currentHealth = playerData.maxHealth;
        }
        OnPlayerHealthChange?.Invoke(this,EventArgs.Empty);
        
    }

    private void ChangeLive(int liveValue)
    {
        currentLive = liveValue;
        if (currentLive > playerData.maxLife)
        {
            currentLive = playerData.maxLife;
        }
        OnPlayerLiveChange?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeCoin (int coin)
    {
        coinNumber = coin;
        OnPlayerCoinChange?.Invoke(this, EventArgs.Empty);
    }


    public PlayerDataSO GetData()
    {
        return playerData;
    }
}
