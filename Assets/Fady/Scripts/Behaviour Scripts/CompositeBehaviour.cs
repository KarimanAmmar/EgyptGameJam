using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PigeonFlock/PigeonBehaviour/Composite")]
public class CompositeBehaviour : PigeonFlockBehaviour
{
    public List<PigeonFlockBehaviour> _behaviours;
    public List<float> _wieghts;
    public override Vector2 CalculateMovementBehaviour(PigeonFlockAgent _pAgent, List<Transform> _influencedPigeonAgents, PigeonFlock pFlock)
    {
        if (_wieghts.Count != _behaviours.Count)
        {
            return Vector2.zero;
        }
        Vector2 move = Vector2.zero;
        for (int i = 0; i < _behaviours.Count; i++)
        {
            Vector2 _partOfDirection = _behaviours[i].CalculateMovementBehaviour(_pAgent, _influencedPigeonAgents,pFlock)*_wieghts[i];
            if(_partOfDirection.sqrMagnitude > _wieghts[i] * _wieghts[i])
            {
                _partOfDirection.Normalize();
                _partOfDirection *= _wieghts[i];
            }
            move += _partOfDirection;
        }
        return move;
    }

}
