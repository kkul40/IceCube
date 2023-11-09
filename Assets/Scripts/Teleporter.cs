using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleportationPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out PlayerControl playerControl))
        {
            playerControl.transform.position = TeleportationPoint.position;
        }   
    }
}
