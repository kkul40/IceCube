using Unity.VisualScripting;

public class SoundEffectVolumeSlider : VolumeSlider
{
    protected override void Start()
    {
        base.Start();
        slider.value = SaveManager.instance.allGameDataHolder.SoundEffectVolume;
    }
    public override void OnValueChanged()
    {
        _musicManager.SetSoundEffectVolume(slider);
    }
}