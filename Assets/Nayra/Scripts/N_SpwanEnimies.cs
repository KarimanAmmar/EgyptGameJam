using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class N_SpwanEnimies : MonoBehaviour
{
    private GameObject randomPrefab;
    private GameObject enemy;
    private int enemyCount =0;

    [HideInInspector] public N_EnemyData enemyData;

    public List<GameObject> enemyPrefab;

    private void Start()
    {
        
        InvokeRepeating("SpawnEnemy", 2f, 2f);
    }

    private void Update()
    {
        if (Time.time > 20 && enemyCount == 0)
        {
            enemyCount = 1;
        }
        //Debug.Log(Time.time);
    }

    private void SpawnEnemy()
    {
        randomPrefab = enemyPrefab[Random.Range(0, enemyCount+1)];
        float randomY = Random.Range(-5, 5);
        Vector3 randomPosition = new Vector3(5f, randomY, 0f);
        enemy = Instantiate(randomPrefab, randomPosition, Quaternion.identity);
        enemyData = enemy.GetComponent<N_EnemyData>();

        /*float randomY = Random.Range(Screen.height, 0);
        Vector3 randomScreenPosition = new Vector3(Screen.width, randomY, 10);
        Vector3 randomPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);
        enemy = Instantiate(randomPrefab, randomPosition, Quaternion.identity);*/

        // Add velocity to the enemy
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float randomSpeed = Random.Range(1f, 5f);
            //rb.velocity = new Vector2(-randomSpeed , 0f);
            rb.velocity = new Vector2(- enemyData.Enemies.speed, 0f);
        }
    }
}
