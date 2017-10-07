using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CeilingBladesScript : MonoBehaviour {
	// NOTE: If no condition is given, use isActive, otherwhise, use
	// the condition's Active method.
	[SerializeField] public GameObject activationCondition;

	[SerializeField] public float offsetDelay; // Starting offset delay
	
	[SerializeField] public bool isActive = true;
	[SerializeField] public float speed = 1f; // Animation speed
	[SerializeField] public float retractDelay = 2f; // Seconds after an expand to start retracting
	[SerializeField] public float expandDelay = 2f; // Seconds after a retract to start expanding
	
	// TODO / @Temporary: The animation time itself should be used!
	[SerializeField] public float animationDuration = 2f;
	[SerializeField] public float indulgenceDelay = 0.2f;

	private Rigidbody2D m_Rigidbody;
	private SpriteRenderer m_Renderer;
	private float m_StopTime = 0f;
	private bool m_Retracted = true;

	private Collider2D m_Collider;

	public void Awake() {
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Renderer = GetComponent<SpriteRenderer>();
		m_Collider = GetComponent<Collider2D>();
		 
		m_StopTime = offsetDelay;
		
		m_Collider.isTrigger = false;
	}

	public void Update() {
		if (activationCondition != null) {
			isActive = activationCondition.GetComponent<ActivableElementScript>().Active();
		}
	}

	public void SetRetracted() {
		m_Retracted = true;
		m_Collider.isTrigger = false; 
			
		// TODO / @Temporary: Remove this once we have a proper animation.
		m_Renderer.color = new Color(0f, 0f, 0f, 1f);
	}

	public void SetExpanded() {
		m_Retracted = false;
		m_Collider.isTrigger = true;

		// TODO / @Temporary: Remove this once we have a proper animation.
		m_Renderer.color = new Color(1f, 0f, 0f, 1f);
	}

	private void Retract() {
		// TODO: Play animation, wait until animation is nearly
		// finished and set retracted to true;

		Invoke("SetRetracted", animationDuration - indulgenceDelay);
		m_StopTime = animationDuration + expandDelay;
	}
	
	private void Expand() {
		// TODO: Play animation;

		Invoke("SetExpanded", indulgenceDelay);
		m_StopTime = animationDuration + retractDelay;
	}

	public void FixedUpdate() {
		if (m_StopTime > 0) {
			m_StopTime -= Time.deltaTime;
		}

		if (m_StopTime < 0) {
			m_StopTime = 0f;
		}

		if (!isActive && !m_Retracted) {
			Retract();
		}
		else if (isActive && (m_StopTime == 0)) {
			if (m_Retracted) {
				Expand();
			}
			else{
				Retract();
			}
		}
	}
}
