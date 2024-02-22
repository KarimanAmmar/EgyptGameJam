using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFlock : MonoBehaviour
{
    [SerializeField] LayerMask _pigeonLayer;
    public PigeonFlockAgent _pAgentPrefab;
    [HideInInspector]
    public List<PigeonFlockAgent> _pAgentsList= new List<PigeonFlockAgent>();
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
    [SerializeField] StayInBorders _pigeonBorder;


    [HideInInspector]
    public float _squareMaxSpeed;
    [HideInInspector]
    public float _squareAreaOfInfluencedRadius;
    [HideInInspector]
    public float _sqaureAvoidanceRadius;

    PigeonFlockAgent _currentSacrificialPigeon;
    private int _currentSacrificialPigeonID;
    private Vector2 _directionToCenter;
    public static PigeonFlock Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
        _currentSacrificialPigeon= ChoosePigeonToShootPigeon();
        


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

        repel();
        attract();


        if (_currentSacrificialPigeon)
        {
            PositionTheSacrificer(_currentSacrificialPigeon);
        }

    }
    private void FixedUpdate()
    {
        //repel();
        //attract();
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
    public PigeonFlockAgent ChoosePigeonToShootPigeon() 
    {


        PigeonFlockAgent _sacrificialPigeon;
        _currentSacrificialPigeonID = UnityEngine.Random.Range(0, _pAgentsList.Count);

        _sacrificialPigeon = _pAgentsList[_currentSacrificialPigeonID];

        _sacrificialPigeon.gameObject.tag = "bullet";
        _sacrificialPigeon.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        _pAgentsList.Remove(_pAgentsList[_currentSacrificialPigeonID]);
        //should be called when the sacrifice pigeon is killed event
        GameData.instance.CalculateFlockBorderRadius(_pAgentsList.Count);

        _currentSacrificialPigeon = _sacrificialPigeon;
        return _sacrificialPigeon;

        

    }
    public void PositionTheSacrificer(PigeonFlockAgent _sacrificer)
    {

        Vector2 _mainPigeonPos = HordeController.instance.Center;

        _mainPigeonPos.x += GameData.instance.FlockBorderRadius;

        _directionToCenter = _mainPigeonPos - (Vector2)_sacrificer.transform.position;
        _sacrificer.transform.up = new Vector2(1,0);

        _sacrificer.gameObject.GetComponent<Rigidbody2D>().velocity = _directionToCenter * _maxSpeed;




        
    }
    void repel()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("here");
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //Debug.Log(mousePos);
            List<GameObject> influencedGameObjects = GetNearByObejcts(mousePos);
            //Debug.Log(influencedGameObjects.Count);
            foreach (var gameObject in influencedGameObjects)
            {
                Vector2 _distanceFromPigeonToCenter = (Vector2)gameObject.transform.position - mousePos;
                float t = _impulseRadius / _distanceFromPigeonToCenter.magnitude;
                //if (t < _borderWeight)
                //{
                //    return new Vector2(0, 0);
                //}
                if (t > 1)

                    gameObject.GetComponent<PigeonFlockAgent>().Move(((_distanceFromPigeonToCenter * t) * _impulsePowerScale), false);
            }
        }
    }
    void attract()
    {
        if (Input.GetMouseButton(1))
        {
            Debug.Log("here");
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //Debug.Log(mousePos);
            List<GameObject> influencedGameObjects = GetNearByObejcts(mousePos);
            //Debug.Log(influencedGameObjects.Count);
            foreach (var gameObject in influencedGameObjects)
            {
                Vector2 _distanceFromPigeonToCenter = mousePos - (Vector2)gameObject.transform.position;
                float t = _impulseRadius + 3 / _distanceFromPigeonToCenter.magnitude;
                //if (t < _borderWeight)
                //{
                //    return new Vector2(0, 0);
                //}
                if (t > 1)

                    gameObject.GetComponent<PigeonFlockAgent>().Move(((_distanceFromPigeonToCenter * t)), false);
            }
        }
    }
    IEnumerator CounterAttack()
    {
        repel();
        yield return new WaitForSeconds(1);
        attract();
    }
}
