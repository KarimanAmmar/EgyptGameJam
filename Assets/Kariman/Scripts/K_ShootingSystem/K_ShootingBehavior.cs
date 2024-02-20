using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace GameSystem.ShootingSystem
{
    public class K_ShootingBehavior : MonoBehaviour
    {
        private List<GameObject> babybirds = new List<GameObject>();
        [SerializeField] float moveSpeed;


        private void Update()
        {
             Shoot();
        }
        void Shoot()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                CollectChildObjects();
                foreach (GameObject babyBird in babybirds)
                {
                    if (babyBird.CompareTag("RedBird"))
                    {
                        K_BirdBehavior behavior = babyBird.GetComponent<K_BirdBehavior>();
                        behavior.canShoot = true;
                        Debug.Log("found");
                    }
                }
            }
        }
        void CollectChildObjects()
        {
            babybirds.Clear();
            foreach (Transform child in transform)
            {
                babybirds.Add(child.gameObject);
                Debug.Log("added");
            }
        }
    }
}
