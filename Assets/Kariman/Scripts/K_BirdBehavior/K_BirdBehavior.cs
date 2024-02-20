using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class K_BirdBehavior : MonoBehaviour
{
    [SerializeField] float speed;

    public bool canShoot = false;

    void Update()
    {
        move();
    }
    public void move()
    {
        if (canShoot==true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
