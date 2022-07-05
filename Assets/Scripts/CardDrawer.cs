using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrawer : MonoBehaviour, IDropHandler
{
    public DeckGenerator generatorSc1;
    public DeckGenerator generatorSc2;
    public DeckGenerator generatorSc3;

    public GameObject cardDelete;
    public AnswerRandomizer cardRand;
    public int TimesDrawn;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Destroy(cardDelete);

            TimesDrawn++;

        }

    }


  


}
