using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N_GameUI : MonoBehaviour
{
    bool GamePaused;
    void Start()
    {
        GamePaused = false;
    }
    void Update()
    {
        if (GamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("menu");
    }
    public void PauseGame()
    {
        GamePaused = true;
    }
    public void ResumeGame()
    {
        GamePaused = false;
    }
}
