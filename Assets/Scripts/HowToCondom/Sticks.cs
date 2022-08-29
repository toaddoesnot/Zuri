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

    public bool rightstick;
    public bool wrongstick;

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

            if (wrongstick)
            {
                image.color = new Color32(220, 153, 160, 255);
            }
            else
            {
                if (rightstick)
                {
                    image.color = new Color32(193, 232, 225, 255);
                }
                else
                {
                    image.color = new Color(1f, 1f, 1f, 0.5f);
                }
            }
        } 
    }
}
