using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    public float speed; // Speed of camera movement
    public Vector3 offset; // Offset from centered camera position

    private Vector3 targetPos, smoothPos;

    private void LateUpdate()
    {
        targetPos = player.transform.position + offset;

        smoothPos = Vector3.Lerp(transform.position, targetPos, speed); 

        transform.position = smoothPos;
    }
}
