using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PigeonFlockAgent : MonoBehaviour
{
    Collider2D _pAgentCollider;
    Rigidbody2D _pAgentRigidbody;
    PigeonFlock _myPigeonFlock;

    public PigeonFlock MyPigeonFlock { get { return _myPigeonFlock; } set{ _myPigeonFlock = value; } }
    public Collider2D PigeonAgentCollider { get { return _pAgentCollider; } set { _pAgentCollider = value; } }
    public Rigidbody2D PigeonAgentRidgidbody { get { return _pAgentRigidbody; } set { _pAgentRigidbody = value; } }
    // Start is called before the first frame update
    void Start()
    {
        _pAgentCollider = GetComponent<Collider2D>();
        _pAgentRigidbody= GetComponent<Rigidbody2D>();
    }
    public void InitializePigeonFlock(PigeonFlock _pigeonFlock)
    {
        _myPigeonFlock= _pigeonFlock;
    }
    // Update is called once per frame
    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        PigeonAgentRidgidbody.velocity = velocity;

    }
}
