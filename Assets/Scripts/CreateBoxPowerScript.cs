using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CreateBoxPowerScript : MonoBehaviour {
	[SerializeField] private string buttonName = "";
	[SerializeField] private string validationButtonName = "";
	[SerializeField] private float cooldown = 1f;
	[SerializeField] private Platformer2DUserControl caster;

	[SerializeField] private float m_MaxDistance = 4f;

	[SerializeField] private GameObject boxModel;
	[SerializeField] private GameObject particlesModel;
	
	[SerializeField] private GameObject radiusModel;
	[SerializeField] private Color radiusColor = new Color(0f, 0.8f, 0f, 1f);

	private float timeLeftBeforeReset = 0f;
	private bool oldButtonState = false;
	
	private GameObject shadowBox = null;
	private GameObject persistentBox = null;
	private GameObject radiusIndication = null;

	//var for the animation of the bullet
	private Animator m_Anim;

	void Reset() {
		oldButtonState = false;

		if (shadowBox) {
			Destroy(shadowBox);
			shadowBox = null;
		}

		ShowRadius(false);

		caster.EnableMovement();

		m_Anim.SetBool("CreateBox", false);
	}


	void SetBoxGravity(bool gravity) {
		persistentBox.GetComponent<Rigidbody2D>().gravityScale = gravity ? 1 : 0;
	}
	
	void MakeBoxFall() {
		if (persistentBox) {
			SetBoxGravity(true);
		}
	}

	void ShowRadius(bool show) {
		radiusIndication.GetComponent<Light>().enabled = show;
	}

	void Start() {
		radiusIndication = Instantiate(radiusModel) as GameObject;
		radiusIndication.transform.SetParent(transform);
		radiusIndication.transform.localPosition = new Vector3(0f, 0f, 0f);
		
		var light = radiusIndication.GetComponent<Light>();
		light.range = m_MaxDistance * 2.5f;
		light.intensity = 0.8f;
		light.color = radiusColor;

		ShowRadius(false);

		m_Anim = GetComponent<Animator>();
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

			m_Anim.SetBool("CreateBox", true);

			caster.DisableMovement();
			ShowRadius(true);

			shadowBox = Instantiate(boxModel) as GameObject;
			shadowBox.AddComponent<ShadowBoxScript>();

			var position = new Vector3(0f, 0f, 0f);

			var facingRight = caster.m_Character.FacingRight();
			
			if (facingRight) {
				position.x = 1f;
			}
			else {
				position.x = -2f;
			}

			shadowBox.transform.position = transform.position + position;

			var shadowBoxScript = shadowBox.GetComponent<ShadowBoxScript>();
			shadowBoxScript.LinkTo(caster.gameObject, m_MaxDistance);
		}
		else if (isReleased) {
			Reset();
		}
		else if (isHold) {
			var validation = Input.GetButton(validationButtonName);
			var shadowBoxScript = shadowBox.GetComponent<ShadowBoxScript>();
			
			if (!validation || !shadowBoxScript.isValid) {
				return;
			}

			if (persistentBox) {
				Destroy(persistentBox);
			}

			var particles = Instantiate(particlesModel, shadowBox.transform.position + shadowBoxScript.GetRelativeCenter(), Quaternion.identity);
			var duration = particles.GetComponent<ParticleSystem>().main.duration;
			
			Destroy(particles, duration);

			persistentBox = Instantiate(boxModel,
									   shadowBox.transform.position,
									   Quaternion.identity) as GameObject;

			SetBoxGravity(false);
			Invoke("MakeBoxFall", 0.75f);
			
			Reset();

			timeLeftBeforeReset = cooldown;
		}
	}
}
