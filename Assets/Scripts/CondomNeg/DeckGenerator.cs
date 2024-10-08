using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckGenerator : MonoBehaviour, IDropHandler
{
    //public List<GameObject> AnswerCards = new List<GameObject>();
    //public int currentType = -1;

    public GameObject card;
    public GameObject cardObject;
    public GameObject canvas;
    public bool SlotFull;

    //public RectTrnasformChange cardScript;
    public float m_XAxis, m_YAxis;

    public SlotList slotListSc;

    public bool Iam1;
    public bool Iam2;
    public bool Iam3;

    public bool doOnce;

    //RectTransform self;

    // Start is called before the first frame update
    void Start()
    {
        //CreateCard();
    }

    public void Update()
    {
        if (cardObject is not null)
        {
            if (cardObject.GetComponent<DragDrop>().dropped is true)
            {

                if (doOnce is false)
                {
                    cardObject.GetComponent<RectTrnasformChange>().r_XAxis = m_XAxis;
                    cardObject.GetComponent<RectTrnasformChange>().r_YAxis = m_YAxis;
                    cardObject.GetComponent<RectTrnasformChange>().ChangePosition();
                    //doOnce = true;

                }
            }
        }
        
        
    }

    public void CreateCard()
    {
        card.GetComponent<RectTrnasformChange>().r_XAxis = m_XAxis;
        card.GetComponent<RectTrnasformChange>().r_YAxis = m_YAxis;

        if (Iam1)
        {
            card.gameObject.tag = "Answer";
        }

        if (Iam2)
        {
            card.gameObject.tag = "Answer2";
        }

        if (Iam3)
        {
            card.gameObject.tag = "Answer3";
        }


        card.GetComponent<RectTrnasformChange>().ChangePosition();

        var createImage = Instantiate(card) as GameObject;
        createImage.transform.SetParent(canvas.transform, false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //SlotFull = true;  // 
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Iam1 && collision.gameObject.tag == "Answer" || Iam2 && collision.gameObject.tag == "Answer2" || Iam3 && collision.gameObject.tag == "Answer3")
        {
            SlotFull = true;
        }

        if (Iam1 && collision.gameObject.tag == "Answer" || Iam2 && collision.gameObject.tag == "Answer2" || Iam3 && collision.gameObject.tag == "Answer3")
        {
            cardObject = collision.gameObject;
        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (Iam1 && collision.gameObject.tag == "Answer" || Iam2 && collision.gameObject.tag == "Answer2" || Iam3 && collision.gameObject.tag == "Answer3")
        {
            SlotFull = false;
        }
    }



}
