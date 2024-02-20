using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_colonyManager : MonoBehaviour
{
    [SerializeField] GameObject Egg;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
             Transform instanciatepos = other.transform;
             Instantiate(Egg, instanciatepos.position, Quaternion.identity);
             Destroy(other.gameObject);
        }
    }
}
