using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GenderChanger : MonoBehaviour
{
    public GameObject arrow;
    public Sprite left;
    public Sprite right;

    public GameObject boy1;
    public GameObject boy2;
    public GameObject boy3;
    public GameObject girl1;
    public GameObject girl2;
    public GameObject girl3;

    public GameObject boySkeleton;
    public GameObject girlSkeleton;

    public StartChoice choiceSc;
    public Sprite girlOrange;
    public Sprite girlPink;
    public Sprite girlGrey;

    public bool females;

    public CardTrigger[] allFemaleCards;
    public bool DoneThing;
    public bool DoneBoys;

    public TextMeshProUGUI femTxt;
    public TextMeshProUGUI maleTxt;

    public void Start()
    {
        boySkeleton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        foreach (CardTrigger female in allFemaleCards)
        {
            female.StartFemales();
        }
        //allFemaleCards = FindObjectsOfType<CardTrigger>();
    }

    public void Update()
    {
        if (females)
        {
            DoneBoys = false;

        }
        else
        {
            if (DoneBoys is false)
            {
                foreach (CardTrigger female in allFemaleCards)
                {
                    female.ReturnMales();
                    DoneBoys = true;
                }

            }
            
        }


        if (choiceSc.partnerPink)
        {
            girlSkeleton.GetComponent<SpriteRenderer>().sprite = girlPink;
            if (DoneThing is false)
            {
                foreach (CardTrigger female in allFemaleCards)
                {
                    female.StartFemales();
                    DoneThing = true;
                }
            }
            else
            {

            }
        }
        if (choiceSc.partnerGrey)
        {
            girlSkeleton.GetComponent<SpriteRenderer>().sprite = girlGrey;
            if (DoneThing is false)
            {
                foreach (CardTrigger female in allFemaleCards)
                {
                    female.StartFemales();
                    DoneThing = true;
                }
            }
            else
            {

            }
        }
        if (choiceSc.partnerOrange)
        {
            if (DoneThing is false)
            {
                foreach (CardTrigger female in allFemaleCards)
                {
                    female.StartFemales();
                    DoneThing = true;
                }
            }
            else
            {

            }
        }
    }

    public void GenderButton()
    {
        if (females)
        {
            females = false;

            girlSkeleton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            boySkeleton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

            arrow.GetComponent<Image>().sprite = right;

            girl1.SetActive(false);
            girl2.SetActive(false);
            girl3.SetActive(false);

            boy1.SetActive(true);
            boy2.SetActive(true);
            boy3.SetActive(true);
        }
        else
        {
            females = true;

            girlSkeleton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            boySkeleton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

            arrow.GetComponent<Image>().sprite = left;

            girl1.SetActive(true);
            girl2.SetActive(true);
            girl3.SetActive(true);

            boy1.SetActive(false);
            boy2.SetActive(false);
            boy3.SetActive(false);
        }
    }
}
