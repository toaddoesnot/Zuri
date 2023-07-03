using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Negotiation()
    {
        SceneManager.LoadScene(1);
    }

    public void Condom()
    {
        SceneManager.LoadScene(3);
    }

    public void Provider()
    {
        SceneManager.LoadScene(5);
    }
}
