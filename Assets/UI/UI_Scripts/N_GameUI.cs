using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class N_GameUI : MonoBehaviour
{
    internal bool GamePaused;
    [SerializeField] private Slider loadingslider;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameEvents tutorialP;

    public static N_GameUI instance;

    private void OnEnable()
    {
        tutorialP.GameAction += TutorialPause;
    }

    private void OnDisable()
    {
        tutorialP.GameAction -= TutorialPause;
    }

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
            Time.timeScale = 1;
        }
    }
    public void RestartGame()
    {
        GamePaused = false;
        StartCoroutine(LoadingLevel(3));
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
        StartCoroutine(LoadingLevel(1));
        //SceneManager.LoadScene(1);
        Debug.Log("menu");
    }
    public void PauseGame()
    {
        if(!GamePaused)
        {
            GamePaused = true;
        }
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

    public void TutorialPause()
    {
        GamePaused = true;
    }
}
