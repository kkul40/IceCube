using Unity.VisualScripting;

public class MusicVolumeSlider : VolumeSlider
{
    protected override void Start()
    {
        base.Start();
        slider.value = SaveManager.instance.allGameDataHolder.MusicVolume;
    }

    public override void OnValueChanged()
    {
        _musicManager.SetMusicVolume(slider);
    }
}