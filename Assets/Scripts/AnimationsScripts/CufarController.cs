using UnityEngine;
using UnityEngine.UI;

public class CufarController : MonoBehaviour
{
    public bool TrebuieDeschis = false;
    private Animator animator;
    public static int scor = 0;

    public Text scor_text;
    public Sprite open;
    public Sprite closed;
    public ScriptMare gameManger;


    private Transform objects = null;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        GetComponent<BoxCollider2D>().isTrigger = false;

    }

    void FixedUpdate()
    {
        
        if(objects!=null && objects.childCount == 0)
        {
            MoveToMenu();
        }
        animator.SetBool("TrebuieDeschis", TrebuieDeschis);
        if (TrebuieDeschis)
        {
            sr.sprite = open;
        }
        else
        {
            sr.sprite = closed;
        }
        
    }

    public static void resetareScor()
    {
        scor = 0;
    }

    void MoveToMenu()
    {
        objects = null;
        gameManger.canvasIndicator.SetActive(true);
        gameManger.score.SetActive(false);
        gameManger.mainCamera.transform.position = gameManger.target_position;
    }

    public void Deschide()
    {
        sr.sprite = open;
        TrebuieDeschis = true;
    }

    public void Inchide()
    {
        GetComponent<SpriteRenderer>().sprite = closed;
        TrebuieDeschis = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PickableObject>() != null)
        {
            if(objects == null)
            {
                objects = collision.gameObject.transform.parent;
            }
            scor++;
            scor_text.text = "SCOR : " + scor;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
