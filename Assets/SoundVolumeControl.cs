using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeControl : MonoBehaviour
{

    public static double MusicSoundLevel = 0.5;
    public static double FxSoundLevel = 0.5;
    public static double AnchorManSoundLevel = 0.5;

    public Slider MusicSoundSlider;
    public Slider FxSoundSlider;
    public Slider AnchorManSoundSlider;


    public void SetMusicSoundLevel()
    {
        MusicSoundLevel = MusicSoundSlider.value;
    }
    public void SetFxSoundLevel()
    {
        FxSoundLevel = FxSoundSlider.value;
    }
    public void SetAnchorManSoundLevel()
    {
        AnchorManSoundLevel = AnchorManSoundSlider.value;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
