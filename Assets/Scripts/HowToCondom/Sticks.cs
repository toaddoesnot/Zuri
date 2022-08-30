using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticks : MonoBehaviour
{
    public SelectTouch circle1;
    public SelectTouch circle2;

    public Image image;

    public Patterns patternsSc;
    public bool litUp;

    public string myTrigger;
    public string myTrigger2;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        patternsSc = FindObjectOfType<Patterns>();
    }

    // Update is called once per frame
    void Update()
    {
        if (patternsSc.MousePressed)
        {
            if (litUp)
            {

            }
            else
            {

                if (myTrigger == patternsSc.twoNumbers || myTrigger2 == patternsSc.twoNumbers)
                {
                    image.color = new Color(1f, 1f, 1f, 1f);
                    litUp = true;
                }
            }
        }
        else
        {
            litUp = false;
        } 
    }
}
