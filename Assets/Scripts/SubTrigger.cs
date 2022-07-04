using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTrigger : MonoBehaviour
{
    //public Sentence sentenceClass;
    [SerializeField]
    public List<string> sentenceList = new List<string>();

    public void TriggerAnswer()
    {
        FindObjectOfType<PlayerManager>().StartDialogue();
    }

}

