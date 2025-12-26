using System;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private DialogueManager dialogueManager;
    private void Start()
    {
        Invoke("TriggerDialogue", 3f);
    }

    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
        dialogueManager.SetCanClick(true);
    }
}
