using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class promptManager : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public GameObject[] docs;
    public narrativeController myDoc;

    public int chosenDoc;
    public int currentLine;

    public bool started;

    public startManager docScript;
    public TilesManager tilesSc;

    public bool doing;

    // Update is called once per frame
    void Update()
    {
        if (started is false)
        {
            chosenDoc = this.GetComponent<startManager>().chosenDoctor;
            if (chosenDoc is not 3)
            {
                myDoc = docs[chosenDoc].GetComponent<narrativeController>();
            }
        }
    }

    public void StartPrompts()
    {
        doing = true;
        StartCoroutine(TypeStart());
        //promptText.text = myDoc.docResponses[0].ToString();
        currentLine++;
        started = true;
    }

    public void generatePromptL()
    {
        doing = true;
        StartCoroutine(TypeSentence());
        //promptText.text = myDoc.docResponses[currentLine].ToString();
        currentLine += 2;
    }

    public void generatePromptR()
    {
        doing = true;
        currentLine++;
        StartCoroutine(TypeSentence());
        //promptText.text = myDoc.docResponses[currentLine].ToString();
        currentLine++;
    }

    public void EndPrompts()
    {
        promptText.text = "";
        StartCoroutine(TypeEnd());
    }

    IEnumerator TypeStart()
    {
        //promptText.text = "";
        foreach (char letter in myDoc.docResponses[0].ToCharArray())
        {
            promptText.text += letter;
            yield return null;
        }
        yield return 1f;
        doing = false;
    }

    IEnumerator TypeSentence()
    {
        promptText.text = "";

        foreach (char letter in myDoc.docResponses[currentLine].ToCharArray())
        {
            if (tilesSc.ended2 is false)
            {
                promptText.text += letter;
            }
            yield return null;
        }
        if (tilesSc.ended2 is true)
        {
            //promptText.text = "";
            //promptText.text = myDoc.specialResponses[2].ToString();
        }
        //yield return 2f;
        doing = false;
    }

    IEnumerator TypeEnd()
    {
        //yield return 0.1f;
        //promptText.text = "";
        yield return 0.2f;
        promptText.text = myDoc.specialResponses[2].ToString();
    }

}
