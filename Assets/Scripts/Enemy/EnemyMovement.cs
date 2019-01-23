using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player; // Player object to follow

    private float distanceToPlayer; // Distance from enemy to player
    public float triggerDistance = 5f, timeToWalk = 5f; // triggerDistance = max distance for movement to begin, time to walk = speed

    private Vector2 currentVelocity = Vector2.zero;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.LookAt(player.transform); // Point towards the player

        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position); // Distance between enemy and player

        if(distanceToPlayer < triggerDistance) // If the distance to the player is within specified triggerDistance
        {
            // Move the enemy smoothly towards the player
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref currentVelocity, timeToWalk);
        }
    }
}
