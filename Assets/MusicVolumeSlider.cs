using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;
    public string name;

    private MusicManager _musicManager;
    void Start()
    {
        slider = GetComponent<Slider>();
        _musicManager = FindObjectOfType<MusicManager>();

        slider.value = PlayerPrefs.GetFloat(name);
    }

    public void OnChangeMusic()
    {
        _musicManager.SetMusicVolume(slider);
    }
    
    public void OnChangeSoundEffect()
    {
        _musicManager.SetSoundEffectVolume(slider);
    }

}
