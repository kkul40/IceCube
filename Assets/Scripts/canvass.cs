using UnityEngine;

public class canvass : MonoBehaviour
{
    void Start()
    {
        SetResolution();
    }

    void SetResolution()
    {
        // Cihaz�n ekran ��z�n�rl���n� al
        Resolution currentResolution = Screen.currentResolution;

        // Burada cihaz�n ��z�n�rl���ne uygun �ekilde kamera veya Canvas ayarlar�n�z� g�ncelleyin
        // �rne�in: Camera.main.aspect = (float)currentResolution.width / currentResolution.height;
        // veya CanvasScaler'�n ayarlar�n� g�ncelleyebilirsiniz.
    }
}
