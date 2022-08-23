using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class instructionText : MonoBehaviour
{
    public GameObject instructions;
    public List<string> Steps = new List<string>();
    public int currentSentence;
    public string displaySentence;

    public StepManager stepsScript;

    public bool canProceed;

    // Start is called before the first frame update
    void Start()
    {
        NextStep();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSentence >= 10)
        {
            stepsScript.Stage5Temp();
            //reboot
        }
    }

    public void NextStep()
    {
        if (canProceed)
        {
            currentSentence++;
            instructions.GetComponent<TextMeshProUGUI>().text = Steps[currentSentence];

            if(currentSentence is 2 || currentSentence is 3 || currentSentence is 5)
            {
                stepsScript.Stage1();
            }
            if(currentSentence is 6)
            {
                stepsScript.Stage2();
            }
            if (currentSentence is 7)
            {
                stepsScript.Stage3();
            }
            if (currentSentence is 9)
            {
                stepsScript.Stage4();
            }
        }
        else
        {

        }
        


    }

}
