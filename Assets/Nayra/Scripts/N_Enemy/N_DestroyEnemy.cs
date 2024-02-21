using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_DestroyEnemy : MonoBehaviour
{
    void Update()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
        //transform.position += new Vector3(0.1f * this.transform.localScale.x, 0, 0);
    }
}
