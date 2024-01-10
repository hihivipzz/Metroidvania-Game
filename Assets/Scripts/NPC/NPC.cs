using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private string name;

    [TextArea(3, 10)]
    public string[] sentences;

    public Dialogue GetDialogue()
    {
        return GetDialogue();
    }
}
