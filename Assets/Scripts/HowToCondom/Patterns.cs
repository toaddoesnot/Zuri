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

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MousePressed = true;
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
            
        }
    }

    public void AddString()
    {
        
    }

    public IEnumerator AddString2()
    {
        
        yield return new WaitForSeconds(1f);

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
