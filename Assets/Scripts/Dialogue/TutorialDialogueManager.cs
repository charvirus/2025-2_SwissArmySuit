using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject clearScreen;
    public GameObject abilities;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;
    public TextMeshProUGUI statusText;
    private bool canClick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
        playerMovement.SetCanmove(false);
        mouseLook.SetCanLook(false);
        statusText.text = "Tutorial";
    }

    private void Update()
    {
        if (canClick && Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        nameText.text = dialogue.name;
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
            abilities.SetActive(false);

            EndDialogue();
            return;
        }
        else if (sentences.Count == 6)
        {
            clearScreen.SetActive(true);
        }
        else if (sentences.Count == 5)
        {
            clearScreen.SetActive(false);
        }
        else if (sentences.Count == 4)
        {
            abilities.SetActive(true);
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        playerMovement.SetCanmove(true);
        mouseLook.SetCanLook(true);
        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }
    public void SetCanClick(bool value)
    {
        canClick = value;
    }
}