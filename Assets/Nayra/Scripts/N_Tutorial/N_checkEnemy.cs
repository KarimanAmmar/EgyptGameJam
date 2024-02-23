using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_checkEnemy : MonoBehaviour
{
    [SerializeField] private GameEvents _checkEnemy;
    [SerializeField] private GameEvents PauseGame;
    [SerializeField] private GameObject _WeekPanel;
    [SerializeField] private GameObject _strongPanel;
    [SerializeField] private GameObject _startPanel;

    private bool isPaused = false;
    private bool startPause = false;
    private bool Week = true;
    private bool strong = true;

    private void OnEnable()
    {
        _checkEnemy.GameAction += EnemySpawned;
    }
    private void OnDisable()
    {
        _checkEnemy.GameAction -= EnemySpawned;
    }
    void Update()
    {
        if(Time.time >= 2f && startPause ==  false)
        {
            PauseGame.GameAction?.Invoke();
            _startPanel.SetActive(true);
            startPause = true;
        }
        if (N_SpwanEnimies.instance.enemy != null && N_SpwanEnimies.instance.enemy.transform.localPosition.x <= -4f && isPaused == false)
        {
            /*Time.timeScale = 0;
            isPaused = true;*/
            checkforPausing();
            Debug.Log("Paused");
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            //Time.timeScale = 1;
            N_GameUI.instance.ResumeGame();
            _WeekPanel.SetActive(false);
            _strongPanel.SetActive(false);
            _startPanel.SetActive(false);
        }

        if (Time.time >= 60)
        {
            N_GameUI.instance.MainMenu();
        }

    }

    void checkforPausing()
    {
        if (N_SpwanEnimies.instance.namePrefab == "sprites for crow_0")
        {
            if (Week == true)
            {
                PauseGame.GameAction?.Invoke();
                _WeekPanel.SetActive(true);
                isPaused = true;
                Week = false;
            }
        }
        if (N_SpwanEnimies.instance.namePrefab == "vulture sprite sheet_0")
        {
            if (strong == true)
            {
                PauseGame.GameAction?.Invoke();
                _strongPanel.SetActive(true);
                isPaused = true;
                strong = false;
            }
        }

    }
    public void EnemySpawned()
    {
        isPaused = false;
    }
}
