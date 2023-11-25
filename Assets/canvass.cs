using UnityEngine;

public class canvass : MonoBehaviour
{
    void Start()
    {
        SetResolution();
    }

    void SetResolution()
    {
        // Cihazýn ekran çözünürlüðünü al
        Resolution currentResolution = Screen.currentResolution;

        // Burada cihazýn çözünürlüðüne uygun þekilde kamera veya Canvas ayarlarýnýzý güncelleyin
        // Örneðin: Camera.main.aspect = (float)currentResolution.width / currentResolution.height;
        // veya CanvasScaler'ýn ayarlarýný güncelleyebilirsiniz.
    }
}
