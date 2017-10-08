using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using UnityEngine;

public class AiRange : MonoBehaviour {

    // Use this for initialization
    Transform target;
    Transform enemyTransform;
    public float speed = 3f;
    public float rotationSpeed = 3f;
    public float detectionRange = 10;
    public int Range;
    private float _cooldown = 0.5f;
    private float _timeStamp;
    public GameObject ProjectileModel;
    public int HowStrong;      

	private Animator m_Anim;// Reference to the player's animator component.
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    void OnCollisionEnter2D(Collision2D coll)
    {
        var contact = coll.contacts[0].normal;
        if (coll.gameObject.tag == "Player" && (contact == new Vector2(-1, 0) || contact == new Vector2(1, 0)))
        {
            Time.timeScale = 0;
            SettingsConstants.DieMenu.SetActive(true);
        }

    }
    void Start()
    {
        enemyTransform = gameObject.GetComponent<Transform>();
		m_Anim = GetComponent<Animator>();
        //obtain the game object Transform
    }

    void Update()
    {

        target = GameObject.FindWithTag("Player").transform;
        Vector3 targetHeading = target.position - enemyTransform.position;
        Vector3 targetDirection = targetHeading.normalized;

		if (Range < targetHeading.magnitude) {
			gameObject.GetComponent<Rigidbody2D> ().velocity += new Vector2 (targetDirection.x, targetDirection.y) * speed * Time.deltaTime;
			Vector3 temp = enemyTransform.localScale;
			//enable walk animation
			if (targetHeading.x == 0)
				m_Anim.SetBool ("walk", false);
			else
				m_Anim.SetBool ("walk", true);
			//
			if (targetHeading.x > 0)
				temp.x = 1;
			else if (targetHeading.x < 0)
				temp.x = -1;
			//Flip if needed
			// If the input is moving the player right and the player is facing left...
			if (temp.x > 0 && !m_FacingRight)
				Flip ();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (temp.x < 0 && m_FacingRight)
				Flip ();
			
			enemyTransform.localScale = temp;
		} else if (_timeStamp <= Time.time) {
			m_Anim.SetBool ("attack", true);
			_timeStamp = Time.time + _cooldown;

			Vector2 myPos = new Vector2 (transform.position.x, transform.position.y);
			Vector2 direction = Vector2.zero;

			if (targetHeading.x > 0) {
				direction = gameObject.transform.right;
			} else {
				direction = -gameObject.transform.right;
			}
			direction.Normalize ();
			GameObject bullet = (GameObject)Instantiate (ProjectileModel, myPos, Quaternion.identity);
			//spawning the bullet at position
			var rigidBody = bullet.GetComponent<Rigidbody2D> ();
			Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D> (), gameObject.GetComponent<BoxCollider2D> ());
			Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D> (), gameObject.GetComponent<CircleCollider2D> ());
			Destroy (bullet, 10);
			rigidBody.AddForce (direction * (HowStrong + gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude), ForceMode2D.Force);
		} else {
			m_Anim.SetBool ("attack", false);
		}
           
        /** 
        //rotate to look at the player
            


        //move towards the player
       // 
     //   

        if (Vector3.Distance(transform.position, target.position) >= 150)
        {

        //      transform.position += transform.forward * 50 * Time.deltaTime;

        }**/
    }
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the enemy's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
