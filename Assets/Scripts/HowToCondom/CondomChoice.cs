using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondomChoice : MonoBehaviour
{
    public GameObject canvasTwo;
    public bool femaleCon;
    public instructionText stepSc;

    public instructionText textSc;
    public AudioSource startSound;

    public GameObject wrongSound;

    public void Start()
    {
        wrongSound.SetActive(false);
    }

    public void InternalCon()
    {
        textSc.FemaleTextActivator();
        canvasTwo.SetActive(false);

        femaleCon = true;
        StartCoroutine(SceneStart());

        stepSc.currentSentence++;
        startSound.Play();
        
    }

    public void ExternalCon()
    {
        canvasTwo.SetActive(false);

        femaleCon = false;
        StartCoroutine(SceneStart());

        stepSc.currentSentence++;
        startSound.Play();
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(1f);
        wrongSound.SetActive(true);

    }
    IEnumerator FirstBlock()
    {
        yield return new WaitForSeconds(2.1f);
    }
}
