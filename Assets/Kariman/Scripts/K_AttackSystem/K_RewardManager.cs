using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class K_RewardManager : MonoBehaviour
{
    [SerializeField] GameObject Egg;
    [SerializeField] K_ColonySystem colonySystemRef;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
             Transform instanciatepos = other.transform;
             Instantiate(Egg, instanciatepos.position, Quaternion.identity);
             K_CollectManager currentEggCollector = Egg.GetComponent<K_CollectManager>();
             currentEggCollector.colonySystem = colonySystemRef;
             Destroy(other.gameObject);
        }
    }
}
