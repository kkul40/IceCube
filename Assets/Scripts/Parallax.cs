using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startPos;
    public float parallaxEffect;
    private Vector3 lastCameraPos;
    private float textureUnuitSizeX;

    public Camera cam;
    void Start()
    {
        lastCameraPos = cam.transform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texxture = sprite.texture;
        textureUnuitSizeX = texxture.width / sprite.pixelsPerUnit;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, cam.transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cam.transform.position - lastCameraPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, 0);
        lastCameraPos = cam.transform.position;

        if (Mathf.Abs(cam.transform.position.x - transform.position.x) >= textureUnuitSizeX)
        {
            float offsetPosotionX = (cam.transform.position.x - transform.position.x) % textureUnuitSizeX;
            transform.position = new Vector3(cam.transform.position.x + offsetPosotionX, transform.position.y);
        }
    }
}
