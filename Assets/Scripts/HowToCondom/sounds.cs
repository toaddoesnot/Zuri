using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public bool playedR;
    public bool playedW;
    public AudioSource soundR;
    public AudioSource soundW;

    public void SoundRight()
    {
        print("uv made it!");
        soundR.Play();
    }

    public void SoundWrong()
    {
        soundW.Play();
    }
}
