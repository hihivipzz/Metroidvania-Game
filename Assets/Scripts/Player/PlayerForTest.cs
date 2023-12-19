using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerForTest : MonoBehaviour {
    private float speed = 7f;
    [SerializeField] private GameInput gameInput;
    private Rigidbody2D rb;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask whatIsEnemy;
    public float attackRadius = 5;
    private AttackDetails attackDetails;

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        rb= GetComponent<Rigidbody2D>();
        attackDetails.damageAmount = 1;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        //Handle Interact
    }

    private void Update()
    {
        MovementHanlder();
        Jump();
        Attack();
    }

    private void MovementHanlder()
    {
        Vector2 inputVector = gameInput.GetMovementNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, 0f);
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }

    private void checkAttackHitBox()
    {
        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, whatIsEnemy);;
        foreach (Collider2D collider in detectedObject)
        {
            Enemy enemy = collider.transform.parent.GetComponent<Enemy>();
            if (enemy)
            {
                attackDetails.position = attackPos.position;
                enemy.Damage(attackDetails);
            }
        }
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            checkAttackHitBox();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}

