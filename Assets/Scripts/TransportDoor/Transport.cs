using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform transportPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            TransportToPosition(player);
        }
    }
    public virtual void TransportToPosition(Player player)
    {
        player.transform.position = transportPosition.position;
    }
}
