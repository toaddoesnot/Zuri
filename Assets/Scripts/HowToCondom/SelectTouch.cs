using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTouch : MonoBehaviour
{
    public int CircleNum;
    public bool MousePressed;
    public bool CircleSelected;

    public Image image;
    public GameObject self;

    public Patterns patternSc;
    public instructionText textSC;
    public bool gotValue;
    public bool ImChecked;

    public AudioSource blink;
    public bool blinked;

    public bool clear;

    public int arg1;
    public int arg2;
    public int arg3;
    public int arg4;

    private void Start()
    {
        image = GetComponent<Image>();
        patternSc = FindObjectOfType<Patterns>();
        self = this.gameObject;
    }

    public void Update()
    {
        

        if (patternSc.mostRecentNo == arg1 || patternSc.mostRecentNo == arg2 || patternSc.mostRecentNo == arg3 || patternSc.mostRecentNo == arg4)
        {
            //clear = true;
        }
        else
        {
            clear = false;
        }


        if (patternSc.blocked is false)
        {
            if (Input.GetMouseButton(0))
            {
                MousePressed = true;
                ImChecked = false;
            }
            else
            {
                if (ImChecked is false)
                {
                    CheckColors();
                    ImChecked = true;
                }
                MousePressed = false;
                CircleSelected = false;
                gotValue = false;
                patternSc.howManySelected = 0;
            }
        }

    }

    public void OnMouseOver()
    {
        if (clear is false)
        {
            if (MousePressed)
            {
                if (patternSc.ActiveCircles.Contains(self))
                {
                    if (gotValue)
                    {

                    }
                    else
                    {
                        patternSc.howManySelected += 1;
                        gotValue = true;
                    }
                }

                if (CircleSelected)
                {

                }
                else
                {
                    blink.time = 0.14f;
                    blink.Play();
                    image.color = new Color(1f, 1f, 1f, 1f);
                    patternSc.Recent = patternSc.mostRecent;
                    patternSc.mostRecent = self;

                    //patternSc.fullKey = "";
                    patternSc.fullKey += CircleNum;
                    patternSc.lastcombination = patternSc.fullKey;
                    patternSc.thatManySelected = patternSc.howManySelected;

                    CircleSelected = true;
                }
            }

           
        }
    }

    public void CheckColors()
    {
        if (textSC.canProceed)
        {
            foreach (GameObject circle in textSC.circles)
            {
                if (circle.GetComponent<SelectTouch>().CircleSelected)
                {
                    circle.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                }
            }
            foreach (GameObject stick in textSC.sticks)
            {
                if (stick.GetComponent<Sticks>().litUp)
                {
                    stick.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                }
            }
            patternSc.cour = false;
        }
        else
        {
            foreach (GameObject circle in textSC.circles)
            {
                if (circle.GetComponent<SelectTouch>().CircleSelected)
                {
                    circle.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                }
            }

            foreach (GameObject stick in textSC.sticks)
            {
                if (stick.GetComponent<Sticks>().litUp)
                {
                    stick.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                }
            }
            patternSc.cour = false;
        }
    }


   

}
