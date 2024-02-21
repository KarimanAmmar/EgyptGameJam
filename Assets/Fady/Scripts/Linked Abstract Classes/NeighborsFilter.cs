using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NeighborsFilter : ScriptableObject
{
   public abstract List<Transform> Filter(PigeonFlockAgent _pAgent,List<Transform> _unFilteredNeighbors);
}
