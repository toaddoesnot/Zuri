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
    public string newLine;
    public int lineNom;

    public bool started;

    public startManager docScript;
    public TilesManager tilesSc;

    public bool doing;

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
        currentLine++;
        started = true;
    }

    public void generatePromptL()
    {
        doing = true;
        StartCoroutine(TypeSentence());
        currentLine += 2;
    }

    public void generatePromptR()
    {
        doing = true;
        currentLine++;
        StartCoroutine(TypeSentence());
        currentLine++;
    }

    public void EndPrompts()
    {
        promptText.text = "";
        StartCoroutine(TypeEnd());
    }

    IEnumerator TypeStart()
    {
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
        newLine = myDoc.docResponses[lineNom];

        promptText.text = "";

        foreach (char letter in myDoc.docResponses[lineNom].ToCharArray())
        {
            if (tilesSc.ended2 is false)
            {
                promptText.text += letter;
            }
            yield return null;
        }
        
        doing = false;
    }

    IEnumerator TypeEnd()
    {
        yield return null;
        promptText.text = myDoc.specialResponses[2].ToString();
    }

}
