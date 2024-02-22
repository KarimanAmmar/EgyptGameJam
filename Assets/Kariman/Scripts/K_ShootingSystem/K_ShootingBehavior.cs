using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace GameSystem.ShootingSystem
{
    public class K_ShootingBehavior : MonoBehaviour
    {
        [SerializeField] private List<PigeonFlockAgent> babybirds = new List<PigeonFlockAgent>();
        private void Update()
        {
            Shoot();
        }
        void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {//todo
                Vector2 shootPos = HordeController.instance.Center;
                shootPos.x = +GameData.instance.FlockBorderRadius;
                if (PigeonFlock.Instance._pAgentsList.Count > -1&&Vector2.Distance(PigeonFlock.Instance._currentSacrificialPigeon.transform.position, shootPos)<1)
                {
                    CollectChildObjects();
                    for (int i = 0; i < babybirds.Count; i++)
                    {
                        if (babybirds[i].gameObject.tag == "bullet")
                        {
                            PigeonFlockAgent agentpigeon = babybirds[i].GetComponent<PigeonFlockAgent>();
                            agentpigeon.MyPigeonFlock._pAgentsList.Remove(babybirds[i]);
                            K_BirdBehavior FirePigeonManager = babybirds[i].GetComponent<K_BirdBehavior>();
                            FirePigeonManager.canShoot = true;
                            Debug.Log("found");
                        }
                    }
                    PigeonFlock.Instance._currentSacrificialPigeon = PigeonFlock.Instance.ChoosePigeonToShootPigeon();
                }
            }
        }
        void CollectChildObjects()
        {
            babybirds.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                PigeonFlockAgent pigeonFlockAgent = child.GetComponent<PigeonFlockAgent>();
                if (pigeonFlockAgent != null)
                {
                    babybirds.Add(pigeonFlockAgent);
                    Debug.Log("added");
                }
            }
        }
    }
}