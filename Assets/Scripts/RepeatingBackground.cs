using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public GameObject cam;
    public float paralax;
    private float width, positionX;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionX = transform.position.x;
    }

    void FixedUpdate()
    {
        float paralax_distance = cam.transform.position.x * paralax;
        float remaining_distance = cam.transform.position.x * (1 - paralax);

        transform.position = new Vector3(positionX + paralax_distance, transform.position.y, transform.position.z);

        if (remaining_distance > positionX + width)
        {
            positionX += width;
        }
    }
}
