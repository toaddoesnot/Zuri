using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class howtoTutorial : MonoBehaviour
{
    public int stage;
    public GameObject prevButton;
    public GameObject nextButton; 
    
    public GameObject[] circles;
    public GameObject[] animations;

    public GameObject circleAnim;

    void Update()
    {
        if (stage is 0)
        {
            prevButton.SetActive(false);

            foreach (GameObject circle in circles)
            {
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                circles[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        if (stage is 1)
        {
            circleAnim.SetActive(false);

            prevButton.SetActive(true);

            foreach (GameObject circle in circles)
            {
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                circles[1].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        if (stage is 2)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Next()
    {
        stage++;
        foreach (GameObject anim in animations)
        {
            anim.SetActive(false);
            animations[stage].SetActive(true);
        }
    }

    public void Prev()
    {
        stage--;
        foreach (GameObject anim in animations)
        {
            anim.SetActive(false);
            animations[stage].SetActive(true);
        }
    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene(4);
    }
}
