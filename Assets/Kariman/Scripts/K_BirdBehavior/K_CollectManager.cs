using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_CollectManager : MonoBehaviour
{
    public K_ColonySystem colonySystem;

    int maxCount = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pigean")
        {
            if (colonySystem.counter + 1 <= maxCount)
            {
                colonySystem.counter++;
            }
        }
    }
}
