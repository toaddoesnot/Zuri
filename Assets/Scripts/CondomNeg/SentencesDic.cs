using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SentencesDic : MonoBehaviour
{
    public List<Sentence> sentences = new List<Sentence>();
    public Sentence senScript;
    public int currentSentence = -1;

    void Start()
    {
        int randomIndex = Random.Range(0, sentences.Count);
        currentSentence = randomIndex;
    }

    public void TriggerDialogue()
    {
       FindObjectOfType<PartnerManager>().StartDialogue(senScript);
    }

   

}
