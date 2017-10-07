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
	private SpriteRenderer m_Renderer;

	public bool isValid = true;

    private void SetTint(Color tint) {
		m_Renderer.color = tint;
	}

	public void Awake() {
		m_Renderer = GetComponent<SpriteRenderer>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		
		SetTint(defaultTint);
		m_Rigidbody2D.isKinematic = true;
		GetComponent<Collider2D>().isTrigger = true; 
	}

	public void LinkTo(GameObject obj) {
		m_LinkedTarget = obj;
	}

	public void FixedUpdate() {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		m_Rigidbody2D.velocity = new Vector2(h * m_MaxSpeed, v * m_MaxSpeed);
	}

	public Vector3 GetRelativeCenter() {
		return m_Renderer.bounds.center - transform.position;
	}

	public void Update() {
		if (m_LinkedTarget) {
			Vector3 endPos = m_Renderer.bounds.center;
			Vector3 startPos = m_LinkedTarget.transform.position;
			Vector3 joint = (endPos - startPos);
			Vector3 normalizedJoint = joint.normalized;

			if (joint.magnitude > m_MaxDistance) {
				joint = normalizedJoint * m_MaxDistance;
				transform.position = startPos + joint - GetRelativeCenter();
			}

			RaycastHit2D[] hits = new RaycastHit2D[2];
			// Ignore invisible elements
			Physics2D.RaycastNonAlloc(new Vector2(endPos.x, endPos.y),
									  -new Vector2(normalizedJoint.x, normalizedJoint.y),
									  hits, joint.magnitude, LayerMask.NameToLayer("TransparentFX"));

			// hit[0] is always self
			RaycastHit2D hit = hits[1];

			if (hit.collider &&
				(hit.collider.tag != m_LinkedTarget.tag)) {
				SetTint(invalidTint);
				isValid = false;
			}
			else {
				SetTint(defaultTint);
				isValid = true;
			}
		}
	}
}
