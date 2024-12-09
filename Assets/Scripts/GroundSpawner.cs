using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] grounds;
    public PlayerController Controller;


    public void SpawnGround()
    {
        int rand_pos = Random.Range(8, 43);
        int rand_ground = Random.Range(0, grounds.Length);
        Instantiate(grounds[rand_ground], new Vector3(transform.position.x + 3, -(float)rand_pos/10, 0), Quaternion.identity);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Controller.is_game_over)
            return;

        if (collision.gameObject.CompareTag("Ground"))
            SpawnGround();
    }
}
