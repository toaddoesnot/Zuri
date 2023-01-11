            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class negotiationTips : MonoBehaviour
{
    public GameObject drawCard;
    public GameObject arrow;

    public AudioSource wrongy;
    public AudioSource righty;

    public GameObject argumentObj;
    public ArgumentSlot slotSc;
    public GameObject drawObj;
    public CardDrawer drawSc;
    public bool canProceed;

    public GameObject takeAnim;
    public TextMeshProUGUI tipTxt;
    public TypeDictionary dictSc;

    // Start is called before the first frame update
    void Start()
    {
        slotSc = argumentObj.GetComponent<ArgumentSlot>();
        drawSc = drawObj.GetComponent<CardDrawer>();
    }

    public void Update()
    {
        if (slotSc.snatched || drawSc.cardDrawn)
        {
            canProceed = true;
            takeAnim.SetActive(false);
        }
        else
        {
            canProceed = false;
        }
    }

    public void Take()
    {
         if (canProceed)
        {
            righty.Play();
        }

        else
        {
            wrongy.Play();

            //arrow.SetActive(true);
            takeAnim.SetActive(true);
            tipTxt.text = "If you don't have a right color, drag one of the cards to the Draw area";
            StartCoroutine(takeAnimation());

            drawCard.GetComponent<Animation>().Play();
            
        }
    }

    public IEnumerator takeAnimation()
    {
        yield return new WaitForSeconds(4.35f);
        //arrow.SetActive(false);
        takeAnim.SetActive(false);
        tipTxt.text = "Drag cards into your bubble to respond";
    }


}
