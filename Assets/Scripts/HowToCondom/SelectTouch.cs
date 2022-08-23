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
            image.color = new Color(1f, 1f, 1f, 0.5f);
            CircleSelected = false;
        }
    }

    public void OnMouseEnter()
    {
        if (MousePressed)
        {
            if (CircleSelected)
            {
                patternSc.Recent = patternSc.mostRecent;
                patternSc.mostRecent = self;
            }
            else
            {
                image.color = new Color(1f, 1f, 1f, 1f);

                ///patternSc.Circles.Add(self);
                patternSc.Recent = patternSc.mostRecent;
                patternSc.mostRecent = self;

                CircleSelected = true;
            }
            
        }
    }
}
