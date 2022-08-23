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


    // Start is called before the first frame update
    

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
