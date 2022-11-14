using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class instructionManagerNeg : MonoBehaviour
{
    public int stage;
    public GameObject prevButton;
    public GameObject nextButton;

    public GameObject instText;
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject maskLeft;
    public GameObject maskRight;

    public Sprite startButton;
    public Sprite normalButton;

    public GameObject videoPanel;
    public VideoClip clip1;
    public VideoClip clip2;
    public VideoClip clip3;

    public GameObject[] circles;

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stage is 0)
        {
            prevButton.SetActive(false);
            maskLeft.SetActive(true);
            videoPanel.GetComponent<VideoPlayer>().clip = clip1;
            videoPanel.GetComponent<VideoPlayer>().playbackSpeed = 1f;
            instText.GetComponent<TextMeshProUGUI>().text = "Drag one or two cards to your bubble to respond. Use the same color as in the sentence.";

            arrowDown.SetActive(true);
            arrowLeft.SetActive(false);

            foreach (GameObject circle in circles)
            {
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                circles[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
        if (stage is 1)
        {
            prevButton.SetActive(true);
            nextButton.GetComponent<Button>().GetComponent<Image>().sprite = normalButton;
            maskLeft.SetActive(false);
            maskRight.SetActive(true);
            videoPanel.GetComponent<VideoPlayer>().clip = clip2;
            videoPanel.GetComponent<VideoPlayer>().playbackSpeed = 1f;
            instText.GetComponent<TextMeshProUGUI>().text = "To get rid of a card, drag it to the draw deck.";

            arrowDown.SetActive(false);
            arrowLeft.SetActive(true);
            arrowRight.SetActive(false);

            foreach (GameObject circle in circles)
            {
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                circles[1].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
        if (stage is 2)
        {
            nextButton.GetComponent<Button>().GetComponent<Image>().sprite = startButton;
            maskRight.SetActive(false);
            maskLeft.SetActive(true);
            videoPanel.GetComponent<VideoPlayer>().clip = clip3;
            videoPanel.GetComponent<VideoPlayer>().playbackSpeed = 0.5f;
            instText.GetComponent<TextMeshProUGUI>().text = "When you either used a card or drew a card, press TAKE to proceed.";

            arrowLeft.SetActive(false);
            arrowRight.SetActive(true);

            foreach (GameObject circle in circles)
            {
                circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                circles[2].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
        if (stage is 3)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Next()
    {
        stage++;
    }

    public void Prev()
    {
        stage--;
    }
}
