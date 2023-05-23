using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardTrigger : MonoBehaviour
{
    public Sentence sentenceClass;
    public Slider playerMotivation;

    public GenderChanger genderSc;
    public string femaleTxt;
    public string maleTxt;

    public bool femaleReactive;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void StartFemales()
    {
        
    }
    public void ReturnMales()
    {
       
    }


    public void TriggerDialogue()
    {
        genderSc = FindObjectOfType<GenderChanger>();

        if (genderSc.females is true)
        {
            if (femaleReactive)
            {
                sentenceClass.sentence[0] = femaleTxt.ToString();
            }
            FindObjectOfType<PartnerManager>().StartDialogue(sentenceClass);
            playerMotivation.value -= sentenceClass.power;
        }
        else
        {
            if (femaleReactive)
            {
                sentenceClass.sentence[0] = maleTxt.ToString();
                
            }
            FindObjectOfType<PartnerManager>().StartDialogue(sentenceClass);
            playerMotivation.value -= sentenceClass.power;
        }
    }
}
