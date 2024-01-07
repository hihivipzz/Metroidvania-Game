using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    public float currentHealth { get; private set; }


    private void Awake()
    {
        
    }

    private void Start()
    {
        currentHealth = playerData.maxHealth;
    }

    private void OnDamage(AttackDetails attackDetail)
    {
       
    }

    private void Update()
    {
        
    }

    public PlayerDataSO GetData()
    {
        return playerData;
    }
}
