using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class N_MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform Panel;
    [SerializeField] private float topPosY, CenterPosY;
    [SerializeField] private float tweenDuration;
    [SerializeField] private Slider loadingslider;

    public void PlayGame()
    {
        /*mainmenu.SetActive(false);
        loadingScreen.SetActive(true);*/
        Time.timeScale = 1;
        StartCoroutine(LoadingLevel(1));
        //SceneManager.LoadScene(1);
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
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void AnimatedPanel()
    {
        Panel.DOAnchorPosY(CenterPosY, tweenDuration);
    }
    public void AnimatedPanelOUT()
    {
        Panel.DOAnchorPosY(topPosY, tweenDuration);
    }
}
