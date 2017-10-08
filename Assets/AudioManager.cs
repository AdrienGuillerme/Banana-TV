using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    AudioSource playback;
    AudioClip menuTheme;
    AudioClip level2Theme;

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        playback = this.GetComponent<AudioSource>();
        menuTheme = Resources.Load<AudioClip>("Audio/menu_theme");
        level2Theme = Resources.Load<AudioClip>("Audio/level2_theme");
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    // Update is called once per frame
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "HomePageScene")
        {
            playback.clip = menuTheme;
            playback.Play();
        }
        if (scene.name == "Main")
        {
            playback.clip = level2Theme;
            playback.Play();
        }
        if (scene.name == "Intro")
        {
            playback.Stop();
        }
    }
}
