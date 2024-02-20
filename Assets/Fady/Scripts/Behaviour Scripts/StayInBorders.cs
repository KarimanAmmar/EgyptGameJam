using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PigeonFlock/PigeonBehaviour/Stay in Border")]
public class StayInBorders : FilteredPigeonBehaviour
{
    public Vector2 _center;
    public float _radius = 15f;
    public float _borderWeight = 0.9f;

    public override Vector2 CalculateMovementBehaviour(PigeonFlockAgent _pAgent, List<Transform> _influencedPigeonAgents, PigeonFlock pFlock)
    {
        Vector2 _distanceFromPigeonToCenter=_center-(Vector2)_pAgent.transform.position;
        float t = _distanceFromPigeonToCenter.magnitude / _radius;
        if (t < _borderWeight)
        {
            return new Vector2(0,0);
        }
        return _distanceFromPigeonToCenter * t * t;
    }
} 
