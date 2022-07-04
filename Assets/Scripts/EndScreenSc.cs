using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenSc : MonoBehaviour
{
    public GameObject textWin;
    public GameObject textLose;
    public GameObject restart;

    public Slider partnerSlider;
    public Slider playerSLider;

    public GameObject buttonTakeCards;

    public void Update()
    {
        if (partnerSlider.value <= 0)
        {
            buttonTakeCards.SetActive(false);
            textWin.SetActive(true);
            restart.SetActive(true);
        }

        if (playerSLider.value <= 0)
        {
            buttonTakeCards.SetActive(false);
            textLose.SetActive(true);
            restart.SetActive(true);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
