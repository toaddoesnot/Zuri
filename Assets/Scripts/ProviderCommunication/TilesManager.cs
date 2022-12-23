using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tiles;
    public Sprite[] arrows;

    public int OnTile;

    public GameObject leftAr;
    public GameObject rightAr;

    public int newLeft;
    public int newRight;

    public int newLway;
    public int newRway;

    public GameObject endScr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftAr.GetComponent<Image>().sprite = arrows[newLeft];
        rightAr.GetComponent<Image>().sprite = arrows[newRight];

        if (OnTile is 3)
        {
            endScr.SetActive(true);
        }
    }

    public void ChooseR()
    {
        OnTile = newRway;

        Image image = tiles[OnTile].GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.01f;
        image.color = tempColor;

        tiles[OnTile].GetComponent<tileController>().doDeed = true;
    }

    public void ChooseL()
    {
        OnTile = newLway;

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
}
