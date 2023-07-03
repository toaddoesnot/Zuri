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

    public int OnTile;
    public startManager docScript;

    public int newLway;
    public int newRway;

    public GameObject fastTile;

    public promptManager promptSc;
    public bool ended;
    public bool ended2;

    public TextMeshProUGUI leftAnswer;
    public TextMeshProUGUI rightAnswer;
    public GameObject leftPlaque;
    public GameObject rightPlaque;

    public TextMeshProUGUI endingText;
    public GameObject endingText2;
    public GameObject endButton;

    public treasureMap treasureSc;
    public bool special1; //all not cases
    public bool special2; // exception
    public bool repeated;

    public int tilesOpened;
    public GameObject loseImage;
    public GameObject tipsButton;
    public GameObject tipText;

    // Update is called once per frame
    void Update()
    {
        if (docScript.chosenDoctor is 1 && OnTile is 12)
        {
            repeated = true;
        }

        if (promptSc.doing)
        {
            leftPlaque.GetComponent<Button>().interactable = false;
            rightPlaque.GetComponent<Button>().interactable = false;
        }
        else
        {
            leftPlaque.GetComponent<Button>().interactable = true;
            rightPlaque.GetComponent<Button>().interactable = true;
        }

        if (docScript.chosenDoctor is 0 && OnTile is 3 || docScript.chosenDoctor is 1 && OnTile is 10 || docScript.chosenDoctor is 2 && OnTile is 4)
        {
            ended2 = true;

            if (ended is false)
            {
                promptSc.EndPrompts();
                promptSc.promptText.text = "";


                if (tilesOpened is 11)
                {
                    endingText.text = "Great job!";
                    foreach (GameObject tile in tiles)
                    {
                        tile.GetComponent<Animation>().Play("tileFade");
                    }
                    StartCoroutine(Ending());
                }
                else
                {
                    endingText.text = "Great, but there are more replies to open! Try again?!";
                    endingText2.SetActive(true);
                    tipsButton.SetActive(true);
                }
                
                 //CHANGE BASED ON THE OUTCOME don't get the tiles out if it's not a win, add objects wilth a text, add tips to text (should fit on one screen)
                if (leftPlaque.activeInHierarchy)
                {
                    leftPlaque.GetComponent<Animation>().Play("tileFade");
                }
                if (rightPlaque.activeInHierarchy)
                {
                    rightPlaque.GetComponent<Animation>().Play("tileFade");
                }
                ended = true;
            }
        }

        if (OnTile is 1 && fastTile.GetComponent<tileController>().fastPass is true)
        {
            OnTile = 4;

            if (treasureSc.playonce[0] is false)
            {
                treasureSc.smiles[2].SetActive(true);
                treasureSc.smiles[2].GetComponent<Animation>().Play("specialSmiles");
                treasureSc.playonce[0] = true;
            }

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

        //if (docScript.chosenDoctor is 0 && OnTile is 7 && special1 is true || docScript.chosenDoctor is 0 && OnTile is 6 && special2 is true)
        //{
        //    rightPlaque.SetActive(false);
        //}
       // else
       // {
       //     rightPlaque.SetActive(true);
       // }
    }

    public void ChooseR()
    {
        tilesOpened++;

        if (docScript.chosenDoctor is 0 && OnTile is 7 || docScript.chosenDoctor is 2 && OnTile is 6)
        {
            special1 = true;
        }
        if (docScript.chosenDoctor is 0 && OnTile is 5 || docScript.chosenDoctor is 0 && OnTile is 2 || docScript.chosenDoctor is 2 && OnTile is 5)
        {
            special2 = true; 
        }

        if (docScript.chosenDoctor is 0 && OnTile is 3 || docScript.chosenDoctor is 1 && OnTile is 10 || docScript.chosenDoctor is 2 && OnTile is 4)
        {
            ended2 = true;
        }
        else
        {
            promptSc.lineNom = tiles[OnTile].GetComponent<tileController>().RLine; //NEW

            OnTile = newRway;
            promptSc.generatePromptR();

            Image image = tiles[OnTile].GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0.01f;
            image.color = tempColor;

            tiles[OnTile].GetComponent<tileController>().doDeed = true;
        }
    }

    public void ChooseL()
    {
        tilesOpened++;
        if (docScript.chosenDoctor is 0 && OnTile is 3 || docScript.chosenDoctor is 1 && OnTile is 10 || docScript.chosenDoctor is 2 && OnTile is 4)
        {
            ended2 = true;
        }
        else
        {
            promptSc.lineNom = tiles[OnTile].GetComponent<tileController>().LLine; //NEW

            OnTile = newLway;
            promptSc.generatePromptL();

            Image image = tiles[OnTile].GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0.01f;
            image.color = tempColor;

            tiles[OnTile].GetComponent<tileController>().doDeed = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(5); // loads current scene
    }

    public IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f);

        endingText2.SetActive(true);
        tipsButton.SetActive(true);

        if (tilesOpened is 11)
        {
            girls[docScript.chosenDoctor].SetActive(true);
        }
    }

    public void ShowTips()
    {
        loseImage.SetActive(true);
        tipsButton.SetActive(false);
        tipText.SetActive(true);
        endButton.SetActive(true);
    }
}
