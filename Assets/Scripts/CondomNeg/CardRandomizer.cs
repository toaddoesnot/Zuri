using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRandomizer : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject>();
    public int currentType;
    public EndScreenSc endSc;

    public GameObject firstCard;
    public GameObject secondCard;

    public GameObject notificationS;

    public void Start()
    {
        //notificationS = GameObject.Find("notification");
    }

    public void GenerateType()
    {
        notificationS.GetComponent<AudioSource>().Play();

        int randomIndex = Random.Range(0, Cards.Count);
        currentType = randomIndex;

        Checker();
    }

    public void Checker()
    {
        if (currentType is 0)
        {
            firstCard.GetComponent<CardTrigger>().TriggerDialogue();

            endSc.partnerCard = firstCard;
        }

        if (currentType is 1)
        {
            secondCard.GetComponent<CardTrigger>().TriggerDialogue();

            endSc.partnerCard = secondCard;
            //endSc.recapList.Add(firstCard.GetComponent<SubTrigger>().sentenceList.ToString());
        }
    }

}
