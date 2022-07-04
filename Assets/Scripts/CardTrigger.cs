using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTrigger : MonoBehaviour
{
    public Sentence sentenceClass;
    public Slider playerMotivation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialogue()
    {
            FindObjectOfType<PartnerManager>().StartDialogue(sentenceClass);
            playerMotivation.value -= sentenceClass.power;
    }
}
