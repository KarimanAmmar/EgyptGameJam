using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PigeonFlockBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateMovementBehaviour(PigeonFlockAgent _pAgent, List<Transform> _influencedPigeonAgents, PigeonFlock pFlock);
}
