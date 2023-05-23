using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public instructionText textScript;

    public GameObject gridIm;

    public GameObject Step1;
    public GameObject Step3organ;
    public GameObject Step3base;
    public GameObject pinchedNot;
    public GameObject pinched;
  
    public GameObject[] Positioning;
    public GameObject[] CondomStart;

    public CondomChoice choiceSc;

    public GameObject condomWrap;
    public GameObject condomFem;

    public GameObject placementFull;
    public GameObject placementHalf;
    public GameObject placementHalf2;

    public GameObject[] PutInternally;
    public GameObject femaleVegBg;
    public GameObject femaleConStart;
    public GameObject femaleConDone;

    public GameObject Step5;

    // public Animation openCondom;


    public void Stage1()
    {
        if (choiceSc.femaleCon is true)
        {
            condomWrap.SetActive(true);
        }
        else
        {
            Step1.SetActive(true);
            //gridIm.SetActive(true);
        }
        
        if (textScript.currentSentence is 2)
        {
            //textScript.canProceed = false;
        }
    }
    public void Stage2()
    {
        print("henlo");
        
    }

    public void Stage3()
    {
        if (choiceSc.femaleCon is false)
        {
            
            Step3organ.SetActive(true);
            Step3base.SetActive(true);
            pinchedNot.SetActive(true);
        }
        else
        {
            Step3organ.SetActive(false);
            Step3base.SetActive(false);
            pinchedNot.SetActive(false);
        }
    
    }
    public void Stage4()
    {
        //Step3base.SetActive(false);
        //pinchedNot.SetActive(false);
    }

    public void Stage5Temp()
    {
        Step3base.SetActive(false);
        pinchedNot.SetActive(false);
    }

}
