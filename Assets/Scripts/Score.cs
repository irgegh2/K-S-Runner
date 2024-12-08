using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TMP_Text score_text;
    public TMP_Text high_score_text;

    void Start()
    {
        score = 0;
        Debug.Log("365");
        high_score_text.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().is_game_over)
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log(PlayerPrefs.GetInt("HighScore"));
                high_score_text.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            score += 1;
            score_text.text = score.ToString();
        }
    }
}
