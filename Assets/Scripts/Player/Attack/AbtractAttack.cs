using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AbtractAttack : MonoBehaviour
{
    protected PlayerInputActions playerInputActions;
    protected PlayerAnimator playerAnimator;
    public GameObject attackPoint;
    public float Radius;
    public LayerMask Enemies;
    public float DamageAmout = 5f;
    public float timeEndAnimation = 1f;

    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerInputActions = new PlayerInputActions();
    }

    public abstract void OnAttackPerformed(InputAction.CallbackContext context);
    public void OnDetectEnemyToMakeDamage()
    {
        Collider2D[] enemiesCollider = Physics2D.OverlapCircleAll(attackPoint.transform.position, Radius, Enemies);

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
}
