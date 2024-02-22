using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class N_GameUI : MonoBehaviour
{
    bool GamePaused;
    [SerializeField] private Slider loadingslider;
    [SerializeField] private GameObject lose;

    public static N_GameUI instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
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
            //Time.timeScale = 1;
        }
    }
    public void RestartGame()
    {
        GamePaused = false;
        StartCoroutine(LoadingLevel(1));
    }

    IEnumerator LoadingLevel(int level)
    {
        AsyncOperation loadoperation = SceneManager.LoadSceneAsync(level);

        while (!loadoperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadoperation.progress / 0.9f);
            loadingslider.value = progressValue;
            yield return null;
        }
    }
    public void MainMenu()
    {
        GamePaused = false;
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
    public void LoseGame()
    {
        GamePaused = true;
        lose.SetActive(true);
    }
}
