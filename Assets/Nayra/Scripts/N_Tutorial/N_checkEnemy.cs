using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_checkEnemy : MonoBehaviour
{
    [SerializeField] private GameEvents _checkEnemy;
    private void OnEnable()
    {
        _checkEnemy.GameAction += EnemySpawned;
    }
    private void OnDisable()
    {
        _checkEnemy.GameAction -= EnemySpawned;
    }
    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("yutu");
        if(N_SpwanEnimies.instance.isSpawning == true)
        {
            Debug.Log("Check Spawned Enemy" + N_SpwanEnimies.instance.namePrefab);
        }*/

        // Check if the spawned enemy's position is less than or equal to -4 on the x-axis
        if (N_SpwanEnimies.instance.enemy != null && N_SpwanEnimies.instance.enemy.transform.localPosition.x <= -4f)
        {
            // Pause the game
            N_GameUI.instance.PauseGame();
        }
    }

    public void EnemySpawned()
    {
        //Debug.Log("Check Spawned Enemy" + N_SpwanEnimies.instance.namePrefab);
        if(N_SpwanEnimies.instance.namePrefab == "Square")
        {
            Debug.Log("enemy pos ========= " + N_SpwanEnimies.instance.enemy.transform.position.x);
            if (N_SpwanEnimies.instance.enemy.transform.position.x <= -4f)
            {
                Debug.Log("--------It is square -----------");
                N_GameUI.instance.PauseGame();
            }

        }
        if(N_SpwanEnimies.instance.namePrefab == "Circle")
        {
            Debug.Log("***********It is Circle *************");
        }

    }
}
