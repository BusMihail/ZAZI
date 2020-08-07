using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public Type type1;
    public Type type2;
    public int itemsRemaining = 5;
    public PolygonCollider2D cldr;

    public string culoareCos;

    private VoiceOverManager voiceOverManager;

    public static int itemsRemainingAll = 15;

    // Start is called before the first frame update
    void Start()
    {
        cldr = GetComponent<PolygonCollider2D>();
        voiceOverManager = gameObject.AddComponent<VoiceOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var component = collision.gameObject.GetComponent<FollowMouse>();

        if (collision.gameObject.tag == "trash")
        {
            if (component.type == type1 || component.type == type2)
            {
                //RECYCLE
                Destroy(collision.gameObject);
      
                GameObject.Find("TrashRecycled").GetComponent<AudioSource>().Play();

                itemsRemaining--;
                itemsRemainingAll--;

                if (itemsRemainingAll == 0)
                {
                    GameManager gameManager = FindObjectOfType<GameManager>();
                    ScriptOras scriptOras = gameManager.GetComponent<ScriptOras>();
                    scriptOras.EndGame();
                }

                if (culoareCos == "green" && itemsRemaining == 1)
                    voiceOverManager.VoiceOverOras_2_4();
                if (culoareCos == "yellow" && itemsRemaining == 2)
                    voiceOverManager.VoiceOverOras_2_5();
                if (culoareCos == "blue" && itemsRemaining == 3)
                    voiceOverManager.VoiceOverOras_2_6();
            }
            else
            {
                if (ScriptOras.singleRunIndiciu)
                {
                    ScriptOras.singleRunIndiciu = false;

                    if (component.type == Type.glass)
                        voiceOverManager.VoiceOverOras_Indiciu1();
                    if (component.type == Type.paper || component.type == Type.carton)
                        voiceOverManager.VoiceOverOras_Indiciu2();
                    if (component.type == Type.metal || component.type == Type.plastic)
                        voiceOverManager.VoiceOverOras_Indiciu3();
                }

                //THROW AWAY
                component.grabbed = false;
                var body = collision.gameObject.GetComponent<Rigidbody2D>();
                body.velocity = new Vector2(Random.Range(-3f, 3f), Random.Range(6f, 8.5f));
                GameObject.Find("TrashBounce").GetComponent<AudioSource>().Play();
            }
        }
        
    }
}
