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

    public bool gotValue;
    public bool wrongling;
    public bool rightling;

    private void Start()
    {
        
        image = GetComponent<Image>();
        patternSc = FindObjectOfType<Patterns>();
        self = this.gameObject;
    }
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MousePressed = true;
        }
        else
        {
            MousePressed = false;

            if (wrongling)
            {
                image.color = new Color32(220, 153, 160, 255);
            }
            else
            {
                if (rightling)
                {
                    image.color = new Color32(193, 232, 225, 255);
                }
                else
                {
                    image.color = new Color(1f, 1f, 1f, 0.5f);
                }
            }

            CircleSelected = false;

            gotValue = false;
            patternSc.howManySelected = 0;
        }
    }

    public void OnMouseOver()
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
