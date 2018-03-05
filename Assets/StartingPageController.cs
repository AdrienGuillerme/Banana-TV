using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;

public class StartingPageController : MonoBehaviour {

    public GameObject SettingsMenuGameObject; // Assign in inspector
    public GameObject StartMenuGameObject; // Assign in inspector   
    private bool _settingsIsShown = false;

    void Start () {
        _settingsIsShown = false;
        SettingsMenuGameObject.SetActive(_settingsIsShown);
        StartMenuGameObject.SetActive(!_settingsIsShown);
    }
	
	void Update () {
		
	}

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
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
