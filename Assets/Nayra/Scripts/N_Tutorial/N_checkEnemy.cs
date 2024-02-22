using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_checkEnemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("yutu");
        if(N_SpwanEnimies.instance.isSpawning == true)
        {
            Debug.Log("Check Spawned Enemy" + N_SpwanEnimies.instance.namePrefab);
        }
    }
}
