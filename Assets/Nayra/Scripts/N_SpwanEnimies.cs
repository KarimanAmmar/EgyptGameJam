using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class N_SpwanEnimies : MonoBehaviour
{
    public static N_SpwanEnimies instance;

    private GameObject randomPrefab;
    internal GameObject enemy;
    private int enemyCount =0;
    public string namePrefab;

    [HideInInspector] public N_EnemyData enemyData;

    public List<GameObject> enemyPrefab;

    [SerializeField] private int minY = -4;
    [SerializeField] private int maxY = 4;
    [SerializeField] private float valX = 10f;

    [SerializeField] private float spwanRate = 1.5f;
    [SerializeField] private int waveTime = 20;

    [SerializeField] GameEvents _checkEnemy;

 

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(spwanratechange());
    }

    private void Update()
    {
        if (Time.time > waveTime && enemyCount == 0)
        {
            enemyCount = 1;
        }
        //Debug.Log(Time.time);
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spwanRate);
            randomPrefab = enemyPrefab[Random.Range(0, enemyCount + 1)];

            float randomY = Random.Range(minY, maxY);
            Vector3 randomPosition = new Vector3(valX, randomY, 0f);

            // Log the spawn information
            //Debug.Log("Spawned enemy prefab: " + randomPrefab.name + " at position: " + randomPosition);
            namePrefab = randomPrefab.name;


            //enemy = Instantiate(randomPrefab, randomPosition, Quaternion.identity,this.transform);
            enemy = Instantiate(randomPrefab, randomPosition, Quaternion.Euler(0f, 0f, 90f), this.transform);
            enemyData = enemy.GetComponent<N_EnemyData>();

            /*float randomY = Random.Range(Screen.height, 0);
            Vector3 randomScreenPosition = new Vector3(Screen.width, randomY, 10);
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);
            enemy = Instantiate(randomPrefab, randomPosition, Quaternion.identity);*/

            // Add velocity to the enemy
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //float randomSpeed = Random.Range(1f, 5f);
                //rb.velocity = new Vector2(-randomSpeed , 0f);
                rb.velocity = new Vector2(-enemyData._speed, 0f);
            }
            _checkEnemy.GameAction?.Invoke();
            Debug.Log("1.5 =" +spwanRate);
        }
    }
    IEnumerator spwanratechange()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            if(spwanRate > 0.8)
            {
                spwanRate -= 0.05f;
            }
            Debug.Log("20 =" + spwanRate);
        }
    }
}
