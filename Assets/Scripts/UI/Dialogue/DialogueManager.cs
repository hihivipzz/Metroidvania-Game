using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueTitle;
    public TextMeshProUGUI dialogueContent;
    public GameObject dialogBox;
    private Queue<string> sentences;
    private Animator animator;
    private bool isOpen = false;
    private int status = -1;

    private void Awake()
    {
        animator = dialogBox.GetComponent<Animator>();
        NPCController.OnNPCStartTalk += NPCController_OnNPCStartTalk;
    }

    private void NPCController_OnNPCStartTalk(object sender, NPCController.OnNPCStartTalkArgument e)
    {
        StartDialogue(e.dialogue);
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("isOpen", isOpen);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isOpen = true;

        dialogueTitle.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            status = -1;
            StoreManager.Instance.OpenStore();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueContent.text = sentence;
    }

    public void SkipDialogue()
    {
        sentences.Clear();
        EndDialogue();
        status = 0;
        StoreManager.Instance.OpenStore();
    }

    public void EndDialogue()
    {
        status = -1;
        isOpen = false;
    }

    public int GetStatus()
    {
        return status;
    }


}
