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

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue()
    {
       print("triggered");
        triggerSc = bubbleHolder.card.GetComponent<SubTrigger>();
       dialogueText.text = triggerSc.sentenceList[0].ToString();
    }

    public void FinishDialogue()
    {
        dialogueText.text = ("");
    }
}
