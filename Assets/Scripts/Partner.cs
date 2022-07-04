using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour
{
    public List<string> statementTypes = new List<string>();
    public int currentType;

    public bool moodDone;
    public bool STDdone;
    public bool moodandSTDone;
    public bool pastDone;
    public bool problemDone;

    private void Start()
    {
        currentType = -1;
        statementTypes.Add("mood");
        statementTypes.Add("STD");
        statementTypes.Add("moodSTD");
        statementTypes.Add("past");
        statementTypes.Add("problem");
    }

    public void RandomizeType()
    {
        string stringToRetrieve = GetRandomItem(statementTypes);
    }

    public string GetRandomItem(List<string> listToRandomize)
    {
        
        int randomNum = Random.Range(0, listToRandomize.Count);
        print(randomNum);
        currentType = randomNum;
        string printRandom = listToRandomize[randomNum];
        print(printRandom);
        Excluding();
        return printRandom;
    }

    public void Excluding()
    {
        
        //statementTypes.Remove("mood");
        if (currentType == 1)
        {
            STDdone = true;
        }
        if (currentType == 2)
        {
            moodandSTDone = true;
        }
        if (currentType == 3)
        {
            pastDone = true;
        }
        if (currentType == 4)
        {
            problemDone = true;
        }
    }


}
