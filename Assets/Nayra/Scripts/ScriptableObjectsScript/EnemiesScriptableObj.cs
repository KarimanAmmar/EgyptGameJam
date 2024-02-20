using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyData", order = 1)]

public class EnemiesScriptableObj : ScriptableObject
{
    public string enemyName;
    public int damage;
    public int maxHealth;
    public int speed;
}