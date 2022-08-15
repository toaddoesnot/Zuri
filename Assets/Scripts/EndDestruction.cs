using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestruction : MonoBehaviour
{
    public GameObject aim;


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer" || collision.gameObject.tag == "Answer2" || collision.gameObject.tag == "Answer3")
        {
            aim = collision.gameObject;
            Destroy(aim);
        }
    }
}
