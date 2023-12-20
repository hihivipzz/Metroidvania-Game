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
    public abstract IEnumerator PerformedSkillAnimation();
}
