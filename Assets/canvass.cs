using UnityEngine;

public class canvass : MonoBehaviour
{
    void Start()
    {
        SetResolution();
    }

    void SetResolution()
    {
        // Cihazın ekran çözünürlüğünü al
        Resolution currentResolution = Screen.currentResolution;

        // Burada cihazın çözünürlüğüne uygun şekilde kamera veya Canvas ayarlarınızı güncelleyin
        // Örneğin: Camera.main.aspect = (float)currentResolution.width / currentResolution.height;
        // veya CanvasScaler'ın ayarlarını güncelleyebilirsiniz.
    }
}
