using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillThree : AbtractAttack
{
    private float width = 2f;
    private float height = 0.6f;

    void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.AttackSkill3.performed += OnAttackPerformed;
    }

    public override void OnAttackPerformed(InputAction.CallbackContext context)
    {
        StartCoroutine(PerformedSkillAnimation());
    }

    public override IEnumerator PerformedSkillAnimation()
    {
        playerAnimator.AttackSkillThreeAnimation(true);
        yield return new WaitForSeconds(timeEndAnimation);
        playerAnimator.AttackSkillThreeAnimation(false);
    }

    public void OnAttackSkillThree()
    {
        OnDetectEnemyToMakeDamage();
    }

    private void OnDrawGizmos()
    {
        DrawRectangle();
    }
}
