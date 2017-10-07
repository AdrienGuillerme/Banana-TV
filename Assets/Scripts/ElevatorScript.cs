using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {
	[SerializeField] public GameObject minBound;
	[SerializeField] public GameObject maxBound;
	[SerializeField] public Vector2 anchor;

	[SerializeField] public float offsetDelay; // Starting offset delay
	
	// NOTE: If no condition is given, use isActive, otherwhise, use
	// the condition's Active method.
	[SerializeField] public GameObject activationCondition;
	
	[SerializeField] public bool isActive = true;
	[SerializeField] public float speed = 1f;
	[SerializeField] public float delay = 2f;
	
	
	private Rigidbody2D m_Rigidbody;
	private SpriteRenderer m_Renderer;
	private bool direction = false;
	private float stopTime = 0f;
	
	public void Awake() {
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Renderer = GetComponent<SpriteRenderer>();

		stopTime = offsetDelay;
	}

	public Vector3 AbsoluteDim(Vector2 relativeDim) {
		float x = m_Renderer.bounds.size.x;
		float y = m_Renderer.bounds.size.y;
		
		return new Vector3(x * relativeDim.x, y * relativeDim.y, 0);
	}

	// FIXME: MovePosition should be sufficient to allow the player to
	// follow the platform, but it is not...
	public void MoveElevator() {
		Vector3 restPos = minBound.transform.position;
		Vector3 activePos = maxBound.transform.position;
		
		Vector3 anchor3 = AbsoluteDim(anchor);
		Vector3 fromResPos = (restPos - (transform.position + anchor3));
		Vector3 fromActivePos = (activePos - (transform.position + anchor3));
		
		Vector3 v = !direction ? fromActivePos : fromResPos;
		v = transform.position + v.normalized * speed * Time.deltaTime;
		
		m_Rigidbody.MovePosition(v);
	}

	public void OnCollisionStay2D(Collision2D collider) {
		var contact = collider.contacts[0].normal;

		// Something is below us
		if (contact == new Vector2(0, 1)) {
			stopTime = delay;
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Elevator_Bound") {
			direction = !direction;

			stopTime = delay;
		}
	}

	public void Update() {
		if (activationCondition != null) {
			isActive = activationCondition.GetComponent<ActivableElementScript>().Active();
		}
	}
	
	public void FixedUpdate() {
		if (stopTime > 0) {
			stopTime -= Time.deltaTime;
		}

		if (stopTime < 0) {
			stopTime = 0f;
		}
		
		if (!isActive || (stopTime > 0)) {
			return;
		}

		MoveElevator();
	}
}
