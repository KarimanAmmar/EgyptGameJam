using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFlock : MonoBehaviour
{
    public PigeonFlockAgent _pAgentPrefab;
    List<PigeonFlockAgent> _pAgentsList= new List<PigeonFlockAgent>();
    public PigeonFlockBehaviour _pFlockBehaviour;

    [Range(2f, 500f)]
    public int _startingCount = 250;

    const float _agentDensity = 0.08f;

    [Range(0f, 100f)]
    public float _scaleMovement;
    [Range(1f, 100f)]
    public float _maxSpeed=5;
    [Range(1f, 10f)]
    public float _areaOfInfluenceRadius=1.5f;
    [Range(0f, 1f)]
    public float _avoidanceRadiusMultiplier = 0.5f;

    public float _squareMaxSpeed;
    public float _squareAreaOfInfluencedRadius;
    public float _sqaureAvoidanceRadius;
    private void Start()
    {
        _squareMaxSpeed = _maxSpeed * _maxSpeed;
        _squareAreaOfInfluencedRadius = _areaOfInfluenceRadius * _areaOfInfluenceRadius;
        _sqaureAvoidanceRadius =  _squareAreaOfInfluencedRadius*_avoidanceRadiusMultiplier*_avoidanceRadiusMultiplier;

        for (int i = 0; i < _startingCount; i++)
        {
            PigeonFlockAgent newPigeon = Instantiate(_pAgentPrefab, UnityEngine.Random.insideUnitCircle * _startingCount * _agentDensity, Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)), this.transform);

            newPigeon.name = "Pigeon " + i;
            newPigeon.InitializePigeonFlock(this);
            _pAgentsList.Add(newPigeon);

        }


    }

    private void Update()
    {
        foreach(var Pigeon in _pAgentsList) 
        {
            List<Transform> influencedPigeonAgents = GetNearByPigeons(Pigeon);

            Vector2 move = _pFlockBehaviour.CalculateMovementBehaviour(Pigeon, influencedPigeonAgents,this);
            move *= _scaleMovement;
            if(move.sqrMagnitude>_squareMaxSpeed)
            {
                move = move.normalized;
                move *= _maxSpeed;
            }
            Pigeon.Move(move);
        }
    }
    //this is currently getting all objects in the world
    public List<Transform> GetNearByPigeons(PigeonFlockAgent _pigeon)
    {
        List<Transform> influencedPigeonAgents = new List<Transform>();
        Collider2D[] _nearByPigeonsColliders = Physics2D.OverlapCircleAll(_pigeon.transform.position, _areaOfInfluenceRadius);

        foreach(var nearByPigeon in _nearByPigeonsColliders)
        {
            if(nearByPigeon != _pigeon.PigeonAgentCollider) 
            {
                influencedPigeonAgents.Add(nearByPigeon.transform);
            }
        }
        return influencedPigeonAgents;
    }
}
