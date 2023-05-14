using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipsMaanger : MonoBehaviour
{
    public instructionText textSc;
    public CondomChoice choiceSc;

    public float totalTime;
    public bool DoneTip;

    //Step1
    //all of them

    //Step2
    public GameObject second;

    //Step3
    //two circles

    //Step4
    //two circles

    //Step5
    public GameObject lineS;
    public GameObject lineB;

    public bool needHelp;

    public void Update()
    {

        if (textSc.currentSentence >= 1)
        {
            totalTime += Time.deltaTime;
        }

        if (textSc.canProceed is false)
        {
            if (totalTime >= 20)
            {
                if (totalTime >= 30)
                {
                    lineB.SetActive(false);
                    lineS.SetActive(false);

                    DoneTip = true;
                }
                else
                {
                    if (DoneTip is false)
                    {
                        if (textSc.currentSentence is 3)
                        {
                            if (choiceSc.femaleCon is true)
                            {
                                lineB.SetActive(true);
                            }
                            else
                            {
                                lineS.SetActive(true);
                            }
                        }
                            DoneTip = true;
                    }
                }
            }
        }
    }

    public void Reset()
    {

    }

    public void StepOne()
    {

    }
    public void StepTwo()
    {

    }
    public void StepThree()
    {
        
    }
    public void StepFour()
    {

    }
    public void StepFive()
    {

    }


}
