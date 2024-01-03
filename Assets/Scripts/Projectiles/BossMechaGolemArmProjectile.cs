using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechaGolemArmProjectile : MonoBehaviour
{
    private AttackDetails attackDetails;

    private float speed;

    [SerializeField] Transform damagePointA;
    [SerializeField] Transform damagePointB;

    [SerializeField] LayerMask whatIsWall;
    [SerializeField] LayerMask whatIsPlayer;

    private Rigidbody2D rb;
    private bool hasHitWall;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if(!hasHitWall)
        {
            attackDetails.position = transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (!hasHitWall)
        {
            Collider2D damageHit = Physics2D.OverlapArea(damagePointA.position,damagePointB.position, whatIsPlayer);
            Collider2D wallHit = Physics2D.OverlapArea(damagePointA.position, damagePointB.position, whatIsWall);

            if (damageHit)
            {
                damageHit.transform.SendMessage("Damage", attackDetails);
                Destroy(gameObject);
            }else if (wallHit)
            {
                Destroy(gameObject);
            }
        }
    }

    public void FireProjectTile(float speed,  float Damage)
    {
        this.speed = speed;
        attackDetails.damageAmount = Damage;
    }

    private void OnDrawGizmos()
    {
        
    }
}
