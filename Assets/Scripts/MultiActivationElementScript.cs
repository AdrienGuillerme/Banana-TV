using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiActivationElementScript : ActivableElementScript {
	[SerializeField] public GameObject[] activatedObjects;

	public void Update() {
		isActive = true;
		
		foreach (GameObject obj in activatedObjects) {
			var interactiveObject = obj.GetComponent<InteractiveElementScript>();

			if (!interactiveObject.isActivated) {
				isActive = false;
				break;
			}
		}
	}
}
