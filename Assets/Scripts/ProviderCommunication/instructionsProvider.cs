using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class instructionsProvider : MonoBehaviour
{
    public int stage;
    public GameObject prevButton;
    public GameObject nextButton;

    public GameObject instText;
    public GameObject tip;

    public GameObject[] circles;
    public GameObject[] animations;
    public string[] instruction;

    // Update is called once per frame
    void Update()
    {
        if(stage != 3)
        {
            instText.GetComponent<TextMeshProUGUI>().text = instruction[stage].ToString();

            foreach (GameObject circle in circles)
            {
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                circles[stage].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }

            if (stage is 0)
            {
                prevButton.SetActive(false);
            }
            if (stage is 1)
            {
                prevButton.SetActive(true);
            }
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }

    public void Next()
    {
        stage++;
        foreach (GameObject anim in animations)
        {
            anim.SetActive(false);
            animations[stage].SetActive(true);
        }
        tip.SetActive(false);
    }

    public void Prev()
    {
        stage--;
        foreach (GameObject anim in animations)
        {
            anim.SetActive(false);
            animations[stage].SetActive(true);
        }
    }
}
