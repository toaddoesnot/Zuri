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

    //public GameObject transition;

    public CondomChoice choiceSc;
    public bool NowIsTime;

    public bool nextPressed;
    public AudioSource nextSong;

    public GameObject refPos;
    public GameObject nextaAnim;
    public GameObject blocker;
    public bool ready4anim;

    public GameObject starsUp;
    public GameObject starsDown;
    public bool starsUpDone;
    public bool starsDownDone;

    public tipsMaanger tipsSc;
    public GameObject[] trinkets;

    public pauseBlocker blockerSc;

    // Start is called before the first frame update
    void Start()
    {
        blocker.SetActive(false);
        circles = GameObject.FindGameObjectsWithTag("Circle");
        sticks = GameObject.FindGameObjectsWithTag("Stick");
        //RightComb();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSentence < 7)
        {
            if (canProceed)
            {
                if (patternSc.MousePressed is false)
                {
                    blocker.SetActive(true);
                }
            }
            else
            {
                if (blockerSc.paused)
                {
                    blocker.SetActive(true);
                    circles[7].GetComponent<SelectTouch>().MousePressed = false;
                    circles[14].GetComponent<SelectTouch>().MousePressed = false;
                }
                else
                {
                    blocker.SetActive(false);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) is false)
        {
            if (NowIsTime)
            {
                stepsScript.PutInternally[3].SetActive(false);
                stepsScript.femaleConDone.SetActive(true);
            }

        }


        if (currentSentence >= 7)
        {
            if (patternSc.MousePressed is false)
            {
                blocker.SetActive(true);
            }
            stepsScript.Stage5Temp();
            next.SetActive(false);
            replay.SetActive(true);
            //reboot
        }


        if (currentSentence is 1)
        {
            stepsScript.Stage1();

            stepsScript.gridIm.transform.position = refPos.transform.position;
           // choiceSc.tutorialSc.SetActive(false);

            if (patternSc.thatManySelected is 9)
            {
                canProceed = true;

                Steps[1] = "Great! We made sure it is safe to use.";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[1];
            }
            else
            {
                canProceed = false;

                Steps[1] = "First, make sure there are no tears or defects on a package.";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[1];
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
                Steps[2] = "Is the expiration date ok?";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[2];
            }
        }

        if (currentSentence is 3)
        {
            if (patternSc.lastcombination is "6912" || patternSc.lastcombination is "1296" || patternSc.lastcombination is "4710" || patternSc.lastcombination is "1074" || patternSc.lastcombination is "1512963" || patternSc.lastcombination is "3691215" || patternSc.lastcombination is "1471013" || patternSc.lastcombination is "1310741" || patternSc.lastcombination is "691215" || patternSc.lastcombination is "12963" ||  patternSc.lastcombination is "471013" || patternSc.lastcombination is "10741")
            {
                canProceed = true;
                Steps[3] = "Perfect!";
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[3];

                if (patternSc.MousePressed is false)
                {
                    blocker.SetActive(true);
                }

                if (animating)
                {

                }
                else
                {
                    stepsScript.Step1.GetComponent<Animation>().Play();
                    stepsScript.Step5.GetComponent<Animation>().Play();
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
            //blocker.SetActive(false);
            stepsScript.condomWrap.SetActive(false);

            if (choiceSc.femaleCon is false)
            {
                trinkets[0].GetComponent<SelectTouch>().clear = false;

                if (patternSc.lastcombination is "85" || patternSc.lastcombination is "8115" || patternSc.lastcombination is "1185" || patternSc.lastcombination is "852" || patternSc.lastcombination is "11852")
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
                    stepsScript.Step5.SetActive(false);
                    

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
                trinkets[1].GetComponent<SelectTouch>().clear = false;
                trinkets[2].GetComponent<SelectTouch>().clear = false;

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
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[4];
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
                    if (patternSc.MousePressed is false)
                    {
                        blocker.SetActive(true);
                    }

                }
                else
                {
                    canProceed = false;
                    stepsScript.condomFem.SetActive(false);
                    Steps[5] = "Let the air out of the tip.";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[5];
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
                stepsScript.placementHalf2.SetActive(false);

                if (patternSc.lastcombination is "78" || patternSc.lastcombination is "98")
                {
                    stepsScript.placementFull.SetActive(false);

                    stepsScript.placementHalf.SetActive(true);
                    stepsScript.placementHalf2.SetActive(false);
                    canProceed = true;
                    Steps[5] = "Yes! Similar to a menstrual cup or a tampon";
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[5];
                }
                else
                {
                    if (patternSc.lastcombination is "58" || patternSc.lastcombination is "118")
                    {
                        canProceed = true;
                        Steps[5] = "Yes! Similar to a menstrual cup or a tampon";
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[5];

                        stepsScript.placementFull.SetActive(false);
                        stepsScript.placementHalf.SetActive(false);
                        stepsScript.placementHalf2.SetActive(true);
                    }
                    else
                    {
                        canProceed = false;

                        Steps[5] = "Squeeze the inner ring with your thumb and forefinger.";
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[5];

                        stepsScript.placementFull.SetActive(true);
                        stepsScript.placementHalf.SetActive(false);
                    }
                    
                }
            }
        }

        if (currentSentence is 6)
        {
            blocker.SetActive(false);
            stepsScript.placementHalf.SetActive(false);
            stepsScript.placementHalf2.SetActive(false);

            if (choiceSc.femaleCon is false)
            {

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
                    foreach (GameObject con in stepsScript.CondomStart)
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
            else
            {
                //// PUTTING IN FEMALE CONDOM ////
                stepsScript.femaleVegBg.SetActive(true);
                stepsScript.femaleConStart.SetActive(true);

                if (patternSc.lastcombination is "1411")
                {
                    //canProceed = false;
                    stepsScript.pinched.SetActive(false);
                    stepsScript.Step3base.SetActive(false);
                    foreach (GameObject con in stepsScript.PutInternally)
                    {
                        con.SetActive(false);
                        stepsScript.PutInternally[0].SetActive(true);
                    }
                }
                if (patternSc.lastcombination is "14118")
                {
                    //canProceed = false;
                    foreach (GameObject con in stepsScript.PutInternally)
                    {
                        con.SetActive(false);
                        stepsScript.PutInternally[1].SetActive(true);
                    }
                }
                if (patternSc.lastcombination is "141185")
                {
                    //canProceed = false;
                    foreach (GameObject con in stepsScript.PutInternally)
                    {
                        con.SetActive(false);
                        stepsScript.PutInternally[2].SetActive(true);
                    }
                }
                if (patternSc.lastcombination is "1411852")
                {
                    canProceed = true;
                    canProceed = true;
                    //Steps[6] = "It will get positioned correctly once you let go!";
                   
                    currentSentence = 7;
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[7];
                    foreach (GameObject con in stepsScript.PutInternally)
                    {
                        con.SetActive(false);
                        stepsScript.PutInternally[3].SetActive(true);
                    }
                    NowIsTime = true;
                }
                else
                {
                    canProceed = false;

                }
            }
                
        }

        if (canProceed)
        {
            //public GameObject starsUp;
            // public GameObject starsDown;
            //public bool starsUpDone;
            //public bool starsDownDone;

            if(currentSentence is >= 1 && currentSentence is <= 6)
            {
                if (starsUpDone is false)
                {
                    starsUp.SetActive(true);
                    starsDown.SetActive(true);
                    StartCoroutine(Starry());
                }
            }
            

            buttonNext.color = new Color(buttonNext.color.r, buttonNext.color.g, buttonNext.color.b, 1f);
            
            if (patternSc.MousePressed is true)
            {
                //if (ready4anim is false)
                    //ready4anim = true;
            }
            else
            {
                //blocker.SetActive(true);
                if (currentSentence <= 3)
                {
                    nextaAnim.SetActive(true); //TIPS
                }
            }
        }
        else
        {
            //make button transparent
            buttonNext.color = new Color(buttonNext.color.r, buttonNext.color.g, buttonNext.color.b, .5f);
            //blocker.SetActive(false);
            nextaAnim.SetActive(false);
            starsUpDone = false;
        }
    }

    public void NextStep()
    {
        nextPressed = true;
        

        if (canProceed)
        {
            nextSong.Play();

            if (currentSentence is 3)
            {
                //stepsScript.Stage2();
                stepsScript.Step1.SetActive(false);
                stepsScript.Positioning[0].SetActive(true);

                currentSentence++;
                tipsSc.totalTime = 0;
                tipsSc.DoneTip = false;
                instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                //nextPressed = false;
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
                    tipsSc.totalTime = 0;
                    tipsSc.DoneTip = false;
                    instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                    //nextPressed = false;
                }
                else
                {
                    if (currentSentence is 5)
                    {
                        currentSentence++;
                        tipsSc.totalTime = 0;
                        tipsSc.DoneTip = false;
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                        //nextPressed = false;
                    }
                    else
                    {
                        currentSentence++;
                        tipsSc.totalTime = 0;
                        tipsSc.DoneTip = false;
                        instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];
                        //nextPressed = false;
                    }
                }
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(4);
    }

    public void FemaleTextActivator()
    {
        Steps[4] = FemaleText[0];
        Steps[5] = FemaleText[1];
        Steps[6] = FemaleText[2];
    }

    IEnumerator Starry()
    {
        yield return new WaitForSeconds(1f);
        starsUp.SetActive(false);
        starsDown.SetActive(false);
        starsUpDone = true;
    }


}
