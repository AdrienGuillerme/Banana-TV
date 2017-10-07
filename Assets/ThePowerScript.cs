using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ThePowerScript : MonoBehaviour {


    [SerializeField] private string _buttonName = "";
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private Platformer2DUserControl _caster;


    private float _timeLeftBeforeReset = 0.5f;
    public GameObject ProjectileModel;
    private float _timeStamp;
    public int HowStrong;
    public float HowLong;
    // Use this for initialization
    void Start () {
		
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
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        GameObject bullet = (GameObject)Instantiate(ProjectileModel, myPos, rotation);
        //spawning the bullet at position
        var rigidBody = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), _caster.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), _caster.GetComponent<CircleCollider2D>());
        Destroy(bullet, 10);
        rigidBody.AddForce(direction*(HowStrong + _caster.GetComponent<Rigidbody2D>().velocity.magnitude),ForceMode2D.Force);
    }
    // Update is called once per frame      
    void Update () {
        if (Input.GetButtonDown(_buttonName))
        {
            if(_timeStamp <= Time.time)
                    FireBullet();
        }
	}

    
}
