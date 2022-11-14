using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class howtoTutorial : MonoBehaviour
{
    public void SkipTutorial()
    {
        SceneManager.LoadScene(1);
    }
}
