using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public AudioSource grindSound;

    public Vector3 position1;
    public Vector3 position2;

    public float speed = 3f;

    private bool first = true;
    private float move_threashold = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        grindSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        if (first)
        {
            direction = position1 - transform.position;
        }
        else
        {
            direction = position2 - transform.position;

        }

        if (direction.magnitude <= move_threashold )
        {
            first = !first;
        }
        else
        {
            direction.Normalize();
            transform.position = transform.position + direction * speed * Time.deltaTime;
        }

    }
}
