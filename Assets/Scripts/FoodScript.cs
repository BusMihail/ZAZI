using UnityEngine;

public enum FOOD_TYPE
{
    BOABE,
    OASE,
    PESTE,
    MORCOV,
    IARBA
}

public class FoodScript : MonoBehaviour
{

    public FOOD_TYPE foodType;
    public float moveSpeed = 1f;
    public bool invItem = true;
    public GameObject food;

    bool grabbed = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (grabbed)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
    private void OnMouseDown()
    {
        if (invItem)
            GrabFood();
        else
            Destroy(this.gameObject);
        //grabbed = !grabbed;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invItem)
        {
            MoveAnimal animal = collision.gameObject.GetComponent<MoveAnimal>();
            if (animal != null && gameObject!= null)
            {
                Destroy(gameObject);
                animal.Feed(foodType);
            }   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ColisionStay");
    }

    void GrabFood()
    {
        var a = Instantiate(food);
        
        FoodScript fc = a.GetComponent<FoodScript>();
        fc.gameObject.GetComponent<Rigidbody2D>().mass = 0.0001f;
        fc.grabbed = true;
        fc.invItem = false;

        a.GetComponent<BoxCollider2D>().isTrigger = false;

        var sr = a.GetComponent<SpriteRenderer>();
        sr.sortingOrder = 21;
        a.transform.localScale = food.transform.localScale * 1.1f;
    }
}
