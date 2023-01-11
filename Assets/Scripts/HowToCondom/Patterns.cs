using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patterns : MonoBehaviour
{
    public bool MousePressed;

    //public List<GameObject> Circles = new List<GameObject>();
    //public List<string> Combinations = new List<string>();

    public string twoNumbers;
    public string fullKey;
    public string lastcombination;

    public GameObject Recent;
    public GameObject mostRecent;

    public List<GameObject> ActiveCircles = new List<GameObject>();
    public int howManySelected;
    public int thatManySelected;
    public instructionText textSc;
    public bool cour;

    public sounds soundSc;
    public bool sounded;

    public GameObject blocker;
    public bool blocked;

    public int mostRecentNo;


    public void Start()
    {
       
    }

    public void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            MousePressed = true;
            mostRecentNo = mostRecent.GetComponent<SelectTouch>().CircleNum;
            sounded = false;
            textSc.nextPressed = false;
            twoNumbers = Recent.GetComponent<SelectTouch>().CircleNum + mostRecent.GetComponent<SelectTouch>().CircleNum.ToString();
        }
        else
        {
            twoNumbers = "";
            fullKey = "";
            Recent = null;
            mostRecent = null;
            MousePressed = false;

            if (cour is false)
            {
                StartCoroutine(AddString2());
                cour = true;
            }

            if (textSc.currentSentence >= 1)
            {
                if (sounded is false)
                {
                    if (textSc.canProceed is true)
                    {
                        soundSc.SoundRight();
                        sounded = true;
                    }
                    else
                    {
                        if (textSc.nextPressed is false)
                        {
                            soundSc.SoundWrong();
                            sounded = true;
                        }
                    }
                }
            }
        }

        if (blocker.activeInHierarchy)
        {
            blocked = true;
        }
        else
        {
            blocked = false;
        }

    }

    public void AddString()
    {
        
    }

    public IEnumerator AddString2()
    {
        
        yield return new WaitForSeconds(0.1f);

        foreach (GameObject circle in textSc.circles)
        {
            circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }

        foreach (GameObject stick in textSc.sticks)
        {
            stick.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

}
