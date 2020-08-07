using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Type type;
    private Rigidbody2D rb;
    private PolygonCollider2D cldr;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cldr = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    void FixedUpdate()
    {
        if (grabbed)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        else
            rb.gravityScale = 1;
    }

    private void OnMouseDown()
    {
        grabbed = !grabbed;
    }
}
