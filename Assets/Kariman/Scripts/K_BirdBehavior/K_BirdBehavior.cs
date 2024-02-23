using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class K_BirdBehavior : MonoBehaviour
{
    public bool canShoot = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 _fireSpeed;
    [SerializeField] int MaxRange;
    //[SerializeField] Transform EndPoint;
    [SerializeField] GameEvents InstantiatePigeon;
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
        float distanceX = Mathf.Abs(this.transform.position.x - MaxRange);

        if (distanceX <= 1.5)
        {
            InstantiatePigeon.GameAction?.Invoke();
            PigeonFlock.Instance._pAgentsList.Remove(this.gameObject.GetComponent<PigeonFlockAgent>());
            Destroy(this.gameObject);
        }
    }
}
