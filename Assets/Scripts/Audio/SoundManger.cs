using UnityEngine;
using UnityEngine.Audio;

public class SoundManger : MonoBehaviour
{
    public static SoundManger instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        
        //keep object even when we go on if wish
        /*if ( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance!= this)
            Destroy(gameObject);*/
        
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
