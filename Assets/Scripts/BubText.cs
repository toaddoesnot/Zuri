using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public string justOncy;

    // Start is called before the first frame update
    void Update()
    {
        print("amAlive");
        myText.text = justOncy.ToString();

        //recapList[currentline].ToString();
    }

}
