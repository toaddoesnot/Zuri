using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRandomizer : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject>();
    public int currentType;

    public GameObject firstCard;
    public GameObject secondCard;

    public void GenerateType()
    {
        int randomIndex = Random.Range(0, Cards.Count);
        currentType = randomIndex;
        Checker();
    }

    public void Checker()
    {
        if (currentType is 0)
        {
            firstCard.GetComponent<CardTrigger>().TriggerDialogue();
        }

        if (currentType is 1)
        {
            secondCard.GetComponent<CardTrigger>().TriggerDialogue();
        }
    }

}
