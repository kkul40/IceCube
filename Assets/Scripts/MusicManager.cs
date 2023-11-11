using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource oneShot;
    public static MusicManager instance;

    private void Awake()
    {
        if (instance != null && instance != this) 
            Destroy(this.gameObject); 
        else 
            instance = this; 
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        audioSource.mute = SaveManager.instance.allGameDataHolder.isMuted;
        audioSource.volume = SaveManager.instance.allGameDataHolder.MusicVolume;
        oneShot.volume = SaveManager.instance.allGameDataHolder.SoundEffectVolume;
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
        SaveManager.instance.allGameDataHolder.isMuted = audioSource.mute;
    }

    public void PlayAudio(AudioClip sound)
    {
        oneShot.PlayOneShot(sound);
    }

    public IEnumerator LowerSound()
    {
        float velocity = 0f;
        while (audioSource.volume > 0.001f)
        {
            audioSource.volume = Mathf.SmoothDamp(audioSource.volume, 0, ref velocity, 0.5f);
            yield return new WaitForEndOfFrame();
        }
    }

    public void SetMusicVolume(Slider slider)
    {
        audioSource.volume = slider.value;
        SaveManager.instance.allGameDataHolder.MusicVolume = slider.value;
    }
    
    public void SetSoundEffectVolume(Slider slider)
    {
        oneShot.volume = slider.value;
        SaveManager.instance.allGameDataHolder.SoundEffectVolume = slider.value;
    }
}
