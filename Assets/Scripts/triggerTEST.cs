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

    public GameObject wrongColor;
    public bool InsideTrigger;

    public void Update()
    {
        if (InsideTrigger)
        {
            if (argumentScript.HaveRightOne is true)
            {

            }
            else
            {
                wrongColor.SetActive(true);
            }
        }
        else
        {

        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
        {
            InsideTrigger = true;

            if (argumentScript.snatched || argumentScript.snatchedTwice)
            {
                if (argumentScript.snatchedTwice)
                {
                    //////////
                    
                    //////////
                }

                else
                {
                    argumentScript.HaveSentence = true;
                    argumentScript.card = collision.gameObject;
                    argumentScript.cardSc = argumentScript.card.GetComponent<AnswerRandomizer>();
                    argumentScript.secondDamage = argumentScript.cardSc.damageAm;

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
                    //////////
                    argumentScript.card.GetComponent<SubTrigger>().TriggerAnswer();
                    //////////
                }
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

                argumentScript.card.GetComponent<SubTrigger>().TriggerAnswer();
            }

            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        

        if (argumentScript.snatched)
        {
            argumentScript.HaveRightOne = false;
            

            if (argumentScript.snatchedTwice)
            {

            }
            else
            {
                textOnBubble.text = FindObjectOfType<PlayerManager>().DialogueText;
                if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
                {
                    InsideTrigger = false;

                    argumentScript.HaveRightOne = false;

                    argumentScript.HaveSentence = false;

                    argumentScript.card = null;
                    argumentScript.cardSc = null;

                    currentCard = 0;
                }
            }
        }

        else
        {
            if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
            {
                InsideTrigger = false;

                argumentScript.HaveRightOne = false;

                argumentScript.HaveSentence = false;

                argumentScript.card = null;
                argumentScript.cardSc = null;

                argumentScript.damage = 0;

                currentCard = 0;
                textOnBubble.text = ("");
            }
        }

        wrongColor.SetActive(false);

    }

    public void AddAcard()
     {
        //textOnBubble.text += argumentScript.sentenceAdded;

    }

}
