using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HordeController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1;

    [SerializeField] Transform BLBoundry;
    [SerializeField] Transform URBoundry;
    private Vector2 _moveDirection = Vector2.zero;
    
    private Vector2 _center;

    private Rigidbody2D rb;
    public Vector2 Center { get { return _center; } set { _center = value; } }

    public Vector2 MoveDirection { get { return _moveDirection; } set { _moveDirection = value; } }

    public static HordeController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _center = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < BLBoundry.position.x)
        {
            transform.position = new Vector2(BLBoundry.position.x, transform.position.y);
            _center = transform.position;
        }
        else if (transform.position.x > URBoundry.position.x)
        {
            transform.position = new Vector2(URBoundry.position.x, transform.position.y);
            _center = transform.position;
        }

        if (transform.position.y < BLBoundry.position.y)
        {
            transform.position = new Vector2(transform.position.x, BLBoundry.position.y);
            _center = transform.position;
        }
        else if (transform.position.y > URBoundry.position.y)
        {
            transform.position = new Vector2(transform.position.x, URBoundry.position.y);
            _center = transform.position;
        }

        if (_moveDirection != Vector2.zero)
        {
            rb.velocity = _moveDirection * _moveSpeed;
            _center = transform.position;
             
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    public void OnMove(InputValue value)
    {

        Vector2 movedirection = value.Get<Vector2>();

        _moveDirection = movedirection;


    }
}
