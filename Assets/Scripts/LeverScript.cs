using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : InteractiveElementScript {
	[SerializeField] public Vector3 restRotation = new Vector3(0f, 0f, 45f);
	[SerializeField] public Vector3 activeRotation = new Vector3(0f, 0f, -45f);

	private Vector3 defaultRotation;

	private void Awake() {
		defaultRotation = transform.eulerAngles;
	}
	
	override public void OnPlayerInteract(GameObject player) {
		isActivated = ! isActivated;
	}

	public void FixedUpdate() {
		transform.eulerAngles = defaultRotation + (isActivated ? activeRotation : restRotation);
	}
}
