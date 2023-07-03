using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseBlocker : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;
    public GameObject blocker;

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.activeInHierarchy)
        {
            paused = true;
        }
        else
        {
            paused = false;
        }
    }
}
