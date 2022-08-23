using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRecap : MonoBehaviour
{
    public GameObject partnerInstance;
    public GameObject playerInstance;

    public Transform parentObject;
    public int players;
    public int partners;

    public GameObject Par1;
    public GameObject Par2;
    public GameObject Par3;
    public GameObject Par4;
    public GameObject Par5;

    public GameObject Pla1;
    public GameObject Pla2;
    public GameObject Pla3;
    public GameObject Pla4;
    public GameObject Pla5;


    public void InstantiatePartner()
    {
        partners++;

        if (partners is 1)
        {
            Par1 = Instantiate(partnerInstance, parentObject);
            Par1.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[0];
        }
        if (partners is 2)
        {
            Par2 = Instantiate(partnerInstance, parentObject);
            Par2.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[2];
        }
        if (partners is 3)
        {
            Par3 = Instantiate(partnerInstance, parentObject);
            Par3.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[4];
        }
        if (partners is 4)
        {
            Par4 = Instantiate(partnerInstance, parentObject);
            Par4.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[6];
        }
        if (partners is 5)
        {
            Par5 = Instantiate(partnerInstance, parentObject);
            Par5.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[8];
        }

    }

    public void InstantiatePlayer()
    {
        players++;

        if (players is 1)
        {
            Pla1 = Instantiate(playerInstance, parentObject);
            Pla1.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[1];
        }
        if (players is 2)
        {
            Pla2 = Instantiate(playerInstance, parentObject);
            Pla2.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[3];
        }
        if (players is 3)
        {
            Pla3 = Instantiate(playerInstance, parentObject);
            Pla3.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[5];
        }
        if (players is 4)
        {
            Pla4 = Instantiate(playerInstance, parentObject);
            Pla4.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[7];
        }
        if (players is 5)
        {
            Pla5 = Instantiate(playerInstance, parentObject);
            Pla5.GetComponent<BubText>().justOncy = FindObjectOfType<EndScreenSc>().recapList[9];
        }
    }
}
    

