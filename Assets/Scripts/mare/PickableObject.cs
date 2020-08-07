using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public float moveSpeed = 1;

    private bool grabbed = false;
    private BoxCollider2D boxcolider;
    public CufarController cc;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.mass = 0.0001f;
        rb.gravityScale = 0;
        boxcolider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseDown()
    {
        grabbed = !grabbed;
        if (grabbed)
        {
            cc.Deschide();
        }
        else
        {
            cc.Inchide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CufarController>() != null)
        {
            cc.Inchide();
            Destroy(this.gameObject);
            GameObject.Find("SoundRaspunsCorect").GetComponent<AudioSource>().Play();
        }
        else
        {
            Physics2D.IgnoreCollision(boxcolider, collision.collider);
        }
    }
}
