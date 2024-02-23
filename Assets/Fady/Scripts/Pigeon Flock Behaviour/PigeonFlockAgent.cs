using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Testing
[RequireComponent(typeof(Collider2D))]
public class PigeonFlockAgent : MonoBehaviour
{
    [Range(1f, 4f)]
    public int _pigeonHealth=1;
    [SerializeField] float _timeToEvolve = 10;
    public List<RuntimeAnimatorController> _SkinColor;

    Collider2D _pAgentCollider;
    Rigidbody2D _pAgentRigidbody;
    PigeonFlock _myPigeonFlock;

   // [SerializeField] GameEvents gameEvents;
    [SerializeField] GameObject Egg;
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
        AudioManager.instance.PlayerSFX(AudioManager.instance.Collision);
        int tempPHealth = _pigeonHealth;
       

        _pigeonHealth -= collision.gameObject.GetComponent<N_EnemyData>()._maxHealth;
        EvolveSkin();
        collision.gameObject.GetComponent<N_EnemyData>()._maxHealth -= tempPHealth;
        
        if (collision.gameObject.GetComponent<N_EnemyData>()._maxHealth <= 0)
        {
            AudioManager.instance.PlayerSFX(AudioManager.instance.EnemyDeath);
            Destroy(collision.gameObject);
            InstantiateEgg(collision.gameObject.transform);
            //gameEvents.GameAction?.Invoke();
        }
        if (_pigeonHealth <= 0)
        {

            AudioManager.instance.PlayerSFX(AudioManager.instance.PlayerDeath);
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
            if (_pigeonHealth < 3)
            {
                _pigeonHealth++;
                EvolveSkin();
            }
        }
    }
    void EvolveSkin()
    {
        Animator PigeonSkin=this.gameObject.GetComponentInChildren<Animator>();
        if (this.gameObject.tag == "bullet")
        {
            return;
        }
        
        switch(_pigeonHealth)
        {
            
            case 1: PigeonSkin.runtimeAnimatorController = _SkinColor[_pigeonHealth-1]; break;
            case 2: PigeonSkin.runtimeAnimatorController = _SkinColor[_pigeonHealth-1]; break;
            case 3: PigeonSkin.runtimeAnimatorController = _SkinColor[_pigeonHealth - 1]; break;
            //case 4: PigeonSkin.runtimeAnimatorController = _SkinColor[_pigeonHealth - 1]; break;
                //case 4: PigeonSkin.runtimeAnimatorController = Color.black; break;

        }
    }
    public void InstantiateEgg(Transform EggPos)
    {
        Instantiate(Egg, EggPos.transform.position, Quaternion.identity);
    }
}
