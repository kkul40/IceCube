using UnityEngine;

public class cameraStick : MonoBehaviour
{
    void Start()
    {
        AdjustCameraToScreen();
    }

    void AdjustCameraToScreen()
    {
        Camera mainCamera = Camera.main;
        float targetAspect = 16f / 9f; // Hedef ekran oran�n� belirtin (�rne�in, 16:9)

        // Cihaz�n ekran oran�n� al�n
        float currentAspect = (float)Screen.width / Screen.height;

        // Hedef ekran oran�na uygun kamera boyutunu hesaplay�n
        float orthographicSize = mainCamera.orthographicSize * (targetAspect / currentAspect);

        // Kameran�n ekran oran�n� g�ncelleyin
        mainCamera.aspect = currentAspect;

        // Kameran�n boyutunu g�ncelleyin
        mainCamera.orthographicSize = orthographicSize;
    }
}
