using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N_MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform Panel;
    [SerializeField] private float topPosY, CenterPosY;
    [SerializeField] private float tweenDuration;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
