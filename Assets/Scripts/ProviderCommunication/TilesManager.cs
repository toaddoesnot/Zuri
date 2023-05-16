using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[] girls;
    //public Sprite[] arrows;

    public int OnTile;
    public startManager docScript;

    //public GameObject leftAr;
    //public GameObject rightAr;

    //public int newLeft;
    //public int newRight;

    public int newLway;
    public int newRway;

    public GameObject fastTile;

    public promptManager promptSc;
    public bool ended;

    public TextMeshProUGUI leftAnswer;
    public TextMeshProUGUI rightAnswer;
    public GameObject leftPlaque;
    public GameObject rightPlaque;

    public TextMeshProUGUI endingText;
    public GameObject endingText2;
    public GameObject endButton;

    // Update is called once per frame
    void Update()
    {
        //leftAr.GetComponent<Image>().sprite = arrows[newLeft];
        //rightAr.GetComponent<Image>().sprite = arrows[newRight];

        if (docScript.chosenDoctor is 0 && OnTile is 3 || docScript.chosenDoctor is 1 && OnTile is 10 || docScript.chosenDoctor is 2 && OnTile is 4)
        {
            if (ended is false)
            {
                promptSc.EndPrompts();
                StartCoroutine(Ending());

                endingText.text = "Great job!";
                leftPlaque.GetComponent<Animation>().Play("tileFade");
                rightPlaque.GetComponent<Animation>().Play("tileFade");

                foreach (GameObject tile in tiles)
                {
                    tile.GetComponent<Animation>().Play("tileFade");
                }

                ended = true;
            }
        }

        if (OnTile is 1 && fastTile.GetComponent<tileController>().fastPass is true)
        {
            OnTile = 4;

            Image image = tiles[OnTile].GetComponent<Image>();
            var tempColor = image.color; 
            tempColor.a = 0.01f;
            image.color = tempColor;

            tiles[OnTile].GetComponent<tileController>().doDeed = true;
        }

        if (OnTile is not 0)
        {
            leftAnswer.text = tiles[OnTile].GetComponent<tileController>().myLeft.ToString();
            rightAnswer.text = tiles[OnTile].GetComponent<tileController>().myRight.ToString();
        }
    }

    public void ChooseR()
    {
        OnTile = newRway;
        promptSc.generatePromptR();

        Image image = tiles[OnTile].GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.01f;
        image.color = tempColor;

        tiles[OnTile].GetComponent<tileController>().doDeed = true;
    }

    public void ChooseL()
    {
        OnTile = newLway;
        promptSc.generatePromptL();

        Image image = tiles[OnTile].GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.01f;
        image.color = tempColor;

        tiles[OnTile].GetComponent<tileController>().doDeed = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); // loads current scene
    }

    public IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f);
        endingText2.SetActive(true);
        endButton.SetActive(true);
        girls[docScript.chosenDoctor].SetActive(true);
    }
}
