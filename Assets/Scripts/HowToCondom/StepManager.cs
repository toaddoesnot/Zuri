using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public instructionText textScript;

    public GameObject Step1;
   // public Animation openCondom;
    
    public GameObject Step2;
    public GameObject Step2right;
    public GameObject Step2wrong;

    public GameObject Step3organ;
    public GameObject Step3base;
    public GameObject pinchedNot;
    public GameObject pinched;
    
    public GameObject con1;
    public GameObject con2;
    public GameObject con3;
    public GameObject con4;

    public int fullcheck; 
    public int expiration;
    public int placeRight;
    public int placeWrong;
    public int placement;
    public int pinchSpot;
    public int condom1;
    public int condom2;
    public int condom3;
    public int condom4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stage1()
    {
        if(textScript.currentSentence is 2)
        {
           // textScript.canProceed = false;
        }
    }
    public void Stage2()
    {
        Step1.SetActive(false);
        Step2.SetActive(true);
    }
    public void Stage3()
    {
        Step2.SetActive(false);
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
        con4.SetActive(true);
    }

}
