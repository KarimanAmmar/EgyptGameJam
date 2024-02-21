using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PigeonFlock/PigeonBehaviour/Cohesion")]
public class CohesionBehaviour : FilteredPigeonBehaviour
{
    public override Vector2 CalculateMovementBehaviour(PigeonFlockAgent _pAgent, List<Transform> _influencedPigeonAgents, PigeonFlock pFlock)
    {
        if (_influencedPigeonAgents.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 _cohesionMove = Vector2.zero;
        List<Transform> _filteredNeighbors = (_neighborsFilter == null) ? _influencedPigeonAgents : _neighborsFilter.Filter(_pAgent, _influencedPigeonAgents);

        foreach (Transform Pigeon in _filteredNeighbors)
        {

            _cohesionMove += (Vector2)Pigeon.position;
        }
        _cohesionMove /= _influencedPigeonAgents.Count;

        ////
        /// we use this calculate the direction to the center of the flock.
        /// we dont multiply by the speed since we control that by seeing if the vector magnitued is higher than the max speed.
        /// if it is we clamp it 
        //
        _cohesionMove -= (Vector2)_pAgent.transform.position;
        return _cohesionMove;

    }
}
