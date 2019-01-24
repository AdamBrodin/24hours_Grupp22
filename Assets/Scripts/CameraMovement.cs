using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public float speed; // Speed of camera movement
    public Vector3 offset; // Offset from centered camera position
    private Vector3 targetPos, smoothPos;
    #endregion

    private void LateUpdate()
    {
        targetPos = player.transform.position + offset; // Calculate offset

        smoothPos = Vector3.Lerp(transform.position, targetPos, speed);  // Lerp together current pos and target pos with x speed

        transform.position = smoothPos; // Change position
    }
}
