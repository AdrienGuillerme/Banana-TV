using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Everything that be in an active or inactive state.
public class ActivableElementScript : MonoBehaviour {
	protected bool isActive;

	public bool Active() {
		return isActive;
	}
}
