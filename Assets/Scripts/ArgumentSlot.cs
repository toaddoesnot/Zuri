using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ArgumentSlot : MonoBehaviour, IDropHandler
{
    public bool needMood;
    public bool needSTD;
    public bool needPast;
    public bool needProblem;

    public bool HaveSentence;
    public GameObject card;
    public AnswerRandomizer cardSc;
    public int damage;
    public int secondDamage;

    public Slider partnerMotivation;
    public bool snatched;
    public bool snatchedTwice;

    public bool HaveRightOne;
    public triggerTEST triggerSc;
    public TextMeshProUGUI argText;

    public string sentenceAdded;
    public SubTrigger addedSc;

    public CardDrawer cardDrawn;

    public cardsBug bugger;

    public PartnerAnim animateSc;

    void Start()
    {
        partnerMotivation = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
    }

    public void Update()
    {
        if (needMood)
        {
            if (triggerSc.currentCard is 2 || triggerSc.currentCard is 5 || triggerSc.currentCard is 7)
            {
                HaveRightOne = true;
            }
        }

        if (needSTD)
        {
            if (triggerSc.currentCard is 1 || triggerSc.currentCard is 5 || triggerSc.currentCard is 6)
            {
                HaveRightOne = true;
            }
        }

        if (needPast)
        {
            if (triggerSc.currentCard is 4 || triggerSc.currentCard is 5 || triggerSc.currentCard is 6 || triggerSc.currentCard is 7)
            {
                HaveRightOne = true;
            }
        }

        if (needProblem)
        {
            if (triggerSc.currentCard is 3 || triggerSc.currentCard is 5)
            {
                HaveRightOne = true;
            }
        }
    }

    public void GiveDamage()
    {
        FindObjectOfType<PlayerManager>().GetRidOfText();

        if (snatched)
        {
            bugger.DestroyCard = true;
            FindObjectOfType<EndScreenSc>().PlayerRecap();
            partnerMotivation.value -= damage;
            damage = 0;
            secondDamage = 0;

            if (snatchedTwice)
            {
                animateSc.twoCardAnim = true;
                animateSc.ChangeAnimation();
            }
            else
            {
                animateSc.oneCardAnim = true;
                animateSc.ChangeAnimation();
            }
            //bugger.DestroyCard = false;
        }
        if (cardDrawn.cardDrawn)
        {
            bugger.DestroyCard = true;
            argText.text = "...";

            animateSc.noCardAnim = true;
            animateSc.ChangeAnimation();
            //bugger.DestroyCard = false;
            //FindObjectOfType<EndScreenSc>().PlayerRecap();
        }
        else
        {
            
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (HaveRightOne)
        {
            if (snatched)
            {
                if (snatchedTwice)
                {
                    
                }
                else
                {
                    sentenceAdded = card.GetComponent<SubTrigger>().sentenceList[0];

                    triggerSc.AddAcard();
                    snatchedTwice = true;
                    HaveSentence = false;
                    damage += secondDamage;
                    Destroy(card);
                }
            }
            else
            {
                //
                snatched = true;
                FindObjectOfType<PlayerManager>().GetText();

                HaveSentence = false;
                Destroy(card);
            }
        }
    }
}


