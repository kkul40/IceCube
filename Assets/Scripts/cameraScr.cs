using UnityEngine;

public class cameraScr : MonoBehaviour
{
    public Transform iceCube;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void LateUpdate()
    {
        var icePos = iceCube.position;
        icePos.z = -10;

        transform.position = icePos;
    }
}