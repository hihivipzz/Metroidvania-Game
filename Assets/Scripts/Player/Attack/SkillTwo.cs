using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillTwo : AbtractAttack
{
    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.AttackSkill2.performed += OnAttackPerformed;
    }

    public override void OnAttackPerformed(InputAction.CallbackContext context)
    {
        StartCoroutine(PerformedSkillAnimation());
    }

    public override IEnumerator PerformedSkillAnimation()
    {
        playerAnimator.AttackSkillTwoAnimation(true);
        yield return new WaitForSeconds(timeEndAnimation);
        playerAnimator.AttackSkillTwoAnimation(false);
    }

    public void OnAttackSkillTwo()
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

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(attackPoint.transform.position, Radius);
    }
}
