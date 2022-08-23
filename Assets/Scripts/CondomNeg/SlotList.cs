using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotList : MonoBehaviour
{
    public List<GameObject> DefinedCards = new List<GameObject>();
    public List<GameObject> UndefinedCards = new List<GameObject>();

    public int currentSlot1;
    public int currentSlot2;
    public int currentSlot3;

    public DeckGenerator generator1;
    public DeckGenerator generator2;
    public DeckGenerator generator3;

    // Start is called before the first frame update
    void Start()
    {
        GiveCard();
    }

    public void GiveCard()
    {
        if(generator1.SlotFull is false)
        {
            currentSlot1 = Random.Range(0, DefinedCards.Count);

            generator1.card = DefinedCards[currentSlot1];
            generator1.CreateCard();
            //generator1.card.GetComponent<RectTrnasformChange>().ChangePosition1();
            DefinedCards.RemoveAt(currentSlot1);
            
        }

        if (generator2.SlotFull is false)
        {
            currentSlot2 = Random.Range(0, DefinedCards.Count);

            generator2.card = DefinedCards[currentSlot2];
            generator2.CreateCard();
            //generator2.card.GetComponent<RectTrnasformChange>().ChangePosition2();
            DefinedCards.RemoveAt(currentSlot2);
        }

        if (generator3.SlotFull is false)
        {
            currentSlot3 = Random.Range(0, UndefinedCards.Count);

            //generator3.card.GetComponent<RectTrnasformChange>().ChangePosition2();
            generator3.card = UndefinedCards[currentSlot3];
            generator3.CreateCard();
            UndefinedCards.RemoveAt(currentSlot3);
        }

        

    }
}
