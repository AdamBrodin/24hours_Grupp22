using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool knockFromRight;
    public float knockbackLength;
    public float knockbackCount;
    public float knockbackX;
    public float knockbackY;

    public float speed;
    public float jumpforce;
    private float moveinput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundcheck;
    public float CheckRadius;
    public LayerMask Whatisground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, CheckRadius, Whatisground);

        moveinput = Input.GetAxis("Horizontal");
        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-knockbackX, knockbackY);
            }
            if (!knockFromRight)
            {
                rb.velocity = new Vector2(knockbackX, knockbackY);
            }
            knockbackCount -= Time.deltaTime;
        }

        if (facingRight == false && moveinput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveinput < 0)
        {
            flip();
        }


    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
