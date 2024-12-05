using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float player_speed;
    public float jump_force;
    public LayerMask layer;
    public Transform transfotm;

    private float fall_multi = 11f;
    private float deb = 0.1f;
    private int jump_count = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D isGrounded = Physics2D.OverlapCircle(transfotm.position, 0.05f, layer);
        transform.position = Vector3.right * player_speed * Time.fixedDeltaTime + transform.position;
        deb += Time.fixedDeltaTime;

        if (isGrounded)
            jump_count = 0;

        if (deb > 0.17f && (isGrounded || jump_count == 1 || jump_count == 0))
        {
            if ((Input.touchCount > 0 || Input.GetMouseButton(0)))
            {
                anim.SetTrigger("jump");
                deb = 0;
                jump_count += 1;
                rb.velocity = Vector3.up * jump_force;
            }
        }

        if (rb.velocity.y < 0)
            rb.AddForce(Vector3.down * fall_multi);
    }
}
