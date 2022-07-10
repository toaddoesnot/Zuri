using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class triggerTEST : MonoBehaviour
{
    public ArgumentSlot argumentScript;

    public List<GameObject> Bubbles = new List<GameObject>();
    public int currentCard;

    public TextMeshProUGUI textOnBubble;


    public void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
        {
            if (argumentScript.snatched)
            {

            }

            else
            {
                argumentScript.HaveSentence = true;
                argumentScript.card = collision.gameObject;
                argumentScript.cardSc = argumentScript.card.GetComponent<AnswerRandomizer>();
                argumentScript.damage = argumentScript.cardSc.damageAm;

                if (argumentScript.cardSc.haveSTD & argumentScript.cardSc.havePast is false)
                {
                    currentCard = 1;
                }

                if (argumentScript.cardSc.haveMood & argumentScript.cardSc.haveSTD is false & argumentScript.cardSc.havePast is false)
                {
                    currentCard = 2;
                }

                if (argumentScript.cardSc.haveProblem)
                {
                    currentCard = 3;
                }

                if (argumentScript.cardSc.havePast & argumentScript.cardSc.haveMood is false & argumentScript.cardSc.haveSTD is false)
                {
                    currentCard = 4;
                }

                if (argumentScript.cardSc.havePast & argumentScript.cardSc.haveMood & argumentScript.cardSc.haveSTD & argumentScript.cardSc.haveProblem)
                {
                    currentCard = 5;
                }

                if (argumentScript.cardSc.haveSTD & argumentScript.cardSc.havePast & argumentScript.cardSc.haveMood is false)
                {
                    currentCard = 6;
                }

                if (argumentScript.cardSc.havePast & argumentScript.cardSc.haveMood & argumentScript.cardSc.haveSTD is false)
                {
                    currentCard = 7;
                }

                GenerateAnswer();
                argumentScript.card.GetComponent<SubTrigger>().TriggerAnswer();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (argumentScript.snatched)
        {

        }
        else
        {
            if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
            {
                argumentScript.HaveSentence = false;

                argumentScript.card = null;
                argumentScript.cardSc = null;

                argumentScript.damage = 0;

                currentCard = 0;

                GenerateAnswer();
                textOnBubble.text = ("");
            }
        }

    }

    public void GenerateAnswer()
     {
       // foreach (GameObject bubble in Bubbles)
       // {
           //bubble.SetActive(false);
           //Bubbles[currentCard].SetActive(true);
       // }

        

    }

}
