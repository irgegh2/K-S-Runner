using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] grounds;
    public bool has_ground = true;

    void Update()
    {
        if (!has_ground)
        {
            SpawnGround();
            has_ground = true;
        }
    }

    public void SpawnGround()
    {
        int rand_pos = Random.Range(8, 43);
        int rand_ground = Random.Range(0, grounds.Length);
        Instantiate(grounds[rand_ground], new Vector3(transform.position.x + 3, -(float)rand_pos/10, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            has_ground = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            has_ground = false;
    }
}
