using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_checkEnemy : MonoBehaviour
{
    [SerializeField] private GameEvents _checkEnemy;
    [SerializeField] private GameObject _WeekPanel;
    [SerializeField] private GameObject _strongPanel;

    private bool isPaused = false;
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
        if (N_SpwanEnimies.instance.enemy != null && N_SpwanEnimies.instance.enemy.transform.localPosition.x <= -4f && isPaused == false)
        {
            /*Time.timeScale = 0;
            isPaused = true;*/
            checkforPausing();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 1;
            _WeekPanel.SetActive(false);
            _strongPanel.SetActive(false);
        }
        if(Time.time >= 40)
        {
            N_GameUI.instance.MainMenu();
        }
    }

    void checkforPausing()
    {
        if (N_SpwanEnimies.instance.namePrefab == "Square")
        {
            if (Week == true)
            {
                Time.timeScale = 0;
                _WeekPanel.SetActive(true);
                isPaused = true;
                Week = false;
            }
        }
        if (N_SpwanEnimies.instance.namePrefab == "Circle")
        {
            if (strong == true)
            {
                Time.timeScale = 0;
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
