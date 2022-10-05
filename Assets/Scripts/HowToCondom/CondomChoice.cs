using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondomChoice : MonoBehaviour
{
    public GameObject canvasTwo;
    public GameObject trans;
    public bool femaleCon;

    public instructionText textSc;

    public void Start()
    {
        
    }
    public void InternalCon()
    {
        textSc.FemaleTextActivator();

        canvasTwo.SetActive(false);
        femaleCon = true;
        trans.SetActive(false);
        trans.SetActive(true);
        StartCoroutine(SceneStart());
    }

    public void ExternalCon()
    {
        canvasTwo.SetActive(false);
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
}
