using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotImprovers : MonoBehaviour
{
    public bool occupied;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer")
        {
            occupied = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Answer")
        {
            occupied = false;
        }
    }
}
