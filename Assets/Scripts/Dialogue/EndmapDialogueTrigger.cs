using System;
using UnityEngine;

public class EndmapDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        Invoke("TriggerDialogue", 3f);
    }

    public void TriggerDialogue()
    {
        FindFirstObjectByType<EndmapDialogueManager>().StartDialogue(dialogue);
    }
}
