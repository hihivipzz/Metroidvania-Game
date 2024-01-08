using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueTitle;
    public TextMeshProUGUI dialogueContent;
    private Queue<string> sentences;
    public Animator animator;
    public Player player;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //player.playerProperty.isStopMoving = true;

        animator.SetBool("isOpen", true);

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
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueContent.text = sentence;
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
