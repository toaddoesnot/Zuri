using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseObj;

    public void PauseGame()
    {
        pauseObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        pauseObj.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
