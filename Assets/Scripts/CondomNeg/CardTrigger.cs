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

    public void StartFemales()
    {
        genderSc = FindObjectOfType<GenderChanger>();
        if (femaleReactive)
        {
            if (genderSc.females is true)
            {
                sentenceClass.sentence[0] = femaleTxt.ToString();
            }
        }
    }
    public void ReturnMales()
    {
        genderSc = FindObjectOfType<GenderChanger>();
        if (femaleReactive)
        {
            if (genderSc.females is false)
            {
                sentenceClass.sentence[0] = maleTxt.ToString();
            }
        }
    }


    public void TriggerDialogue()
    {
            FindObjectOfType<PartnerManager>().StartDialogue(sentenceClass);
            playerMotivation.value -= sentenceClass.power;
    }
}
