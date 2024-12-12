using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float player_speed;
    public float jump_force;
    public LayerMask layer;
    public Transform transfotm;
    public GameObject panel;
    public GameObject stopPanel;
    public Score scoreScr;
    public AudioSource coinSound;

    public bool is_game_over = false;
    public bool stop = false;

    private float fall_multi = 11f;
    private float deb = 0.1f;
    private int jump_count = 0;
    private float speed_deb = 0;

    void Start()
    {
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (is_game_over == false && stop == false)
        {
            Collider2D isGrounded = Physics2D.OverlapCircle(transfotm.position, 0.05f, layer);
            transform.position = Vector3.right * player_speed * Time.fixedDeltaTime + transform.position;
            deb += Time.fixedDeltaTime;
            speed_deb += Time.fixedDeltaTime;

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

            if (speed_deb > 10 && player_speed < 7)
            {
                player_speed += 0.2f;
                speed_deb = 0;
            }

        }
    }

    public void GameOver()
    {
        if (is_game_over == false)
        {
            is_game_over = true;
            anim.SetTrigger("death");
            panel.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("DownDetector"))
        {
            GameOver();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            scoreScr.score += 3;
            scoreScr.score_text.text = scoreScr.score.ToString();

            Destroy(collision.gameObject);
        }
    }

    public void StopButton()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            stopPanel.SetActive(true);
        } else
        {
            Time.timeScale = 1f;
            stopPanel.SetActive(false);
        }
    }
}
