using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChoice : MonoBehaviour
{
    public GameObject startUI;

    public SpriteRenderer spriteRenderer;
    public Sprite partner2;
    public Sprite partner3;

    public GameObject listMood;
    public GameObject listSTI;
    public GameObject listMood2;
    public GameObject listPast;
    public GameObject listProblem;

    public GameObject Ch2Mood;
    public GameObject Ch2STI;
    public GameObject Ch2Mood2;
    public GameObject Ch2Past;
    public GameObject Ch2Problem;

    public GameObject Ch3Mood;
    public GameObject Ch3STI;
    public GameObject Ch3Mood2;
    public GameObject Ch3Past;
    public GameObject Ch3Past2;
    public GameObject Ch3Problem;

    public GameObject Mood1;
    public GameObject STI1;
    public GameObject Mood21;
    public GameObject Past1;
    public GameObject Problem1;

    public GameObject animImage;

    public bool partnerOrange;
    public bool partnerPink;
    public bool partnerGrey;

    public TypeDictionary roundSc;

    public void Partner1()
    {
        animImage.SetActive(true);
        partnerOrange = true;

        startUI.SetActive(false);
        FindObjectOfType<TypeDictionary>().GenerateType();
        roundSc.Round = 1;
       // animImage.SetActive(false);
    }

    public void Partner2()
    {
        roundSc.Round = 1;
        animImage.SetActive(true);
        partnerPink = true;

        spriteRenderer.sprite = partner2;
        startUI.SetActive(false);

        listMood.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listSTI.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listMood2.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listPast.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listProblem.GetComponent<CardRandomizer>().Cards.RemoveAt(0);

        listMood.GetComponent<CardRandomizer>().Cards.Add(Ch2Mood);
        listMood.GetComponent<CardRandomizer>().firstCard = Mood1;
        listMood.GetComponent<CardRandomizer>().secondCard = Ch2Mood;

        listSTI.GetComponent<CardRandomizer>().Cards.Add(Ch2STI);
        listSTI.GetComponent<CardRandomizer>().firstCard = STI1;
        listSTI.GetComponent<CardRandomizer>().secondCard = Ch2STI;

        listMood2.GetComponent<CardRandomizer>().Cards.Add(Ch2Mood2);
        listMood2.GetComponent<CardRandomizer>().firstCard = Mood21;
        listMood2.GetComponent<CardRandomizer>().secondCard = Ch2Mood2;

        listPast.GetComponent<CardRandomizer>().Cards.Add(Ch2Past);
        listPast.GetComponent<CardRandomizer>().firstCard = Past1;
        listPast.GetComponent<CardRandomizer>().secondCard = Ch2Past;

        listProblem.GetComponent<CardRandomizer>().Cards.Add(Ch2Problem);
        listProblem.GetComponent<CardRandomizer>().firstCard = Problem1;
        listProblem.GetComponent<CardRandomizer>().secondCard = Ch2Problem;

        FindObjectOfType<TypeDictionary>().GenerateType();
        //animImage.SetActive(false);
    }

    public void Partner3()
    {
        roundSc.Round = 1;
        animImage.SetActive(true);
        partnerGrey = true;

        spriteRenderer.sprite = partner3;
        startUI.SetActive(false);

        listMood.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listSTI.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listMood2.GetComponent<CardRandomizer>().Cards.RemoveAt(0);

        listPast.GetComponent<CardRandomizer>().Cards.RemoveAt(0);
        listPast.GetComponent<CardRandomizer>().Cards.RemoveAt(0);

        listProblem.GetComponent<CardRandomizer>().Cards.RemoveAt(0);

        /////////

        listMood.GetComponent<CardRandomizer>().Cards.Add(Ch3Mood);
        listMood.GetComponent<CardRandomizer>().firstCard = Mood1;
        listMood.GetComponent<CardRandomizer>().secondCard = Ch3Mood;

        listSTI.GetComponent<CardRandomizer>().Cards.Add(Ch3STI);
        listSTI.GetComponent<CardRandomizer>().firstCard = STI1;
        listSTI.GetComponent<CardRandomizer>().secondCard = Ch3STI;

        listMood2.GetComponent<CardRandomizer>().Cards.Add(Ch3Mood2);
        listMood2.GetComponent<CardRandomizer>().firstCard = Mood21;
        listMood2.GetComponent<CardRandomizer>().secondCard = Ch3Mood2;

        listPast.GetComponent<CardRandomizer>().Cards.Add(Ch3Past);
        listPast.GetComponent<CardRandomizer>().secondCard = Ch3Past;
        listPast.GetComponent<CardRandomizer>().Cards.Add(Ch3Past2);
        listPast.GetComponent<CardRandomizer>().firstCard = Ch3Past2;

        listProblem.GetComponent<CardRandomizer>().Cards.Add(Ch3Problem);
        listProblem.GetComponent<CardRandomizer>().firstCard = Problem1;
        listProblem.GetComponent<CardRandomizer>().secondCard = Ch3Problem;

        FindObjectOfType<TypeDictionary>().GenerateType();
        //animImage.SetActive(false);
    }

}
