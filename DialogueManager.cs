using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    public GameObject chatbox;

    private Queue<string> sentences;
    private bool conversationActive = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        chatbox.SetActive(false);
        chatbox.transform.localScale = new Vector3(0,0,0);
    }

    public void OneButtonDialogue (Dialogue dialogue)
    {
        if(!conversationActive) {
            StartDialogue(dialogue);
        } else {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        sentences.Clear();
        conversationActive = true;
        chatbox.SetActive(true);
        LeanTween.scale(chatbox, new Vector3(1,1,1), 0.2f);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        conversationActive = false;
        LeanTween.scale(chatbox, new Vector3(0,0,0), 0.2f);
        // chatbox.SetActive(false);
    }
}
