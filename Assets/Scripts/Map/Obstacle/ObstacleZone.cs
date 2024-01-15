using UnityEngine;

public class ObstacleZone : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    private float startDameTime;
    public float dameOverTime = 0.2f;
    private float DAMAGE = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null && Time.time > startDameTime + dameOverTime)
        {
            AttackDetails attackDetail = new AttackDetails();
            attackDetail.position = player.transform.position;
            attackDetail.damageAmount = DAMAGE;
            player.OnDamage(attackDetail);
            startDameTime = Time.time;
        }
    }
}
