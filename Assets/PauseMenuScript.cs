using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public bool Paused = false;

    public GameObject PausedMenu;
    public GameObject SoundControlPanel;
    private bool _settingsIsShown = false;



    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Resume();
            }
            else if (Paused == false)
            {
                Time.timeScale = 0;
                Paused = true;
                PausedMenu.SetActive(Paused);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Paused = false;
        PausedMenu.SetActive(Paused);
    }

    public void LaunchSettings()
    {
        _settingsIsShown = true;
        SoundControlPanel.SetActive(_settingsIsShown);
        PausedMenu.SetActive(!_settingsIsShown);

    }

    public void QuitSettings()
    {
        _settingsIsShown = false;
        SoundControlPanel.SetActive(_settingsIsShown);
        PausedMenu.SetActive(!_settingsIsShown);

    }
    

    public void QuitAndGoBackHome()
    {
        SceneManager.LoadScene("HomePageScene", LoadSceneMode.Single);

    }
}
