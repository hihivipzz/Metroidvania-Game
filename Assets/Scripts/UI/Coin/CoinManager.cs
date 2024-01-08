using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;
    public static CoinManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void SpawnCoin(int quantity, Vector2 centerPosition, float maxXDistance = 5f)
    {
        for (int i = 0; i < quantity; i++)
        {
            float randomX = centerPosition.x + Random.Range(-maxXDistance, maxXDistance);

            Vector2 spawnPosition = new Vector2(randomX, centerPosition.y);

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
