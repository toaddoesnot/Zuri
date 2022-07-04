using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotivationBar : MonoBehaviour
{

    public Slider playerMotivation;
    public TextMeshProUGUI sliderText;

    public void Update()
    {
        sliderText.text = "Motivation: " + playerMotivation.value.ToString();
    }
}
