using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startManager : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] changingPlaque;
    public GameObject[] doctors;
    public GameObject[] ways;

    public int chosenDoctor;
    public GameObject secondCanvas;
    public GameObject whiteBg;

    public void Update()
    {
        foreach (GameObject doc in doctors)
        {
            doc.SetActive(false);
            doctors[chosenDoctor].SetActive(true);
            ways[chosenDoctor].SetActive(true);
        }
        foreach (GameObject way in ways)
        {
            way.SetActive(false);
            ways[chosenDoctor].SetActive(true);
        }
    }

    public void Provider1()
    {
        chosenDoctor = 0;
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        changingPlaque[0].SetActive(true);
        changingPlaque[0].GetComponent<Animation>().Play("slidingPlaque");
    }

    public void Provider2()
    {
        chosenDoctor = 1;
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        changingPlaque[1].SetActive(true);
        changingPlaque[1].GetComponent<Animation>().Play("slidingPlaque_1");
    }

    public void Provider3()
    {
        chosenDoctor = 2;
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        changingPlaque[2].SetActive(true);
        changingPlaque[2].GetComponent<Animation>().Play("slidingPlaque_2");
    }

    public void Back()
    {
        if (chosenDoctor is 0)
        {
            changingPlaque[0].GetComponent<Animation>().Play("DEslidingPlaque");
        }
        if (chosenDoctor is 1)
        {
            changingPlaque[1].GetComponent<Animation>().Play("DEslidingPlaque_1");
        }
        if (chosenDoctor is 2)
        {
            changingPlaque[2].GetComponent<Animation>().Play("DEslidingPlaque_2");
        }
        StartCoroutine(ReturnButtons());
    }

    public void Schedule()
    {
        secondCanvas.SetActive(false);
        whiteBg.GetComponent<Animation>().Play("canvasFade");
        StartCoroutine(Scheduled());
    }

    public IEnumerator ReturnButtons()
    {
        yield return new WaitForSeconds(0.65f);
        changingPlaque[chosenDoctor].SetActive(false);
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
        chosenDoctor = 3;
    }

    public IEnumerator Scheduled()
    {
        yield return new WaitForSeconds(0.65f);
        whiteBg.SetActive(false);
    }

}
