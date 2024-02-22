using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    [SerializeField] float speed = 1.0f;

    void FixedUpdate()
    {
        BackGroundMovements();
    }
    void BackGroundMovements()
    {
        transform.position = Vector3.MoveTowards(transform.position, position2.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, position2.position) < 0.02f)
        {
            transform.position = position1.position;
        }
    }
}
