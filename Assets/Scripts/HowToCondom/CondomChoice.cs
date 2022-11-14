using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondomChoice : MonoBehaviour
{
    public GameObject canvasTwo;
    //public GameObject trans;
    public bool femaleCon;
    public instructionText stepSc;

    //public GameObject tutorialSc;

    public instructionText textSc;
    public AudioSource startSound;

    public GameObject wrongSound;

    public void Start()
    {
        //StartCoroutine(FirstBlock());
        wrongSound.SetActive(false);
    }

    public void InternalCon()
    {
        //Time.timeScale = 1;
        textSc.FemaleTextActivator();
       // tutorialSc.SetActive(true);
        canvasTwo.SetActive(false);

        femaleCon = true;
        //trans.SetActive(false);
       //trans.SetActive(true);
        StartCoroutine(SceneStart());

        stepSc.currentSentence++;
        startSound.Play();
        
    }

    public void ExternalCon()
    {
        //Time.timeScale = 1;
        canvasTwo.SetActive(false);
       // tutorialSc.SetActive(true);

        femaleCon = false;
        //trans.SetActive(false);
       // trans.SetActive(true);
        StartCoroutine(SceneStart());

        stepSc.currentSentence++;
        startSound.Play();
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(1f);
        wrongSound.SetActive(true);
        //trans.GetComponent<quickFix>().Destruction();

    }
    IEnumerator FirstBlock()
    {
        yield return new WaitForSeconds(2.1f);
        //blocker.SetActive(false);
        //Time.timeScale = 0;
    }
}
