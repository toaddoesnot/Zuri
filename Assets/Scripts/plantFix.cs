using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantFix : MonoBehaviour
{
    public GameObject plant1;
    public GameObject plant2;
    public GameObject popupGal;

    // Update is called once per frame
    void Update()
    {
        if (popupGal.activeInHierarchy)
        {
            plant1.SetActive(false);
            plant2.SetActive(false);
        }
        else
        {
            plant1.SetActive(true);
            plant2.SetActive(true);
        }
    }
}
