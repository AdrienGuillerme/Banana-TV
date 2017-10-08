using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{

    public Slider GravityImpactSlider;
	// Use this for initialization
	void Start () {
	    SettingsConstants.GravityImpact = GravityImpactSlider.value * 5;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetGravityImpact()
    {
        SettingsConstants.GravityImpact = GravityImpactSlider.value * 5;
    }
}
