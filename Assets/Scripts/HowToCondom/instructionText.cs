using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class instructionText : MonoBehaviour
{
    public GameObject instructions;
    public List<string> Steps = new List<string>();
    public List<string> FemaleText = new List<string>();

    public int currentSentence;
    public string displaySentence;

    public StepManager stepsScript;

    public bool canProceed;

    public Patterns patternSc;
    public Image buttonNext;

    public GameObject next;
    public GameObject replay;

    public bool animating;

    public GameObject[] circles;
    public GameObject[] sticks;
    public bool done;
    public bool can;

    public GameObject transition;

    public CondomChoice choiceSc;

    // Start is called before the first frame update
    void Start()
    {
        transition.SetActive(true);
        //NextStep();
        circles = GameObject.FindGameObjectsWithTag("Circle");
        sticks = GameObject.FindGameObjectsWithTag("Stick");

        //RightComb();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSentence >= 7)
        {
            stepsScript.Stage5Temp();
            next.SetActive(false);
            replay.SetActive(true);
            //reboot
        }


        if (currentSentence is 1)
        {
            if (patternSc.thatManySelected is 9)
            {
                canProceed = true;
                Steps[1] = "Great! We made sure it is safe to use.";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[1];
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
                Steps[2] = "You never want to use an expired condom.";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[2];
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
                Steps[3] = "Perfect!";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[3];

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
                    Steps[3] = "Tip: It works best from ruffled to the unruffled side.";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[3];
                }
            }
        }

        if (currentSentence is 4)
        {
            stepsScript.condomWrap.SetActive(false);

            if (choiceSc.femaleCon is false)
            {
                if (patternSc.lastcombination is "85" || patternSc.lastcombination is "8115" || patternSc.lastcombination is "1185")
                {
                    canProceed = true;

                    Steps[4] = "That's right!";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[4];

                    ////POSITION////
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
                        Steps[4] = "That looks inside out.";
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[4];
                    }
                    if (patternSc.lastcombination is "58" || patternSc.lastcombination is "118")
                    {
                        foreach (GameObject cond in stepsScript.Positioning)
                        {
                            cond.SetActive(false);
                            stepsScript.Positioning[0].SetActive(true);
                        }
                        Steps[4] = "Do you know how to position it the right way?";
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[4];
                    }
                }
            }
            else
            {
                foreach (GameObject cond in stepsScript.Positioning)
                {
                    cond.SetActive(false);
                }
                    
                stepsScript.condomFem.SetActive(true);

                if (patternSc.lastcombination is "5" || patternSc.lastcombination is "456" || patternSc.lastcombination is "654")//
                {
                    canProceed = true;

                    Steps[4] = "That's right!";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[4];
                }
                else
                {
                    canProceed = false;

                    if (patternSc.lastcombination is "11" || patternSc.lastcombination is "101112" || patternSc.lastcombination is "121110")
                    {
                        Steps[4] = "That’s the thin, outer ring that remains outside of the body.";
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[4];
                    }
                    else
                    {
                        Steps[4] = "Find the inner ring that goes inside the vagina";
                    }
                }
            }

        }

        if (currentSentence is 5)
        {
            if (choiceSc.femaleCon is false)
            {
                print("externals out");
                if (patternSc.lastcombination is "2")
                {
                    stepsScript.pinchedNot.SetActive(false);
                    stepsScript.pinched.SetActive(true);
                    canProceed = true;
                    Steps[5] = "That way the condom will not slide!";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[5];
                }
                else
                {
                    canProceed = false;
                }
            }
            else
            {
                stepsScript.Step3organ.SetActive(false);
                stepsScript.Step3base.SetActive(false);
                stepsScript.pinchedNot.SetActive(false);

                stepsScript.condomFem.SetActive(false);
                stepsScript.placementFull.SetActive(true);
                stepsScript.placementHalf.SetActive(false);

                if (patternSc.lastcombination is "78" || patternSc.lastcombination is "98")
                {
                    stepsScript.placementFull.SetActive(false);
                    stepsScript.placementHalf.SetActive(true);

                    canProceed = true;
                    Steps[5] = "Yes! Similar to a menstrual cup or a tampon";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[5];
                }
                else
                {
                    canProceed = false;
                    stepsScript.placementFull.SetActive(true);
                    stepsScript.placementHalf.SetActive(false);
                }
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
                currentSentence = 7;
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[7];
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

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void FemaleTextActivator()
    {
        Steps[4] = FemaleText[0];
        Steps[5] = FemaleText[1];
        Steps[6] = FemaleText[2];
    }
}
