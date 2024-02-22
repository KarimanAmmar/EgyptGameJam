using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_EnemyData : MonoBehaviour
{
    [SerializeField] private EnemiesScriptableObj enemies;

    public string _enemyName;
    public int _damage;
    public int _maxHealth;
    public int _speed;
    private void Awake()
    {
        Debug.Log("Start");
        Debug.Log(enemies.name + enemies.damage + enemies.maxHealth + enemies.speed);
        _enemyName = enemies.enemyName;
        _damage = enemies.damage;
        _maxHealth = enemies.maxHealth;
        _speed = enemies.speed;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Debug.Log("enemy Health"+_maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MainPigeon"))
        {
            Destroy(collision.gameObject);
            N_GameUI.instance.LoseGame();
            //End Game Logic
        }
        

    }

}
