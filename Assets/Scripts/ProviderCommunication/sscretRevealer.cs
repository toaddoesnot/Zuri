using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sscretRevealer : MonoBehaviour
{
    public treasureMap treasureSc;

    public GameObject myDoc;
    public GameObject self;
    public bool revealed;
    public string myAnim;
    public string myAnim2;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (self.activeInHierarchy && !revealed)
        {
            treasureSc.secrets++;
            myDoc.GetComponent<Animation>().Play(myAnim);
            StartCoroutine(RestartAnim());
            revealed = true;
        }
    }

    IEnumerator RestartAnim()
    {
        yield return new WaitForSeconds(speed);
        myDoc.GetComponent<Animation>().Play(myAnim2);
    }
}
