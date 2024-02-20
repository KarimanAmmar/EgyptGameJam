using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PigeonFlock/PigeonBehaviour/Avoidance")]
public class AvoidanceBehaviour : FilteredPigeonBehaviour
{
    public override Vector2 CalculateMovementBehaviour(PigeonFlockAgent _pAgent, List<Transform> _influencedPigeonAgents, PigeonFlock pFlock)
    {
        if (_influencedPigeonAgents.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 _avoidanceMove = Vector2.zero;
        int _nAvoid = 0;

        List<Transform> _filteredNeighbors = (_neighborsFilter == null) ? _influencedPigeonAgents : _neighborsFilter.Filter(_pAgent, _influencedPigeonAgents);

        foreach (Transform Pigeon in _filteredNeighbors)
        {
            if (Vector2.SqrMagnitude(Pigeon.position - _pAgent.transform.position) < pFlock._sqaureAvoidanceRadius)
            {
                _nAvoid++;
                _avoidanceMove += (Vector2)(_pAgent.transform.position-Pigeon.position);
            }
            
        }
        if(_nAvoid>0)
        {
            _avoidanceMove /= _nAvoid;
        }
        

        
        return _avoidanceMove;

    }
}
