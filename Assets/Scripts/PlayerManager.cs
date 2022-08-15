using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public ArgumentSlot bubbleHolder;
    public SubTrigger triggerSc;

    private Queue<string> sentences;

    public ArgumentSlot argumentSc;

    public string DialogueText;

    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void GetText()
    {
        DialogueText = dialogueText.text;
    }

    public void GetRidOfText()
    {
        DialogueText = "";
    }

    public void StartDialogue()
    {
       print("triggered");
       triggerSc = bubbleHolder.card.GetComponent<SubTrigger>();

        if (argumentSc.snatched)
        {
            dialogueText.text = DialogueText + triggerSc.sentenceList[0].ToString();
        }
        else
        {
            dialogueText.text = triggerSc.sentenceList[0].ToString();
            
        }

       
    }

    public void FinishDialogue()
    {
        dialogueText.text = ("");

    }
}
