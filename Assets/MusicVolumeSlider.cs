using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;
    public string name;
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = PlayerPrefs.GetFloat(name);
    }

}
