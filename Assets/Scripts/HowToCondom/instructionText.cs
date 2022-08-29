using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class instructionText : MonoBehaviour
{
    public GameObject instructions;
    public List<string> Steps = new List<string>();

    public int currentSentence;
    public string displaySentence;

    public StepManager stepsScript;

    public bool canProceed;

    public Patterns patternSc;
    public Image buttonNext;

    public bool animating;

    public GameObject[] circles;

    // Start is called before the first frame update
    void Start()
    {
        NextStep();
        //RightComb();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSentence >= 7)
        {
            stepsScript.Stage5Temp();
            //reboot
        }


        if (currentSentence is 1)
        {
            ///if 2 check tears - if contains 456987101112 then go
            ///
            
                if(patternSc.thatManySelected is 9)
                {
                   canProceed = true;
                }
                else
                {
                   canProceed = false;
                }
        }

        if (currentSentence is 2)
        {
            if (patternSc.lastcombination is "1112" || patternSc.lastcombination is "1211")
            {
                canProceed = true;
            }
            else
            {
                canProceed = false;
            }
        }

        if (currentSentence is 3)
        {
            if (patternSc.lastcombination is "6912" || patternSc.lastcombination is "1296" || patternSc.lastcombination is "4710" || patternSc.lastcombination is "1074")
            {
                canProceed = true;
                
                if (animating)
                {

                }
                else
                {
                    stepsScript.Step1.GetComponent<Animation>().Play();
                    animating = true;
                    //NextStep();
                }
                
            }
            else
            {
                canProceed = false;

                if (patternSc.lastcombination is "456" || patternSc.lastcombination is "654" || patternSc.lastcombination is "101112" || patternSc.lastcombination is "121110")
                {
                    //rubbersidetext true
                }
            }
        }

        if (currentSentence is 4)
        {
            if (patternSc.lastcombination is "85" || patternSc.lastcombination is "8115" || patternSc.lastcombination is "1185")
            {
                canProceed = true;
                foreach (GameObject cond in stepsScript.Positioning)
                {
                    cond.SetActive(false);
                    stepsScript.Positioning[1].SetActive(true);
                }
            }
            else
            {
                canProceed = false;

                if (patternSc.lastcombination is "811" || patternSc.lastcombination is "5811" || patternSc.lastcombination is "8511")
                {
                    foreach (GameObject cond in stepsScript.Positioning)
                    {
                        cond.SetActive(false);
                        stepsScript.Positioning[2].SetActive(true);
                    }
                }
                if (patternSc.lastcombination is "58" || patternSc.lastcombination is "118")
                {
                    foreach (GameObject cond in stepsScript.Positioning)
                    {
                        cond.SetActive(false);
                        stepsScript.Positioning[0].SetActive(true);
                    }
                }
            }
        }

        if (currentSentence is 5)
        {
            if (patternSc.lastcombination is "2")
            {
                stepsScript.pinchedNot.SetActive(false);
                stepsScript.pinched.SetActive(true);
                canProceed = true;
            }
            else
            {
                canProceed = false;
            }
        }

        if (currentSentence is 6)
        {
            //if 2 is hold and if 58 then 1 if 5811 then 2 if 581114
            if (patternSc.lastcombination is "25")
            {
                canProceed = false;
                stepsScript.pinched.SetActive(false);
                stepsScript.Step3base.SetActive(false);
                foreach (GameObject con in stepsScript.CondomStart)
                {
                    con.SetActive(false);
                    stepsScript.CondomStart[0].SetActive(true);
                }
            }
            if (patternSc.lastcombination is "258")
            {
                canProceed = false;
                foreach(GameObject con in stepsScript.CondomStart)
                {
                    con.SetActive(false);
                    stepsScript.CondomStart[1].SetActive(true);
                }
            }
            if (patternSc.lastcombination is "25811")
            {
                canProceed = false;
                foreach (GameObject con in stepsScript.CondomStart)
                {
                    con.SetActive(false);
                    stepsScript.CondomStart[2].SetActive(true);
                }
            }
            if (patternSc.lastcombination is "2581114")
            {
                canProceed = true;
                foreach (GameObject con in stepsScript.CondomStart)
                {
                    con.SetActive(false);
                    stepsScript.CondomStart[3].SetActive(true);
                }
            }
            else
            {
                canProceed = false;
            }
        }

        if (canProceed)
        {
            //make button normal
            buttonNext.color = new Color(buttonNext.color.r, buttonNext.color.g, buttonNext.color.b, 1f);
        }
        else
        {
            //make button transparent
            buttonNext.color = new Color(buttonNext.color.r, buttonNext.color.g, buttonNext.color.b, .5f);
        }
    }

    public void NextStep()
    {
        if (canProceed)
        {
            if (currentSentence is 3)
            {
                //stepsScript.Stage2();
                stepsScript.Step1.SetActive(false);
                stepsScript.Positioning[0].SetActive(true);

                currentSentence++;
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
            }
            else
            {
                if (currentSentence is 4)
                {
                    //if 2 then ok
                    //stepsScript.Stage3();

                    foreach (GameObject con in stepsScript.Positioning)
                    {
                        con.SetActive(false);
                    }
                    stepsScript.Step3organ.SetActive(true);
                    stepsScript.Step3base.SetActive(true);
                    stepsScript.pinchedNot.SetActive(true);

                    currentSentence++;
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                }
                else
                {
                    if (currentSentence is 5)
                    {
                        //if 2 is hold and if 58 then 1 if 5811 then 2 if 581114
                        //stepsScript.Stage4();
                        

                        currentSentence++;
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                    }
                    else
                    {
                        currentSentence++;
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                    }
                }
            }



        }
    }

    public void RightComb()
    {
        circles = GameObject.FindGameObjectsWithTag("Circle");
    }
    public void WrongComb()
    {

    }

}
