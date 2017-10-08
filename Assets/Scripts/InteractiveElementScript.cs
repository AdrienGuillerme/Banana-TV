using System;
using UnityEngine;

abstract public class InteractiveElementScript : MonoBehaviour
{
	[SerializeField] public bool isActivated;
	
	abstract public void OnPlayerInteract(GameObject player);
}
