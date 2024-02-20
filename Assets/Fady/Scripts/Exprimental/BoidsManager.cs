using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonoBehaviour
{
    [Header("Boids Stats")]
    [SerializeField] private GameObject Boid;
    [SerializeField] private int BoidsCount;

    [Range(1, 10)]
    public float MaxSpeed;
    [Range(1, 10)]
    public float MinSpeed;

    public float seperationDistance;
    public Transform GOAL;

    [HideInInspector]
    public GameObject[] boids;
    [HideInInspector]
    public static BoidsManager instance;
    //-----------------------------------
    [Header("Spawning Stats")]
    [SerializeField] private float spawnRadius = 5;
    [Range(0, 10)] public float minSpawnRate = 3;
    [Range(0, 10)] public float maxSpawnRate = 3;
    [SerializeField] private float spawnOffset = 7;
    private Vector3 spawnPos = Vector3.zero;
    public int boidCounter = 0;


    //
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        boids = new GameObject[BoidsCount];
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //-------------
    
    IEnumerator spawnEnemy()
    {
         boidCounter = 0;
        while (boidCounter < BoidsCount)
        {
            
            float x = UnityEngine.Random.Range((spawnRadius * -1) + transform.position.x, spawnRadius + transform.position.x);
            float z = UnityEngine.Random.Range((spawnRadius * -1) + transform.position.z, spawnRadius + transform.position.z);
            float y = UnityEngine.Random.Range(0 + transform.position.y, spawnRadius + transform.position.y);
            if (x >= 0)
            {
                spawnPos.x = x + spawnOffset;
            }
            else if (x < 0)
            {
                spawnPos.x = x - spawnOffset;

            }
            //if (z >= 0)
            //{
            //    spawnPos.z = z + spawnOffset;
            //}
            //else if (z < 0)
            //{
            //    spawnPos.z = z - spawnOffset;
            //}
            if (y >= 0)
            {
                spawnPos.y = y + spawnOffset;
            }
            else if (y < 0)
            {
                spawnPos.y = y - spawnOffset;
            }

            float tempRate=UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(tempRate);

            boids[boidCounter] =Instantiate(Boid, spawnPos, Quaternion.identity,this.transform);
            boidCounter++;

        }

    }
}
