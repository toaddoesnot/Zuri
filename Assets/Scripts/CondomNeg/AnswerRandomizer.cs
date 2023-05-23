using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerRandomizer : MonoBehaviour
{
    public List<GameObject> Answers = new List<GameObject>();
    public int currentCard;

    public bool haveMood;
    public bool haveSTD;
    public bool havePast;
    public bool haveProblem;

    public int damageAm;

    public GenderChanger genderSc;
    public TextMeshProUGUI textObj;
    public string femaleTxt;

    public bool femaleReactive;

    public SubTrigger triggerSc;
    public bool doOnce;


    // Start is called before the first frame update
    public void Start()
    {
        genderSc = FindObjectOfType<GenderChanger>();
        triggerSc = this.GetComponent<SubTrigger>();
    }
    //
    public void Update()
    {
        if (genderSc.DoneThing is false)
        {
            if (femaleReactive)
            {

                if (genderSc.females is true)
                {
                    triggerSc.sentenceList[0] = femaleTxt;
                    
                }
                else
                {
                    triggerSc.sentenceList[0] = "Even if you lose erection, I will help you to get it back. ";
                }
            }
        }
        else
        {
            if (doOnce is false)
            {
                textObj.text = triggerSc.sentenceList[0].ToString();
                doOnce = true;
            }
        }
        
        //
    }

    public void GenerateAnswer()
    {
        int randomIndex = Random.Range(0, Answers.Count);
        currentCard = randomIndex;

        foreach (GameObject answer in Answers)
        {
            answer.SetActive(false);
            Answers[currentCard].SetActive(true);
        }

    }


}
