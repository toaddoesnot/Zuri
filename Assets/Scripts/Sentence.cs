using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Sentence
{
    [TextArea(3, 10)]
    public string[] sentence;
    public string description;
    public int power;
}
