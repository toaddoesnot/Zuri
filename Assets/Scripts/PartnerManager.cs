using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartnerManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI powerText;

    public bool startearly;

    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (startearly == true)
        {
            StartCoroutine(StopEarly());
        }

    }

    public void StartDialogue(Sentence dialogue)
    {
        powerText.text = dialogue.description;
        sentences.Clear();
        startearly = true;

        foreach (string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        
    }

    IEnumerator StopEarly()
    {
        yield return new WaitForSeconds(5);
        startearly = false;


    }
}
