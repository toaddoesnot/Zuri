using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardController : MonoBehaviour
{
    public CardDrawer cardSC;


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")

        {
            cardSC.cardDelete = collision.gameObject;
            cardSC.cardRand = cardSC.cardDelete.GetComponent<AnswerRandomizer>();
            //
        }
    }
}
