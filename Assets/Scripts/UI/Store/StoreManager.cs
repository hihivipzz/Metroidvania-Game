using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Animator animator;
    public bool isOpen = false;

    private void FixedUpdate()
    {
        animator.SetBool("IsOpen", isOpen);
    }

    public void OpenStore()
    {
        isOpen = true;
    }

    public void CloseStore()
    {
        isOpen = false;
    }
}
