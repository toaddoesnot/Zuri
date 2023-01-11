using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public bool playedR;
    public bool playedW;
    public AudioSource soundR;
    public AudioSource soundW;

    public Patterns patternSc;

    public void SoundRight()
    {
        if (patternSc.blocked is false)
        {
            print("uv made it!");
            soundR.Play();
        }
    }

    public void SoundWrong()
    {
        if (patternSc.blocked is false)
        {
            soundW.Play();
        }
    }
}
