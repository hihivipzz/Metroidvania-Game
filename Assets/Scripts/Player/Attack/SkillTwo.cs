using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillTwo : AbtractAttack
{
    private float height = 0.6f;
    private float width = 2f;
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
        OnDetectEnemyToMakeDamage();
    }

    private void OnDrawGizmos()
    {
        DrawRectangle();
    }
}
