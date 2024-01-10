using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
            }

            Destroy(gameObject);
        }
    }
}
