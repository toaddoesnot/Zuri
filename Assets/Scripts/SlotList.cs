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
        currentSlot1 = Random.Range(0, DefinedCards.Count);
        generator1.card = DefinedCards[currentSlot1];
        DefinedCards.RemoveAt(currentSlot1);

        currentSlot2 = Random.Range(0, DefinedCards.Count);
        generator2.card = DefinedCards[currentSlot2];
        DefinedCards.RemoveAt(currentSlot2);

        currentSlot3 = Random.Range(0, UndefinedCards.Count);
        generator3.card = UndefinedCards[currentSlot3];
        UndefinedCards.RemoveAt(currentSlot3);
    }



}
