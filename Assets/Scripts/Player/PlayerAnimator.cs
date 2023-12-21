using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator = null;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void RunAnimation(bool isRunning)
    {
        animator.SetBool("isRun", isRunning);
    }

    public void JumpAnimation(bool isJump)
    {
        animator.SetFloat("JumpY", isJump ? 2f : 0.1f);
    }

    public void WalkAnimation(bool isWalk)
    {
        animator.SetBool("isWalk", isWalk);
    }

    public void AttackSkillOneAnimation(bool isAttack)
    {
        animator.SetBool("isAttackSkillOne", isAttack);
    }

    public void AttackSkillTwoAnimation(bool isAttack)
    {
        animator.SetBool("isAttackSkillTwo", isAttack);
    }

    public void AttackSkillThreeAnimation(bool isAttack)
    {
        animator.SetBool("isAttackSkillThree", isAttack);
    }

    public void DeadAnimation(bool isDead)
    {
        animator.SetBool("isDead", isDead);
    }
}
