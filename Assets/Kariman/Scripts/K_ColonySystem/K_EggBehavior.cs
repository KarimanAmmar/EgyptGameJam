using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_EggBehavior : MonoBehaviour
{
    [SerializeField] GameEvents eggEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pigeon"))
        {
            eggEvent.GameAction?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
