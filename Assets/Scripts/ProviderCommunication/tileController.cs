using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileController : MonoBehaviour
{
    public TilesManager tilesSc;
    public bool doDeed;

    public startManager startSc;
    public List<int> moves = new List<int>();

    [TextArea]
    public List<string> leftAnswers = new List<string>();
    [TextArea]
    public List<string> rightAnswers = new List<string>();

    public string myLeft;
    public string myRight;

    public int LWay;
    public int RWay;

    public bool fastPass;

    public List<int> lines = new List<int>();
    public int LLine;
    public int RLine;

    // Update is called once per frame
    void Update()
    {
        if (startSc.chosenDoctor is 0)
        {
            LWay = moves[0];
            RWay = moves[1];
            myLeft = leftAnswers[0];
            myRight = rightAnswers[0];
        }
        if (startSc.chosenDoctor is 1)
        {
            LWay = moves[2];
            RWay = moves[3];
            myLeft = leftAnswers[1];
            myRight = rightAnswers[1];

            LLine = lines[2];
            RLine = lines[3];
        }
        if (startSc.chosenDoctor is 2)
        {
            LWay = moves[4];
            RWay = moves[5];
            myLeft = leftAnswers[2];
            myRight = rightAnswers[2];
        }

        if (doDeed is true)
        {
            tilesSc.newLway = LWay;
            tilesSc.newRway = RWay;

            doDeed = false;
        }
    }
}
