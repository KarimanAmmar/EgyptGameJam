using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class N_SpwanEnimies : MonoBehaviour
{
    public static N_SpwanEnimies instance;

    private GameObject randomPrefab;
    private GameObject enemy;
    private int enemyCount =0;
    public bool isSpawning = false;
    public string namePrefab;

    [HideInInspector] public N_EnemyData enemyData;

    public List<GameObject> enemyPrefab;

    [SerializeField] private int minY = -4;
    [SerializeField] private int maxY = 4;
    [SerializeField] private float valX = 10f;

    [SerializeField] private float spwanRate = 2f;
    [SerializeField] private int waveTime = 20;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, spwanRate);
    }

    private void Update()
    {
        if (Time.time > waveTime && enemyCount == 0)
        {
            enemyCount = 1;
        }
        //Debug.Log(Time.time);
    }

    private void SpawnEnemy()
    {
        isSpawning = true;

        randomPrefab = enemyPrefab[Random.Range(0, enemyCount+1)];

        float randomY = Random.Range(minY, minY);
        Vector3 randomPosition = new Vector3(valX, randomY, 0f);

        // Log the spawn information
        Debug.Log("Spawned enemy prefab: " + randomPrefab.name + " at position: " + randomPosition);
        namePrefab = randomPrefab.name;

        enemy = Instantiate(randomPrefab, randomPosition, Quaternion.identity,this.transform);
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
            rb.velocity = new Vector2(- enemyData._speed, 0f);
        }

        //isSpawning = false;
    }
}
