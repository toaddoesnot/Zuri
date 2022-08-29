using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public instructionText textScript;

    public GameObject Step1;
    public GameObject Step3organ;
    public GameObject Step3base;
    public GameObject pinchedNot;
    public GameObject pinched;
  
    public GameObject[] Positioning;
    public GameObject[] CondomStart;

    // public Animation openCondom;


    private void Start()
    {
        Stage1();
    }

    public void Stage1()
    {
        Step1.SetActive(true);
        if (textScript.currentSentence is 2)
        {
           // textScript.canProceed = false;
        }
    }
    public void Stage2()
    {
        print("henlo");
        
    }
    public void Stage3()
    {
        Step3organ.SetActive(true);
        Step3base.SetActive(true);
        pinchedNot.SetActive(true);
}
    public void Stage4()
    {
        //Step3base.SetActive(false);
       // pinchedNot.SetActive(false);
    }

    public void Stage5Temp()
    {
        Step3base.SetActive(false);
        pinchedNot.SetActive(false);
    }

}
