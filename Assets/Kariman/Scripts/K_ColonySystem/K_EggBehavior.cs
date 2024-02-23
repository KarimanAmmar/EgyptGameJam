using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_EggBehavior : MonoBehaviour
{
    [SerializeField] GameEvents eggEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pigeon") ||
            other.gameObject.layer == LayerMask.NameToLayer("MainPigeon"))
        {
            eggEvent.GameAction?.Invoke();
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (Time.time > 4)
        {
            Destroy(this.gameObject);
        }
    }
}
