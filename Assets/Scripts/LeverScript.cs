using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : InteractiveElementScript {
	[SerializeField] public Vector3 restRotation = new Vector3(0f, 0f, 45f);
	[SerializeField] public Vector3 activeRotation = new Vector3(0f, 0f, -45f);

	private Animator leverAnim;

	private void Awake() {
		leverAnim = GetComponent<Animator>();
		leverAnim.SetBool("playAnim", false);
	}
	
	override public void OnPlayerInteract(GameObject player) {
		isActivated = ! isActivated;
		leverAnim.SetBool("playAnim", true);
	}

	public void FixedUpdate() {
		leverAnim.SetBool("playAnim", false);
	}
}
