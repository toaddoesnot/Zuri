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
    public GameObject[] pieces;

    public int chosenDoctor;
    public GameObject secondCanvas;
    public GameObject whiteBg;

    public TilesManager tilesSc;
    public promptManager promptSc;
    public GameObject fastTile;

    public void Update()
    {
        if (chosenDoctor is 0 || chosenDoctor is 1 || chosenDoctor is 2)
        {
            foreach (GameObject way in ways)
            {
                way.SetActive(false);
                ways[chosenDoctor].SetActive(true);
            }
        }
    }

    public void Provider1()
    {
        chosenDoctor = 0;
        doctors[1].SetActive(false);
        doctors[2].SetActive(false);

        tilesSc.OnTile = 11;
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
        doctors[0].SetActive(false);
        doctors[2].SetActive(false);

        tilesSc.OnTile = 3;
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
        doctors[1].SetActive(false);
        doctors[0].SetActive(false);

        tilesSc.OnTile = 10;
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        changingPlaque[2].SetActive(true);
        changingPlaque[2].GetComponent<Animation>().Play("slidingPlaque_2");
    }

    public void Back()
    {
        doctors[1].SetActive(true);
        doctors[0].SetActive(true);
        doctors[2].SetActive(true);

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

        promptSc.StartPrompts();

        StartCoroutine(Scheduled());

        tilesSc.newLway = pieces[chosenDoctor].GetComponent<tileController>().LWay;
        tilesSc.newRway = pieces[chosenDoctor].GetComponent<tileController>().RWay;

        foreach (GameObject tile in pieces)
        {
            tile.SetActive(true);
            pieces[chosenDoctor].SetActive(false);
        }

        if (chosenDoctor is 1)
        {
            fastTile.GetComponent<tileController>().fastPass = true;
        }
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
