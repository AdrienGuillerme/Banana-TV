using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enable the display of bubbleOject on colloide and display text on the bubble
public class dislayBubble : MonoBehaviour {

	public GameObject bubbleObject;
	public GameObject textUI;
	public string bubbleText;

	private bool playerLeaveZone = false;
	public float timer; 

	// check if the bubble should be enable 
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "CharacterRobotBoy") {
			bubbleObject.SetActive(true);
			timer =Time.time;
			textUI.GetComponent<UnityEngine.UI.Text> ().text = bubbleText;
		}
	}
	// check if the bubble should be disable 
	void OnCollisionExit2D(Collision2D collisionInfo) {
		if (collisionInfo.gameObject.name == "CharacterRobotBoy") {
			playerLeaveZone = true;
		}	
	}

	void Update() {
		// wait at least 0.5s to disable the bubble display 
		if (playerLeaveZone) {
			float deltaTime = Time.time - timer;
			if (deltaTime > 0.5) {
				bubbleObject.SetActive(false);
				playerLeaveZone = false;
			}
		}
	}
}
