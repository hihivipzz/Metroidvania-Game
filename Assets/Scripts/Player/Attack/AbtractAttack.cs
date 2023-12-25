using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AbtractAttack : MonoBehaviour
{
    protected PlayerInputActions playerInputActions;
    protected PlayerAnimator playerAnimator;
    public GameObject attackPoint;
    public LayerMask Enemies;
    public float DamageAmout = 5f;
    public float timeEndAnimation = 1f;
    [SerializeField]
    public float height;
    [SerializeField]
    public float width;

    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerInputActions = new PlayerInputActions();
    }

    public abstract void OnAttackPerformed(InputAction.CallbackContext context);
    public void OnDetectEnemyToMakeDamage()
    {
        Collider2D[] enemiesCollider = Physics2D.OverlapAreaAll(
           new Vector2(attackPoint.transform.position.x - width / 2f, attackPoint.transform.position.y + height / 2f),
           new Vector2(attackPoint.transform.position.x + width / 2f, attackPoint.transform.position.y - height / 2f),
           Enemies);

        foreach (Collider2D enemyCollider in enemiesCollider)
        {
            AttackDetails attackDetails = new AttackDetails();
            attackDetails.position = transform.position;
            attackDetails.damageAmount = DamageAmout;
            Enemy enemy = enemyCollider.transform.parent.GetComponent<Enemy>();
            enemy.Damage(attackDetails);
        }
    }
    public abstract IEnumerator PerformedSkillAnimation();

    protected void DrawRectangle()
    {
        float halfWidth = width / 2f;
        float halfHeight = height / 2f;

        Vector3 topLeft = attackPoint.transform.position + new Vector3(-halfWidth, halfHeight, 0f);
        Vector3 topRight = attackPoint.transform.position + new Vector3(halfWidth, halfHeight, 0f);
        Vector3 bottomLeft = attackPoint.transform.position + new Vector3(-halfWidth, -halfHeight, 0f);
        Vector3 bottomRight = attackPoint.transform.position + new Vector3(halfWidth, -halfHeight, 0f);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
