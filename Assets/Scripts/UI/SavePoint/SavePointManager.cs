using UnityEngine;

public class SavePointManager : MonoBehaviour
{
    public Animator animator;
    public bool isOpen = false;
    private int status = -1;

    private void FixedUpdate()
    {
        animator.SetBool("IsOpenSavePointDialogue", isOpen);
    }

    public void StartDialog()
    {
        isOpen = true;
        status = 1;
    }

    public void CloseDialog()
    {
        isOpen = false;
        status = -1;
    }

    public void YesOnClick()
    {
        // open save screen

        // handle save game

        CloseDialog();
    }

    public int GetStatus()
    {
        return status;
    }
}
