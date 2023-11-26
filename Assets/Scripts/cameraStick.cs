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
        float targetAspect = 16f / 9f; // Hedef ekran oranýný belirtin (örneðin, 16:9)

        // Cihazýn ekran oranýný alýn
        float currentAspect = (float)Screen.width / Screen.height;

        // Hedef ekran oranýna uygun kamera boyutunu hesaplayýn
        float orthographicSize = mainCamera.orthographicSize * (targetAspect / currentAspect);

        // Kameranýn ekran oranýný güncelleyin
        mainCamera.aspect = currentAspect;

        // Kameranýn boyutunu güncelleyin
        mainCamera.orthographicSize = orthographicSize;
    }
}
