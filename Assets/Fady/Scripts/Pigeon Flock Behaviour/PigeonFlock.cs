using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFlock : MonoBehaviour
{
    [SerializeField] LayerMask _pigeonLayer;
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
    [Header("PlayerAbilities")]
    [SerializeField] float _impulseRadius = 1;
    [SerializeField] float _impulsePowerScale = 10;
    


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
        
        if(Input.GetMouseButton(0))
        {
            Debug.Log("here");
            Vector2 mousePos= Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            List<GameObject> influencedGameObjects = GetNearByObejcts(mousePos);
            Debug.Log(influencedGameObjects.Count);
            foreach (var gameObject in influencedGameObjects)
            {
                Vector2 _distanceFromPigeonToCenter =  (Vector2)gameObject.transform.position- mousePos;
                float t =_impulseRadius / _distanceFromPigeonToCenter.magnitude ;
                //if (t < _borderWeight)
                //{
                //    return new Vector2(0, 0);
                //}
                if(t>1)

                gameObject.GetComponent<PigeonFlockAgent>().Move(((_distanceFromPigeonToCenter*t)*_impulsePowerScale),false);
            }
        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("here");
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            List<GameObject> influencedGameObjects = GetNearByObejcts(mousePos);
            Debug.Log(influencedGameObjects.Count);
            foreach (var gameObject in influencedGameObjects)
            {
                Vector2 _distanceFromPigeonToCenter =  mousePos-(Vector2)gameObject.transform.position;
                float t =  _impulseRadius+ 3/_distanceFromPigeonToCenter.magnitude;
                //if (t < _borderWeight)
                //{
                //    return new Vector2(0, 0);
                //}
                if (t > 1)

                    gameObject.GetComponent<PigeonFlockAgent>().Move(((_distanceFromPigeonToCenter * t)), false);
            }
        }


    }
    //this is currently getting all objects in the world
    public List<Transform> GetNearByPigeons(PigeonFlockAgent _pigeon)
    {
        List<Transform> influencedPigeonAgents = new List<Transform>();
        //todo if there is no neighbors the will be like a target or an attraction for the pigeon
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
    public List<GameObject> GetNearByObejcts(Vector2 point)
    {
        List<GameObject> influencedGameObejcts = new List<GameObject>();
        Collider2D[] _nearByGameObjectsColliders = Physics2D.OverlapCircleAll(point, _impulseRadius,_pigeonLayer);

        foreach (var nearByPigeon in _nearByGameObjectsColliders)
        {
            
                influencedGameObejcts.Add(nearByPigeon.gameObject);
            
        }
        return influencedGameObejcts;
    }
}
