using System;
using UnityEngine;

public class TutorialDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private TutorialDialogueManager tutorialDialogueManager;

    private void Start()
    {
        Invoke("TriggerDialogue", 3f);
    }

    public void TriggerDialogue()
    {
        FindFirstObjectByType<TutorialDialogueManager>().StartDialogue(dialogue);
        tutorialDialogueManager.SetCanClick(true);
    }
}
