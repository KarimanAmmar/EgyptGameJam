using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class K_RewardManager : MonoBehaviour
{
    [SerializeField] GameObject Egg;

    public void InstantiateEgg(Transform DiedPigeonPos)
    {
        Instantiate(Egg, DiedPigeonPos.position, Quaternion.identity);
    }
}
