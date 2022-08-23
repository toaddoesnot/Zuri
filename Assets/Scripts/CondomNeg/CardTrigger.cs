using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTrigger : MonoBehaviour
{
    public Sentence sentenceClass;
    public Slider playerMotivation;

    public void TriggerDialogue()
    {
            FindObjectOfType<PartnerManager>().StartDialogue(sentenceClass);
            playerMotivation.value -= sentenceClass.power;
    }
}
