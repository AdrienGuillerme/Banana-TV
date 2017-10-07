using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShadowBoxScript : MonoBehaviour {
	[SerializeField] private Color defaultTint = new Color(0f, 0.5f, 0f, 0.5f);
	[SerializeField] private Color invalidTint = new Color(0.5f, 0f, 0f, 0.5f);

	[SerializeField] private float m_MaxSpeed = 10f;
	[SerializeField] private float m_MaxDistance = 4f;
	
	private Rigidbody2D m_Rigidbody2D;
	private GameObject m_LinkedTarget;

	public bool isValid = true;

    private void SetTint(Color tint) {
		GetComponent<SpriteRenderer>().color = tint;
	}

	public void Awake() {
		SetTint(defaultTint);

		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Rigidbody2D.isKinematic = true;
		
		GetComponent<Collider2D>().isTrigger = true;
	}

	// public void OnTriggerEnter2D() {
	// 	SetTint(invalidTint);

	// 	isValid = false;
	// }

	// public void OnTriggerExit() {
	// 	SetTint(defaultTint);
		
	// 	isValid = true;
	// }

	public void LinkTo(GameObject obj) {
		m_LinkedTarget = obj;
	}

	public void FixedUpdate() {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		m_Rigidbody2D.velocity = new Vector2(h * m_MaxSpeed, v * m_MaxSpeed);
	}

	public void Update() {
		if (m_LinkedTarget) {
			// TODO: Make it relative to the center of m_LinkedTarget
			Vector3 startPos = m_LinkedTarget.transform.position;
			Vector3 joint = (transform.position - startPos);

			if (joint.magnitude > m_MaxDistance) {
				transform.position = startPos + joint.normalized * m_MaxDistance;
			}
		}
	}
}
