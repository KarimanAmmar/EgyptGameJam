using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PigeonFlock/PigeonBehaviour/Smoothed Cohesion")]
public class SmoothCohesionBehaviour : FilteredPigeonBehaviour
{
    Vector2 _currentVelocity;
    public float _smoothScale = 0.5f;
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
        _cohesionMove = Vector2.SmoothDamp(_pAgent.transform.up, _cohesionMove, ref _currentVelocity, _smoothScale);//current direction , target Direction,current Velocity , smoothscale (t)
        return _cohesionMove;

    }
}
