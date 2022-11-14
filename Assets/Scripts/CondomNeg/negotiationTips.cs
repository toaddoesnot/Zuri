using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            arrow.SetActive(true);
            drawCard.GetComponent<Animation>().Play();
            StartCoroutine(takeAnimation());
        }
    }

    public IEnumerator takeAnimation()
    {
        yield return new WaitForSeconds(1);
        arrow.SetActive(false);
    }

}
