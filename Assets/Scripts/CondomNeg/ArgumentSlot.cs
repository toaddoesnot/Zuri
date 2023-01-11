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
    public PartnerAnim animateSc2;

    public GameObject snatchedRightS;
    public GameObject snatchedWrongS;

    public Animation PositiveResponse; //NEW
    public GameObject takeCardTips; //NEW
    public TextMeshProUGUI tipText; //NEW
    public TypeDictionary roundSc; //NEW

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
                animateSc2.twoCardAnim = true;
                animateSc2.ChangeAnimation();
            }
            else
            {
                animateSc.oneCardAnim = true;
                animateSc.ChangeAnimation();
                animateSc2.oneCardAnim = true;
                animateSc2.ChangeAnimation();
            }
            //bugger.DestroyCard = false;
        }
        if (cardDrawn.cardDrawn)
        {
            if (roundSc.Round <= 2)
            {
                takeCardTips.SetActive(true);
            }
            tipText.text = "Drag cards into your bubble to respond";

            bugger.DestroyCard = true;
            argText.text = "...";

            animateSc.noCardAnim = true;
            animateSc.ChangeAnimation();
            animateSc2.noCardAnim = true;
            animateSc2.ChangeAnimation();
            //bugger.DestroyCard = false;
            //FindObjectOfType<EndScreenSc>().PlayerRecap();
        }
        else
        {
            //takeCardTips.SetActive(false);
            tipText.text = "Drag cards into your bubble to respond";
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (HaveRightOne)
        {
            if (roundSc.Round <= 2)
            {
                 takeCardTips.SetActive(true);
            }
           
            tipText.text = "Press Take Card or Drag a second card";

            if (snatched)
            {
                if (snatchedTwice)
                {
                    
                }
                else
                {
                    snatchedRightS.GetComponent<AudioSource>().Play();
                    PositiveResponse.Play("bubbleRight");

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
                snatchedRightS.GetComponent<AudioSource>().Play();
                PositiveResponse.Play("bubbleRight");

                

                snatched = true;
                FindObjectOfType<PlayerManager>().GetText();

                HaveSentence = false;
                Destroy(card);
            }
        }
    }
}


