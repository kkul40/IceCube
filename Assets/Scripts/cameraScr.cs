using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScr : MonoBehaviour
{
    public Transform iceCube;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var icePos = iceCube.position;
        icePos.z = -10;
        
        transform.position = icePos;
    }
}
