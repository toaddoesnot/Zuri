using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickFix : MonoBehaviour
{
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Destruction()
    {
        Destroy(self);
    }

}
