using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Testing
[RequireComponent(typeof(Collider2D))]
public class PigeonFlockAgent : MonoBehaviour
{
    [Range(1f, 10f)]
    public int _pigeonHealth=1;
    [SerializeField] float _timeToEvolve = 10;
    [SerializeField] List<Color> _SkinColor;

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
        StartCoroutine(EvolveHealth());
        EvolveSkin();
    }
    public void InitializePigeonFlock(PigeonFlock _pigeonFlock)
    {
        _myPigeonFlock= _pigeonFlock;
    }
    // Update is called once per frame
    public void Move(Vector2 velocity, bool _force = false)
    {
        if (_force == false) 
        {
            transform.up = velocity;
            PigeonAgentRidgidbody.velocity = velocity;
        }
        else if( _force == true)
        {
            PigeonAgentRidgidbody.AddForce(velocity, ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("P collision detected");
        int tempPHealth = _pigeonHealth;
       

        _pigeonHealth -= collision.gameObject.GetComponent<N_EnemyData>()._maxHealth;
        EvolveSkin();
        collision.gameObject.GetComponent<N_EnemyData>()._maxHealth -= tempPHealth;
        
        if (collision.gameObject.GetComponent<N_EnemyData>()._maxHealth <= 0)
        {
            Destroy(collision.gameObject);
        }
        if (_pigeonHealth <= 0)
        {

            Destroy(this.gameObject);

        }
    }
    private void OnDestroy()
    {
        if (PigeonFlock.Instance._pAgentsList.Count > 0)
        {
            GameData.instance.CalculateFlockBorderRadius(PigeonFlock.Instance._pAgentsList.Count);
            PigeonFlock.Instance._pAgentsList.Remove(this);
            if (this.gameObject.tag == "bullet")
            {
                PigeonFlock.Instance.ChoosePigeonToShootPigeon();
            }
        }
    }
    IEnumerator EvolveHealth()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeToEvolve);
            _pigeonHealth++;
            EvolveSkin();
        }
    }
    void EvolveSkin()
    {
        SpriteRenderer PigeonSkin=this.gameObject.GetComponentInChildren<SpriteRenderer>();
        switch(_pigeonHealth)
        {
            case 1: PigeonSkin.color = _SkinColor[_pigeonHealth-1]; break;
            case 2: PigeonSkin.color = _SkinColor[_pigeonHealth-1]; break;
            case 3: PigeonSkin.color = _SkinColor[_pigeonHealth-1]; break;
            case 4: PigeonSkin.color = _SkinColor[_pigeonHealth-1]; break;
            
        }
    }
}
