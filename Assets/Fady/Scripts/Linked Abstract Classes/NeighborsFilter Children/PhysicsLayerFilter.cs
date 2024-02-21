using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "PigeonFlock/Filter/PhysicsLayerFilter")]
public class PhysicsLayerFilter : NeighborsFilter
{
    public LayerMask _mask;
    public override List<Transform> Filter(PigeonFlockAgent _pAgent, List<Transform> _unFilteredNeighbors)
    {
        List<Transform> _filteredNeighbors = new List<Transform>();
        foreach (var neighbor in _unFilteredNeighbors)
        {
            if(_mask == (_mask | (1 << neighbor.gameObject.layer)))
            {
                _filteredNeighbors.Add(neighbor);
            }
        }
        return _filteredNeighbors;
    }
}
