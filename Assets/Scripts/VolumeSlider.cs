using UnityEngine;
using UnityEngine.UI;

public abstract class VolumeSlider : MonoBehaviour
{
    protected Slider slider;
    protected MusicManager _musicManager;

    protected virtual void Start()
    {
        slider = GetComponent<Slider>();
        _musicManager = FindObjectOfType<MusicManager>();
    }

    public virtual void OnValueChanged()
    {
        
    }
}