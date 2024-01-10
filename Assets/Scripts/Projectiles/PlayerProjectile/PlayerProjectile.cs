using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private AttackDetails attackDetail;

    private float speed;

    [SerializeField] Transform attackPos;
    public float attackRadius;
    private float travelTime;
    private float timeBetweenDamage = 0.1f;
    private float lastDamageTime ;


    [SerializeField] LayerMask whatIsWall;
    [SerializeField] LayerMask whatIsDamageable;

    private Rigidbody2D rb;
    private bool hasHitWall;

    private float startTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;
        startTime = Time.time;
        lastDamageTime= Time.time;
    }

    private void Update()
    {
        if (!hasHitWall)
        {
            attackDetail.position = transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (!hasHitWall)
        {
  
            Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, whatIsDamageable);
            Collider2D wallHit = Physics2D.OverlapCircle(attackPos.position, attackRadius, whatIsWall);

            if(Time.time  > timeBetweenDamage + lastDamageTime) {
                foreach (Collider2D collider in detectedObject)
                {
                    if (collider.transform.parent.GetComponent<Enemy>())
                    {
                        Enemy enemy = collider.transform.parent.GetComponent<Enemy>();
                        attackDetail.position = transform.position;
                        enemy.Damage(attackDetail);
                    }
                    else if (collider.transform.parent.GetComponent<Boss>())
                    {
                        Boss boss = collider.transform.parent.GetComponent<Boss>();
                        attackDetail.position = transform.position;
                        boss.Damage(attackDetail);
                    }
                }
                lastDamageTime= Time.time;
            }
            

           
            if (wallHit)
            {
                Destroy(gameObject);
            }

            if (Time.time > startTime + travelTime )
            {
                Destroy(gameObject);
            }
        }
    }

    public void FireProjectTile(float speed, float travelDistance, float Damage)
    {
        this.speed = speed;
        this.travelTime = travelDistance;
        attackDetail.damageAmount = Damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}
