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
            Destroy(this.gameObject);
            eggEvent.GameAction?.Invoke();
        }
    }
    private void Start()
    {
        StartCoroutine(DestroyEgg());
    }
    IEnumerator DestroyEgg()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
