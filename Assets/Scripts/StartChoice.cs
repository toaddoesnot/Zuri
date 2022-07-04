using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChoice : MonoBehaviour
{
    public GameObject startUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChoosePartner()
    {
        startUI.SetActive(false);
    }
}
