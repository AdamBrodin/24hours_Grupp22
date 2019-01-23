using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    private bool onGround;
    // Start is called before the first frame update
    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpHeight);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }
}
