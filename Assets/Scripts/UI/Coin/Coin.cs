using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event EventHandler onPickUpCoin;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            Debug.Log(player);
            if (player != null)
            {
                player.ChangeCoin(player.coinNumber + 1);
                Debug.Log("Change coin");
                onPickUpCoin?.Invoke(this, EventArgs.Empty);
            }

            Destroy(gameObject);
        }
    }
}
