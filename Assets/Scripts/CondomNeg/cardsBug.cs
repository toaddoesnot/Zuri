using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsBug : MonoBehaviour
{
    public bool CardOutside;
    public bool DestroyCard;

    public bool AmSmol;
    public bool AmBig;

    public GameObject cardDestroyer;

    public DeckGenerator slot1;
    public DeckGenerator slot2;
    public DeckGenerator slot3;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (AmBig)
        {
            if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
            {
                print("card outside");
                CardOutside = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (AmSmol)
        {
            if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
            {
                if (cardDestroyer.GetComponent<cardsBug>().CardOutside is true)
                {
                    Destroy(collision.gameObject);
                }
                if (cardDestroyer.GetComponent<cardsBug>().CardOutside is false)
                {
                    cardDestroyer.GetComponent<cardsBug>().DestroyCard = false;
                }
                
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
        {
            print("card inside");
            CardOutside = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (AmBig)
        {
            if (DestroyCard)
            {
                cardDestroyer.SetActive(true);
            }
            else
            {
                cardDestroyer.SetActive(false);
            }
        }
       
    }
}
