using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRepeat : MonoBehaviour
{
    public TypeDictionary listTypes;
    public GameObject listObj;

    public ArgumentSlot slotScript;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;

    public GameObject moodBub;
    public GameObject STDBub;
    public GameObject mood2Bub;
    public GameObject pastBub;
    public GameObject problemBub;

    public bool moodDone;
    public bool STDDone;
    public bool mood2Done;
    public bool pastDone;
    public bool problemDone;

    public EndScreenSc gameEndSc;

    void Start()
    {
        listTypes = listObj.GetComponent<TypeDictionary>();
    }

    public void Checker()
    {
        if (listTypes.SentenceTypes.Contains(one))
        {
            
        }
        else
        {
            if (moodDone is false)
            {
                Mood();
                moodDone = true;
            }
        }

        if (listTypes.SentenceTypes.Contains(two))
        {

        }
        else
        {
            if (STDDone is false)
            {
                STD();
                STDDone = true;
            }
        }

        if (listTypes.SentenceTypes.Contains(three))
        {

        }
        else
        {
            if (mood2Done is false)
            {
                Mood2();
                mood2Done = true;
            }
        }

        if (listTypes.SentenceTypes.Contains(four))
        {

        }
        else
        {
            if (pastDone is false)
            {
                Past();
                pastDone = true;
            }
        }

        if (listTypes.SentenceTypes.Contains(five))
        {

        }
        else
        {
            if (problemDone is false)
            {
                Problem();
                problemDone = true;
            }
        }

        if (listTypes.SentenceTypes.Count == 0)
        {
           // gameEndSc.GameEnd();
        }
    }

    public void Mood()
    {
        print("mood");
        moodBub.GetComponent<CardRandomizer>().GenerateType();
        moodBub.SetActive(true);
        STDBub.SetActive(false);
        mood2Bub.SetActive(false);
        pastBub.SetActive(false);
        problemBub.SetActive(false);

        slotScript.needMood = true;
    }

    public void STD()
    {
        print("STD");
        STDBub.GetComponent<CardRandomizer>().GenerateType();
        moodBub.SetActive(false);
        STDBub.SetActive(true);
        mood2Bub.SetActive(false);
        pastBub.SetActive(false);
        problemBub.SetActive(false);

        slotScript.needSTD = true;
    }

    public void Mood2()
    {
        print("Mood2");
        mood2Bub.GetComponent<CardRandomizer>().GenerateType();
        moodBub.SetActive(false);
        mood2Bub.SetActive(true);
        STDBub.SetActive(false);
        pastBub.SetActive(false);
        problemBub.SetActive(false);

        slotScript.needMood = true;
    }

    public void Past()
    {
        print("past");
        pastBub.GetComponent<CardRandomizer>().GenerateType();
        moodBub.SetActive(false);
        STDBub.SetActive(false);
        mood2Bub.SetActive(false);
        pastBub.SetActive(true);
        problemBub.SetActive(false);

        slotScript.needPast = true;
    }

    public void Problem()
    {
        print("problem");
        problemBub.GetComponent<CardRandomizer>().GenerateType();
        moodBub.SetActive(false);
        STDBub.SetActive(false);
        mood2Bub.SetActive(false);
        pastBub.SetActive(false);
        problemBub.SetActive(true);

        slotScript.needProblem = true;
    }

}
