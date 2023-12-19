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
}
