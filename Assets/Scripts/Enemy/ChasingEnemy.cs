using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    public float dmgtogive;
    public float speed;
    public float distance;
    public bool movingRight = true;
    public Transform fuckingspelare;
    public float force;
    public Rigidbody2D rb;
    public Transform groundDetection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Health hpscript = collision.gameObject.GetComponent<Health>();
            hpscript.TakeDamage(dmgtogive);

            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.knockbackCount = player.knockbackLength;

            if(collision.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }
            
        }
    }
}
