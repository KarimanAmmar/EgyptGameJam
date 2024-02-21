using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField]
    private StayInBorders _flockBorder;
    public float _flockBorderRadius;

    public float FlockBorderRadius { get { return _flockBorderRadius; } set { _flockBorderRadius = value; } }

    public static GameData instance;

    // Start is called before the first frame update
    private void Awake()
    {
        _flockBorderRadius = _flockBorder._radius;
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CalculateFlockBorderRadius(int currentFlockCount)
    {

        _flockBorderRadius = currentFlockCount / 10f;
        Debug.Log("flock count"+currentFlockCount);
        Debug.Log(currentFlockCount / 10);
        

    }
}
