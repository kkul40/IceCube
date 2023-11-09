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
        if (instance == null)
            instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("isMusicOn") == 0) audioSource.mute = true;
        else if (PlayerPrefs.GetInt("isMusicOn") == 1) audioSource.mute = false;
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
        if (audioSource.mute) PlayerPrefs.SetInt("isMusicOn", 0);
        else PlayerPrefs.SetInt("isMusicOn", 1);
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
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }
    
    public void SetSoundEffectVolume(Slider slider)
    {
        oneShot.volume = slider.value;
        PlayerPrefs.SetFloat("SoundEffectVolume", slider.value);
    }
}
