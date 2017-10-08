using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class SoundVolumeControl : MonoBehaviour
    {


        public Slider MusicSoundSlider;
        public Slider FxSoundSlider;
        public Slider AnchorManSoundSlider;


        public void SetMusicSoundLevel()
        {
            SettingsConstants.MusicSoundLevel = MusicSoundSlider.value;
        }
        public void SetFxSoundLevel()
        {
            SettingsConstants.FxSoundLevel = FxSoundSlider.value;
        }
        public void SetAnchorManSoundLevel()
        {
            SettingsConstants.AnchorManSoundLevel = AnchorManSoundSlider.value;
        }
        // Use this for initialization
        void Start () {
            MusicSoundSlider.value = SettingsConstants.MusicSoundLevel;
            FxSoundSlider.value = SettingsConstants.FxSoundLevel;
            AnchorManSoundSlider.value = SettingsConstants.AnchorManSoundLevel;
    }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
