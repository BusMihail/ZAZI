using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectLoop : MonoBehaviour
{
    public float speed_h = 0.01f, speed_v = 0.01f;
    public float distance_v = 5f;
    public float distance_h = 60f;

    public float right_limit = 30f;
    public float left_limit = -30f;

    float start;
    float init;

    float initial_X, initial_Y;

    // Start is called before the first frame update
    void Start()
    {
        speed_h += Random.value * 0.004f - .002f;
        start = transform.position.y;
        init = Random.value * 2 * Mathf.PI;
        initial_X = transform.position.x;
        initial_Y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float aux = Mathf.Sin(init) * distance_v;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(distance_h, start + aux, 0), speed_h);
        init += speed_v;

        if (transform.position.x >= right_limit - 1)
        {
            transform.position = new Vector3(left_limit, initial_Y, 0);
        }
    }
}
