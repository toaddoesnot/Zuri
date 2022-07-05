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

    public Slider partnerMotivation;
    public bool snatched;

    void Start()
    {
        partnerMotivation = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();

    }

    public void GiveDamage()
    {
        
        partnerMotivation.value -= damage;
        damage = 0;

    }

    public void OnDrop(PointerEventData eventData)
    {
        snatched = true;
        HaveSentence = false;
        Destroy(card);
        

       // if (eventData.pointerDrag != null)
        //{
            
            //cardSc = null;
       // }

    }

}


