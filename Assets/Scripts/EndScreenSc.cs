using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenSc : MonoBehaviour
{
    [SerializeField]
    public List<string> recapList = new List<string>();
    
    public TextMeshProUGUI recapText;
    public GameObject recapElement;

    public TextMeshProUGUI playerText;

    public GameObject partnerCard;

    public GameObject textWin;
    public GameObject textLose;
    public GameObject restart;

    public Slider partnerSlider;
    public Slider playerSLider;

    public GameObject buttonTakeCards;
    public int currentline;
    public GameObject background;

    public GameObject aim1;
    public GameObject aim2;
    public GameObject aim3;

    public NewRecap NewRecapSc;
    public GameObject animationImage;
    
    public void Update()
    {
        if (partnerSlider.value <= 0)
        {
            //animationImage.SetActive(false);
            animationImage.SetActive(true);

            aim1.SetActive(true);
            aim2.SetActive(true);
            aim3.SetActive(true);

            buttonTakeCards.SetActive(false);

            background.SetActive(true);
            textWin.SetActive(true);
            restart.SetActive(true);

            recapElement.SetActive(true);
        }
        else
        {
            if (playerSLider.value < 0)
            {
                //animationImage.SetActive(false);
                animationImage.SetActive(true);

                aim1.SetActive(true);
                aim2.SetActive(true);
                aim3.SetActive(true);

                buttonTakeCards.SetActive(false);

                background.SetActive(true);
                textLose.SetActive(true);
                restart.SetActive(true);

                recapElement.SetActive(true);
            }
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void PartnerRecap()
    {
            recapList.Add(partnerCard.GetComponent<CardTrigger>().sentenceClass.sentence[0].ToString());
            NewRecapSc.InstantiatePartner();
            //recapText.text += "\n\n- " + recapList[currentline].ToString();
            currentline++;
    }

    public void PlayerRecap()
    {
            print("PlayerRecapping!");
            recapList.Add(playerText.text);
        NewRecapSc.InstantiatePlayer();
        //recapText.text += "\n\n- " + recapList[currentline].ToString();
            currentline++;
    }
}
