using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckGenerator : MonoBehaviour, IDropHandler
{
    //public List<GameObject> AnswerCards = new List<GameObject>();
    //public int currentType = -1;

    public GameObject card;
    public GameObject canvas;
    public bool SlotFull;

    public RectTrnasformChange cardScript;
    public float m_XAxis, m_YAxis;

    public SlotList slotListSc;
    public List<GameObject> AnswerCards = new List<GameObject>();

    //RectTransform self;

    // Start is called before the first frame update
    void Start()
    {
        CreateCard();
    }

    public void CreateCard()
    {
        if(SlotFull is false)
        {
            //int randomIndex = Random.Range(0, AnswerCards.Count);
            // currentType = randomIndex;
            // card = AnswerCards[currentType];

            cardScript = card.GetComponent<RectTrnasformChange>();
            cardScript.r_XAxis = m_XAxis;
            cardScript.r_YAxis = m_YAxis;

            var createImage = Instantiate(card) as GameObject;
            createImage.transform.SetParent(canvas.transform, false);
        }
    }

    void Update()
    {
       
    }



    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer")
        {
            SlotFull = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer")
        {
            SlotFull = false;
        }
    }


}
