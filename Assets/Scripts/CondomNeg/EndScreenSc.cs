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

    //public GameObject buttonTakeCards;
    public int currentline;
    public GameObject background;

    public GameObject aim1;
    public GameObject aim2;
    public GameObject aim3;

    public NewRecap NewRecapSc;
    public GameObject animationImage;

    public bool soundPlayed;
    public GameObject soundManager;
    public GameObject soundW;
    public GameObject soundL;

    public GameObject[] clearView;
    
    public void Update()
    {
        if (partnerSlider.value <= 0)
        {
            //animationImage.SetActive(false);
            soundManager.SetActive(false);
            animationImage.SetActive(true);

            aim1.SetActive(true);
            aim2.SetActive(true);
            aim3.SetActive(true);

            //buttonTakeCards.SetActive(false);

            background.SetActive(true);

            foreach (GameObject view in clearView)
            {
                view.SetActive(false);
            }

            textWin.SetActive(true);
            restart.SetActive(true);
            recapElement.SetActive(true);

            if (soundPlayed is false)
            {
                soundW.GetComponent<AudioSource>().Play();
                soundPlayed = true;
            }
        }
        else
        {
            if (playerSLider.value <= 0)
            {
                soundManager.SetActive(false);
                //animationImage.SetActive(false);
                animationImage.SetActive(true);

                aim1.SetActive(true);
                aim2.SetActive(true);
                aim3.SetActive(true);

                //buttonTakeCards.SetActive(false);

                background.SetActive(true);

                foreach (GameObject view in clearView)
                {
                    view.SetActive(false);
                }

                textLose.SetActive(true);
                restart.SetActive(true);
                recapElement.SetActive(true);
                if (soundPlayed is false)
                {
                    soundL.GetComponent<AudioSource>().Play();
                    soundPlayed = true;
                }
            }
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);//usually 1
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
