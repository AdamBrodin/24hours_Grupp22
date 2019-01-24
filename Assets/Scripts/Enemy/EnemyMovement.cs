using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    #region Variables
    public GameObject player; // Player object to follow
    private float distanceToPlayer; // Distance from enemy to player
    public float triggerDistance, timeToWalk, jumpForce; // triggerDistance = max distance for movement to begin, time to walk = speed
    private Vector2 currentVelocity = Vector2.zero;
    private Rigidbody2D rb2d;
    #endregion

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        //transform.right = player.transform.position - transform.position; // Point towards the player

        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position); // Distance between enemy and player

        if(distanceToPlayer < triggerDistance) // If the distance to the player is within specified triggerDistance
        {
            // Move the enemy smoothly towards the player
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref currentVelocity, timeToWalk);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "JumpingObject":
                rb2d.AddForce(Vector2.up * jumpForce);
                break;
        }
    }
}
