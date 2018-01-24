using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

	public AudioMixer NewMixer;					//Used to hold a reference to the AudioMixer mainMixer

    public void SetMasterLevel(float masterLvl)
    {
        NewMixer.SetFloat("masterVol", masterLvl);
    }

    //Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
    public void SetMusicLevel(float musicLvl)
	{
		NewMixer.SetFloat("musicVol", musicLvl);
	}

	//Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
	public void SetSfxLevel(float SFXLvl)
	{
		NewMixer.SetFloat("SFXVol", SFXLvl);
	}
}
