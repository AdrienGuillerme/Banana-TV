using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityStandardAssets._2D;

public class ThePowerScript : MonoBehaviour {


    [SerializeField] private string _buttonName = "";
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private Platformer2DUserControl _caster;
	[SerializeField] private float _maxHoldDuration = 3f;
	[SerializeField] private float _holdModifier = 0.4f;
	[SerializeField] private float _timeForShootingAnimation = 12f;

    private float _timeLeftBeforeReset = 0.5f;
	private float _holdTimestamp = 0f;
    public GameObject ProjectileModel;
    private float _timeStamp;
    public int HowStrong;
    public float HowLong;
    public GameObject DieView;


	//var for the animation of the bullet
	private Animator m_Anim;
	private float _fireAnimationTime = 12f;

    // Use this for initialization
    void Start ()
    {
        SettingsConstants.DieMenu = DieView;
		m_Anim = GetComponent<Animator>();
	}

    public void FireBullet()    
    {
        //Clone of the bullet
        _timeStamp = Time.time + _cooldown;

        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = Vector2.zero;
        if (_caster.m_Character.FacingRight())
        {
            direction = _caster.transform.right;
        }
        else
        {
            direction = - _caster.transform.right;
        }
        direction.Normalize();

		var holdingTime = 0f;

		if (_holdTimestamp != 0) {
			holdingTime = Time.time - _holdTimestamp;
		}
		
		holdingTime = (holdingTime <= _maxHoldDuration) ? holdingTime : _maxHoldDuration;
		var holdFactor = (1 + holdingTime * _holdModifier);
		
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        GameObject bullet = (GameObject)Instantiate(ProjectileModel, myPos, rotation);
		bullet.transform.localScale *= holdFactor;
        //spawning the bullet at position
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), _caster.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), _caster.GetComponent<CircleCollider2D>());
        Destroy(bullet, 10);

		
		var totalForce = HowStrong * holdFactor;
		
        rigidBody.AddForce(direction*(totalForce + _caster.GetComponent<Rigidbody2D>().velocity.magnitude),ForceMode2D.Force);

		_holdTimestamp = 0f;
    }
	
    // Update is called once per frame      
    void Update () {
		if (m_Anim.GetBool("Fire") ) {
			m_Anim.SetBool ("Fire", false);
		}
        if (Input.GetButtonDown(_buttonName))
        {
			_holdTimestamp = Time.time;
        }
		else if (Input.GetButtonUp(_buttonName)) {
			if (_timeStamp <= Time.time) {
				m_Anim.SetBool("Fire", true);
				FireBullet ();
			}
		}
	}

    
}
