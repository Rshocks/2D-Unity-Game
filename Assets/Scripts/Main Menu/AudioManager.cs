using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer MyMixer;

    void Start()
    {
        if(PlayerPrefs.HasKey("MasterVol"))
        {
            MyMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }

        if(PlayerPrefs.HasKey("MusicVol"))
        {
            MyMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }

        if(PlayerPrefs.HasKey("SFXVol"))
        {
            MyMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }
    }
}
