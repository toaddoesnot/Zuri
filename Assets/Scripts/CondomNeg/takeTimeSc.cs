using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class takeTimeSc : MonoBehaviour
{
    public float totalTime;
    public GameObject takeAnim;

    public bool DoneTip;
    public TextMeshProUGUI tipTxt;

    public TypeDictionary dictSc;
    public negotiationTips paramSc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dictSc.Round >= 1)
        {
            totalTime += Time.deltaTime;
        }

        if (paramSc.canProceed is false)
        {
            if (totalTime >= 20)
            {
                if (totalTime >= 30)
                {
                    takeAnim.SetActive(false);
                    tipTxt.text = "Drag cards into your bubble to respond";
                    DoneTip = true;
                }
                else
                {
                    if (DoneTip is false)
                    {
                        takeAnim.SetActive(true);
                        tipTxt.text = "If you don't have a right color, drag one of the cards to the Draw area";
                        DoneTip = true;
                    }
                }
            }
        }

        
    }
}
