using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTrnasformChange : MonoBehaviour
{
    public RectTransform m_RectTransform;

    public float r_XAxis, r_YAxis;

    // Start is called before the first frame update
    void Start()
    {
        r_XAxis = 0;
        r_YAxis = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition()
    {
        m_RectTransform.anchoredPosition = new Vector2(r_XAxis, r_YAxis);
    }

}
