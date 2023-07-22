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
    public GameObject[] tipText;

    public bool winwin;

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


                if (docScript.chosenDoctor is 1 && tilesOpened >= 11 || docScript.chosenDoctor is 0 && tilesOpened >= 11 || docScript.chosenDoctor is 2 && tilesOpened > 11 || treasureSc.secrets == 2) 
                {
                    winwin = true;
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
                //treasureSc.smiles[2].SetActive(true);
                //treasureSc.smiles[2].GetComponent<Animation>().Play("specialSmiles");
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

        if (docScript.chosenDoctor is 0 && OnTile is 7 && special1 is true || docScript.chosenDoctor is 0 && OnTile is 6)// && special2 is true)
        {
            if(OnTile is 7)
            {
                rightAnswer.text = "(Tell the truth). Understood.";
                newRway = 4;
                tiles[7].GetComponent<tileController>().RLine = 8;
            }
            if (OnTile is 6)
            {
                rightPlaque.SetActive(false);
            }
        }

        if (docScript.chosenDoctor is 2 && OnTile == 6 && special1 is true)
        {
            leftAnswer.text = "When I have this ovulation pain. What should I do?";
        }
        if (docScript.chosenDoctor is 2 && OnTile == 5 && special2 is true)
        {
            leftAnswer.text = "Thank you, I have learnt many new things!";
        }
        if (docScript.chosenDoctor is 2 && OnTile == 5 && !special2)
        {
            tiles[5].GetComponent<tileController>().LWay = 7;
            newLway = 7;
        }
        if (docScript.chosenDoctor is 2 && OnTile == 7)
        {
            newRway = 4;
        }

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

        if (docScript.chosenDoctor is 0 && OnTile is 2)
        {
            promptSc.docs[0].GetComponent<narrativeController>().specialResponses[2] = "I will respect your right to decline a procedure or request an alternative!";
        }

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
        SceneManager.LoadScene(6); // loads current scene
    }

    public IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f);

        endingText2.SetActive(true);
        tipsButton.SetActive(true);

        if (winwin)
        {
            girls[docScript.chosenDoctor].SetActive(true);
        }
    }

    public void ShowTips()
    {
        loseImage.SetActive(true);
        tipsButton.SetActive(false);
        tipText[docScript.chosenDoctor].SetActive(true);
        endButton.SetActive(true);
    }
}
