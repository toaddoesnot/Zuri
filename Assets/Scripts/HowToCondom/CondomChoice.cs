using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondomChoice : MonoBehaviour
{
    public GameObject canvasTwo;
    public GameObject trans;
    public bool femaleCon;

    public GameObject tutorialSc;

    public instructionText textSc;

    public void Start()
    {
        //StartCoroutine(FirstBlock());
    }

    public void InternalCon()
    {
        //Time.timeScale = 1;
        textSc.FemaleTextActivator();
        tutorialSc.SetActive(true);
        canvasTwo.SetActive(false);

        femaleCon = true;
        trans.SetActive(false);
       trans.SetActive(true);
        StartCoroutine(SceneStart());
    }

    public void ExternalCon()
    {
        //Time.timeScale = 1;
        canvasTwo.SetActive(false);
        tutorialSc.SetActive(true);

        femaleCon = false;
        trans.SetActive(false);
        trans.SetActive(true);
        StartCoroutine(SceneStart());
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(2);
        trans.GetComponent<quickFix>().Destruction();
        
    }
    IEnumerator FirstBlock()
    {
        yield return new WaitForSeconds(2.1f);
        //blocker.SetActive(false);
        //Time.timeScale = 0;
    }
}
