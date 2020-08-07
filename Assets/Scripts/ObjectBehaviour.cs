using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectBehaviour : MonoBehaviour
{
    public Type type = Type.glass;
    public Camera cam;

    private bool grabbed = false;
    private Collider2D colider;
    private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        colider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (!grabbed)
        {
            rigidbody.gravityScale = .0f;
        }
        else
        {
            rigidbody.gravityScale = 1f;
        }
        grabbed = !grabbed;
    }
    public void Throw()
    {
        float v = rigidbody.velocity.magnitude;
        rigidbody.velocity = Vector2.zero;
        
        float deg = Random.value * 60;
        deg -= 30;
        Vector2 a = Quaternion.Euler(0, 0, deg) * Vector2.up;
        Debug.Log(a);
        a = a.normalized * ((Random.value) / 10 + 4f);
        rigidbody.AddForce(a,ForceMode2D.Force);
        rigidbody.AddTorque(Random.value * (a.magnitude / 25), ForceMode2D.Force);   
        
    }
    private void FixedUpdate()
    {
        if (grabbed)
        {
            var mp = Input.mousePosition;
            // translate
            mp -= new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
            // scale
            mp /= 64;
            transform.position = mp;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }
    }
}
public enum Type
{
    glass = 0,
    paper,
    carton,
    plastic,
    metal,
}