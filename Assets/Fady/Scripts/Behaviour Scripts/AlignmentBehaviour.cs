using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PigeonFlock/PigeonBehaviour/Alignment")]
public class AlignmentBehaviour : FilteredPigeonBehaviour
{
    // Start is called before the first frame update
    public override Vector2 CalculateMovementBehaviour(PigeonFlockAgent _pAgent, List<Transform> _influencedPigeonAgents, PigeonFlock pFlock)
    {
        if (_influencedPigeonAgents.Count == 0)
        {
            return _pAgent.transform.up;
        }
        Vector2 _AlginmentMove = Vector2.zero;
        List<Transform> _filteredNeighbors = (_neighborsFilter == null) ? _influencedPigeonAgents : _neighborsFilter.Filter(_pAgent, _influencedPigeonAgents);

        foreach (Transform Pigeon in _filteredNeighbors)
        {

            _AlginmentMove += (Vector2)Pigeon.transform.up;
        }
        _AlginmentMove /= _influencedPigeonAgents.Count;
        return _AlginmentMove;

    }
}
