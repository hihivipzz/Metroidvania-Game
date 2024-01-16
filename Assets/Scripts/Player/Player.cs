using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler OnPlayerHealthChange;
    public event EventHandler OnPlayerLiveChange;
    public event EventHandler OnPlayerCoinChange;

    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private Transform itemCheckPos;
    [SerializeField] private GameInput gameInput;
    public float currentHealth { get; private set; }
    public int currentLive { get; private set; }
    private PlayerCombatController combatcontroller;
    public bool isDead { get; private set; }
    public int coinNumber { get; private set; }
    public bool isDetectedItem { get; private set; }
    public bool isDetectedNPC { get; private set; }
    private TreasureController detectedItem;
    private NPCController detectedNPC;
    private Vector3 revivePosition;

    private void Awake()
    {
        currentHealth = playerData.maxHealth;
        currentLive = playerData.maxLife;
        coinNumber = 0;
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        revivePosition = this.transform.position;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if(isDetectedItem)
        {
            
            detectedItem.OpenTreasure();
        }else if (isDetectedNPC)
        {
            detectedNPC.StartTalk(this.transform.position);
        }
    }

    private void Start()
    {

        combatcontroller = GetComponent<PlayerCombatController>();
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
        CheckItemOrNPC();
    }

    private void CheckIsDead()
    {
        if (currentLive <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }

    private void CheckItemOrNPC()
    {
        RaycastHit2D detectedItemCollider = Physics2D.Raycast(itemCheckPos.position, transform.right, playerData.itemDistance, playerData.whatIsItem);
        if(detectedItemCollider)
        {
            isDetectedItem = true;
            detectedItem = detectedItemCollider.collider.gameObject.GetComponent<TreasureController>();
        }
        else
        {
            isDetectedItem= false;
            detectedItem = null;
        }
        RaycastHit2D detectedNPCCollider = Physics2D.Raycast(itemCheckPos.position, transform.right, playerData.nPCDistance, playerData.whatIsNpc);
        if (detectedNPCCollider)
        {
            isDetectedNPC = true;
            detectedNPC = detectedNPCCollider.collider.gameObject.GetComponent<NPCController>();
        }
        else
        {
            isDetectedNPC= false;
            detectedNPC = null;
        }
    }

    public void ChangeHealth(float healthValue)
    {
        currentHealth = healthValue;
        if (currentHealth <= 0)
        {
            ChangeLive(currentLive - 1);
            if (currentLive > 0)
            {
                currentHealth = playerData.maxHealth;
            }
        }
        if (currentHealth > playerData.maxHealth)
        {
            currentHealth = playerData.maxHealth;
        }
        OnPlayerHealthChange?.Invoke(this, EventArgs.Empty);

    }

    public void ChangeLive(int liveValue)
    {
        currentLive = liveValue;

        if (currentLive > playerData.maxLife)
        {
            currentLive = playerData.maxLife;
        }

        OnPlayerLiveChange?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeCoin(int coin)
    {
        coinNumber = coin;
        OnPlayerCoinChange?.Invoke(this, EventArgs.Empty);
    }


    public PlayerDataSO GetData()
    {
        return playerData;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(itemCheckPos.position, new Vector3(itemCheckPos.position.x + playerData.itemDistance, itemCheckPos.position.y));
    }

    public void Revive()
    {
        this.transform.position = revivePosition;
        ChangeCoin(coinNumber / 2);
        ChangeHealth(playerData.maxHealth);
        ChangeLive(playerData.maxLife);
    }

    public void SetReviePos(Vector3 pos)
    {
        revivePosition = pos;
    }
}
