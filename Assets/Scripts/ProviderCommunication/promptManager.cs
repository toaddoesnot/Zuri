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
        promptText.text = myDoc.docResponses[0].ToString();
        currentLine++;
        started = true;
    }

    public void generatePromptL()
    {
        promptText.text = myDoc.docResponses[currentLine].ToString();
        currentLine += 2;
    }

    public void generatePromptR()
    {
        currentLine++;
        promptText.text = myDoc.docResponses[currentLine].ToString();
        currentLine++;
    }

    public void EndPrompts()
    {
        promptText.text = myDoc.specialResponses[2].ToString();
    }

}
