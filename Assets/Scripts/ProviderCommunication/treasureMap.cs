using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureMap : MonoBehaviour
{
    public List<Vector2> ZuriPositions1 = new List<Vector2>();
    public List<Vector2> ZuriPositions2 = new List<Vector2>();
    public List<Vector2> ZuriPositions3 = new List<Vector2>();
    public GameObject[] smiles;

    public GameObject Zuri;
    public bool[] playonce;

    public TilesManager tilesScript;
    public startManager startScript;

    void Update()
    {
        if (startScript.chosenDoctor is 0)
        {
            Zuri.transform.localPosition = ZuriPositions1[tilesScript.OnTile];
            
            if(tilesScript.special1 is true)
            {
                smiles[0].SetActive(true);
                if (playonce[0] is false)
                {
                    smiles[0].GetComponent<Animation>().Play("specialSmiles");
                    tilesScript.OnTile = 7;
                    tilesScript.newLway = 4;
                    playonce[0] = true;
                }
            }
            if (tilesScript.special2 is true)
            {
                smiles[1].SetActive(true);
                if (playonce[1] is false)
                {
                    smiles[1].GetComponent<Animation>().Play("specialSmiles");
                    playonce[1] = true;
                }
            }
        }

        if (startScript.chosenDoctor is 1)
        {
            Zuri.transform.localPosition = ZuriPositions2[tilesScript.OnTile];

            if (tilesScript.OnTile is 6 && tilesScript.ended is false)
            {
                tilesScript.leftPlaque.SetActive(false);
                smiles[3].SetActive(true);
                if (playonce[1] is false)
                {
                    smiles[3].GetComponent<Animation>().Play("specialSmiles");
                    playonce[1] = true;
                }
            }
            else
            {
                if(tilesScript.ended2 is false && tilesScript.ended is false)
                {
                    tilesScript.leftPlaque.SetActive(true);
                }
                else
                {
                    tilesScript.leftPlaque.SetActive(false);
                    tilesScript.rightPlaque.SetActive(false);
                }
            }

            if (tilesScript.OnTile is 12 && tilesScript.ended is false)
            {
                //tilesScript.rightPlaque.SetActive(false);
                smiles[4].SetActive(true);
                if (playonce[2] is false)
                {
                    smiles[4].GetComponent<Animation>().Play("specialSmiles");
                    playonce[2] = true;
                }
            }
            else
            {
                if (tilesScript.OnTile is 11 && tilesScript.repeated is true)
                {
                    tilesScript.rightPlaque.SetActive(false);
                }
            }
        }

        if (startScript.chosenDoctor is 2)
        {
            Zuri.transform.localPosition = ZuriPositions3[tilesScript.OnTile];

            if (tilesScript.special1 is true)
            {
                tilesScript.rightPlaque.SetActive(false);

                smiles[5].SetActive(true);

                if (playonce[0] is false)
                {
                    smiles[5].GetComponent<Animation>().Play("specialSmiles");
                    tilesScript.OnTile = 6;
                    playonce[0] = true;
                }
            }

            if (tilesScript.special2 is true)
            {
                tilesScript.rightPlaque.SetActive(false);

                smiles[6].SetActive(true);

                if (playonce[1] is false)
                {
                    smiles[6].GetComponent<Animation>().Play("specialSmiles");
                    tilesScript.OnTile = 5;
                    playonce[1] = true;
                }
            }

            if (tilesScript.OnTile is not 6 && tilesScript.OnTile is not 5 && tilesScript.ended is false)
            {
                tilesScript.rightPlaque.SetActive(true);
            }
        }
    }
}
