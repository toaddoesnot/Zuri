using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeDictionary : MonoBehaviour
{
    public List<GameObject> SentenceTypes = new List<GameObject>();
    public int currentType;

    public Slider partnerSlider;
    public Slider playerSlider;

    public NoRepeat repeatSc;
    public GameObject repeater;

    public ArgumentSlot argumentSc;
    public bool Started;

    public DeckGenerator generatorSc1;
    public DeckGenerator generatorSc2;
    public DeckGenerator generatorSc3;
    public SlotList randomizer4Generators;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;
    public GameObject r5;

    public int Round;

    public triggerTEST bossSc;
    public TextMeshProUGUI textOnBub;

    public CardDrawer cardDrawer;

    public cardsBug bugger;
    public takeTimeSc timeSc;

    public GameObject takeCardTips;


    // Start is called before the first frame update
    void Start()
    {
        currentType = -1;
        repeatSc = repeater.GetComponent<NoRepeat>();
        //GenerateType();

    }

    public void Update()
    {
        if (Round is 2)
        {
            r1.SetActive(false);
            r2.SetActive(true);
        }
        if (Round is 3)
        {
            r2.SetActive(false);
            r3.SetActive(true);
        }
        if (Round is 4)
        {
            r3.SetActive(false);
            r4.SetActive(true);
        }
        if (Round is 5)
        {
            r4.SetActive(false);
            r5.SetActive(true);
        }
    }

    public void GenerateType()
    {
        if (Started)
        {
            if (argumentSc.snatched)
            {
                    bossSc.InsideTrigger = false;
                    argumentSc.HaveRightOne = false;
                    //destroyer.SetActive(true);
                    textOnBub.text = ("...");
                    argumentSc.snatched = false;
                    argumentSc.snatchedTwice = false;

                    bossSc.currentCard = 0;

                    int randomIndex = Random.Range(0, SentenceTypes.Count);
                    currentType = randomIndex;
                    SentenceTypes.RemoveAt(randomIndex);
                    repeatSc.Checker();
                    randomizer4Generators.GiveCard();

                    Round++;
                takeCardTips.SetActive(false); // NEW 
                timeSc.totalTime = 0;

                if (partnerSlider.value <= 0 || playerSlider.value < 0)
                {
                    
                }
                else
                {
                    FindObjectOfType<EndScreenSc>().PartnerRecap();
                    cardDrawer.cardDrawn = false;
                }

            }
            else
            {
                if (cardDrawer.cardDrawn)
                {
                        textOnBub.text = ("...");
                        argumentSc.snatched = false;
                        argumentSc.snatchedTwice = false;

                        bossSc.currentCard = 0;

                        int randomIndex = Random.Range(0, SentenceTypes.Count);
                        currentType = randomIndex;
                        SentenceTypes.RemoveAt(randomIndex);
                        repeatSc.Checker();
                        randomizer4Generators.GiveCard();

                        Round++;
                        takeCardTips.SetActive(false); // NEW 

                    if (partnerSlider.value <=0 || playerSlider.value < 0)
                    {
                        
                    }
                    else
                    {
                        FindObjectOfType<EndScreenSc>().PlayerRecap();
                        FindObjectOfType<EndScreenSc>().PartnerRecap();
                        cardDrawer.cardDrawn = false;
                    } 
                }
            }
        }

        else
        {
            int randomIndex = Random.Range(0, SentenceTypes.Count);
            currentType = randomIndex;
            SentenceTypes.RemoveAt(randomIndex);
            repeatSc.Checker();

            FindObjectOfType<EndScreenSc>().PartnerRecap();
            Started = true;
        }
        //bugger.DestroyCard = false;
        
    }
}
