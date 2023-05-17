using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrativeController : MonoBehaviour
{
    public List<string> docResponses = new List<string>();
    public List<string> specialResponses = new List<string>();

    public TilesManager tilesSc;

    public void Update()
    {
        if(tilesSc.ended2 is true)
        {
            docResponses.Clear();
        }
    }
    //public GameObject mySpec1;
    //public GameObject mySpec2;

    //public int spec1;
    //public int spec2;
}
