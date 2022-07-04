using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTrnasformChange : MonoBehaviour
{
    RectTransform m_RectTransform;

    public float r_XAxis, r_YAxis;

    // Start is called before the first frame update
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();

        m_RectTransform.anchoredPosition = new Vector2(r_XAxis, r_YAxis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
