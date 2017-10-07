using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
	public PlatformerCharacter2D m_Character;
	private bool m_Jump;
	private bool m_Interacting;
	private bool m_CanMove = true;

	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			m_Interacting = CrossPlatformInputManager.GetButtonDown("Submit");
		}
	}

	private void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = CrossPlatformInputManager.GetAxis("Horizontal");

		h *= m_CanMove ? 1f : 0f;
		crouch = crouch && m_CanMove;
		m_Jump = m_Jump && m_CanMove;
			
		// Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;
	}

	public void OnTriggerStay2D(Collider2D collider) {
		// FIXME: Should probably use another boolean value
		// (m_CanInteract or whatever).
		if ((collider.gameObject.layer == LayerMask.NameToLayer("Interactive_Element")) &&
			m_Interacting && m_CanMove) {
			collider.gameObject.GetComponent<InteractiveElementScript>().OnPlayerInteract(gameObject);

			// Only allow interacting with one element at a time.
			m_Interacting = false;
		}
	}
		
	public void DisableMovement() {
		m_CanMove = false;
	}

	public void EnableMovement() {
		m_CanMove = true;
	}
}
