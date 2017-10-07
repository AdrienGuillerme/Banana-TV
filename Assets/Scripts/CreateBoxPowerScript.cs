using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CreateBoxPowerScript : MonoBehaviour {
	[SerializeField] private string buttonName = "";
	[SerializeField] private string validationButtonName = "";
	[SerializeField] private float cooldown = 1f;
	[SerializeField] private Platformer2DUserControl caster;

	[SerializeField] private GameObject boxModel;

	private float timeLeftBeforeReset = 0f;
	private bool oldButtonState = false;
	private GameObject shadowBox = null;
	private GameObject persistenBox = null;

	void Reset() {
		oldButtonState = false;

		if (shadowBox) {
			Destroy(shadowBox);
			shadowBox = null;
		}
		caster.EnableMovement();
	}

	// Update is called once per frame
	void Update () {
		if (timeLeftBeforeReset > 0)
			timeLeftBeforeReset -= Time.deltaTime;

		if (timeLeftBeforeReset < 0)
			timeLeftBeforeReset = 0;
		
		if (timeLeftBeforeReset != 0)
			return;

		var button = Input.GetButton(buttonName);

		var doNotCare = !oldButtonState && !button;		
		var isHold = oldButtonState && button;
		var isReleased = oldButtonState && !button;
		var isPressed = !oldButtonState && button;

		oldButtonState = button;

		if (doNotCare) {
			return;
		}

		if (isPressed) {
			caster.DisableMovement();

			shadowBox = Instantiate(boxModel) as GameObject;
			shadowBox.transform.SetParent(this.transform);
			shadowBox.GetComponent<SpriteRenderer>().color = new Color(0f, 0.5f, 0f, 0.5f);
			shadowBox.GetComponent<Rigidbody2D>().isKinematic = true;

			// TODO: Disable collisions!

			var position = new Vector3(0f, 0f, 0f);

			var facingRight = caster.GetComponent<PlatformerCharacter2D>().FacingRight();
			
			if (facingRight) {
				position.x = 1f;
			}
			else {
				position.x = 2f;
			}

			Debug.Log(position);
			
			shadowBox.transform.localPosition = position;

			// TODO: Transfer movement to box
		}
		else if (isReleased) {
			Reset();
		}
		else if (isHold) {
			var validation = Input.GetButton(validationButtonName);

			if (!validation) {
				return;
			}

			if (persistenBox) {
				Destroy(persistenBox);
			}
			
			persistenBox = Instantiate(boxModel,
									   shadowBox.transform.position,
									   Quaternion.identity) as GameObject;
			
			Reset();

			timeLeftBeforeReset = cooldown;
		}
	}
}
