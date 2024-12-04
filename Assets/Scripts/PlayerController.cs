using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    public float jumpForce;
    private float fallMulti = 7f;
    private float jumpMulti = 3f;
    private int jumpCount;
    private bool canJump = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.right * playerSpeed * Time.fixedDeltaTime + transform.position;

        if (Input.GetMouseButton(0))
        {
            rb.velocity = Vector3.up * jumpForce;
        }
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.down * fallMulti);
        } else if (rb.velocity.y > 0)
        {
            rb.AddForce(Vector3.up * jumpMulti);
        }
    }
}
