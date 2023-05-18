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
    public bool ended2;

    public TextMeshProUGUI leftAnswer;
    public TextMeshProUGUI rightAnswer;
    public GameObject leftPlaque;
    public GameObject rightPlaque;

    public TextMeshProUGUI endingText;
    public GameObject endingText2;
    public GameObject endButton;

    public treasureMap treasureSc;
    public bool special1;
    public bool special2;
    public bool repeated;

    // Update is called once per frame
    void Update()
    {
        //leftAr.GetComponent<Image>().sprite = arrows[newLeft];
        //rightAr.GetComponent<Image>().sprite = arrows[newRight];

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
                StartCoroutine(Ending());
                //promptSc.promptText.text = "";

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

        if (docScript.chosenDoctor is 0 && OnTile is 7 && special1 is true || docScript.chosenDoctor is 0 && OnTile is 6 && special2 is true)
        {
            rightPlaque.SetActive(false);
        }
        else
        {
            if (docScript.chosenDoctor is 1 && OnTile is 8 && repeated is true)
            {
                rightPlaque.SetActive(false);
            }
            else
            {
                rightPlaque.SetActive(true);
            }
        }
    }

    public void ChooseR()
    {
        if (docScript.chosenDoctor is 0 && OnTile is 7 || docScript.chosenDoctor is 2 && OnTile is 6)
        {
            special1 = true;
        }
        if (docScript.chosenDoctor is 0 && OnTile is 5 || docScript.chosenDoctor is 0 && OnTile is 2 || docScript.chosenDoctor is 2 && OnTile is 5)
        {
            special2 = true;
            //leftPlaque.SetActive(false);
        }

        if (docScript.chosenDoctor is 0 && OnTile is 3 || docScript.chosenDoctor is 1 && OnTile is 10 || docScript.chosenDoctor is 2 && OnTile is 4)
        {
            ended2 = true;
            //promptSc.promptText.text = "";
        }
        else
        {
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
        if (docScript.chosenDoctor is 0 && OnTile is 3 || docScript.chosenDoctor is 1 && OnTile is 10 || docScript.chosenDoctor is 2 && OnTile is 4)
        {
            ended2 = true;
            //promptSc.promptText.text = "";
        }
        else
        {
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
