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
        playerAnimator.TriggerAttack(2);
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
