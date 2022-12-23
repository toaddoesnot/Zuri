using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileController : MonoBehaviour
{
    public TilesManager tilesSc;
    public bool doDeed;

    public int LeftBt;
    public int RightBt;

    public int LWay;
    public int RWay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doDeed is true)
        {
            tilesSc.newLeft = LeftBt;
            tilesSc.newRight = RightBt;

            tilesSc.newLway = LWay;
            tilesSc.newRway = RWay;

            doDeed = false;
        }
        else
        {
            
        }
    }
}
