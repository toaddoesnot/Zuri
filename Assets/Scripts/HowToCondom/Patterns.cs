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

    public GameObject Recent;
    public GameObject mostRecent;
    

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
            Recent = null;
            mostRecent = null;
            MousePressed = false;
        }


        //twoNumbers = Circles[0].GetComponent<SelectTouch>().CircleNum + Circles[1].GetComponent<SelectTouch>().CircleNum.ToString();
        



    }

    public void AddString()
    {
        //Combinations.Add(twoNumbers);
    }

}
