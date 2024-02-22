using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class K_BirdBehavior : MonoBehaviour
{
    public bool canShoot = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 _fireSpeed;

    void Update()
    {
        move();
    }
    public void move()
    {
        if (canShoot==true)
        {
            rb.velocity = _fireSpeed;
            canShoot = false;
        }
    }
}
