using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillOne : AbtractAttack
{
    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.AttackSkill1.performed += OnAttackPerformed;
    }

    public override void OnAttackPerformed(InputAction.CallbackContext context)
    {
        StartCoroutine(PerformedSkillAnimation());
    }

    public override IEnumerator PerformedSkillAnimation()
    {
        playerAnimator.AttackSkillOneAnimation(true);
        yield return new WaitForSeconds(timeEndAnimation);
        playerAnimator.AttackSkillOneAnimation(false);
    }

    public void OnAttackSkillOne()
    {
        OnDetectEnemyToMakeDamage();
    }

    private void OnDrawGizmos()
    {
        DrawRectangle();
    }
}
