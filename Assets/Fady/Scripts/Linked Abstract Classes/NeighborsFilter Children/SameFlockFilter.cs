using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PigeonFlock/Filter/Same Flock")]
public class SameFlockFilter : NeighborsFilter
{
    [SerializeField] bool _useFlock = false;
    public override List<Transform> Filter(PigeonFlockAgent _pAgent, List<Transform> _unFilteredNeighbors)
    {
       List<Transform> _filteredNeighbors = new List<Transform>();
        foreach (var neighbor in _unFilteredNeighbors)
        {
            PigeonFlockAgent _pigeonOriginFlock = neighbor.GetComponent<PigeonFlockAgent>();
            //set this if to false if u want the swarm effect
            if(_useFlock==true&&_pigeonOriginFlock != null&& _pigeonOriginFlock.MyPigeonFlock==_pAgent.MyPigeonFlock ) 
            {
            
                _filteredNeighbors.Add(neighbor);
            }
        }
        return _filteredNeighbors;
    }

    
}
