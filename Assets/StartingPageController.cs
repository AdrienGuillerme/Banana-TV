using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;

public class StartingPageController : MonoBehaviour {

    public GameObject SettingsMenuGameObject; // Assign in inspector
    public GameObject StartMenuGameObject; // Assign in inspector   
    private bool _settingsIsShown = false;



    // Use this for initialization
    void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

    }
    public void LaunchSettings()
    {
        _settingsIsShown = true;
        SettingsMenuGameObject.SetActive(_settingsIsShown);
        StartMenuGameObject.SetActive(!_settingsIsShown);

    }

    public void QuitSettings()
    {
        _settingsIsShown = false;
        SettingsMenuGameObject.SetActive(_settingsIsShown);
        StartMenuGameObject.SetActive(!_settingsIsShown);

    }
}
