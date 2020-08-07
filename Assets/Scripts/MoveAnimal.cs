using UnityEngine;
using UnityEngine.UI;

public class MoveAnimal : MonoBehaviour
{
    public float speed_h = 0.1f;
    public FOOD_TYPE food = FOOD_TYPE.IARBA;
    public int food_count = 1;

    Vector3 target_position;
    bool is_feed = false;
    bool canmove = true;
    Vector3 pos;
    public Spawner spawner = null;

    public GameObject[] bule;
    int index = 0;

    //animalele nu vin spre locul unde vor fi hranite decat dupa ce camera a ajuns in locul respectiv
    public static bool start = false;
    public Text score; //plus
    public static int total_animale_hranite = 0;
    public static int raspunsuri_ok_consecutive = 0;
    public static int raspunsuri_gresite_consecutive = 0;

    private VoiceOverManager voiceOverManager;

    void Start()
    {
        voiceOverManager = gameObject.AddComponent<VoiceOverManager>();
        target_position = new Vector3(0, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MoveAnimal>() != null)
        {
            canmove = false;
            pos = transform.position;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MoveAnimal>() != null)
            canmove = true;
    }
    private void OnDestroy()
    {
        if(spawner != null)
        {
            spawner.DecCount();
        }
    }
    
    void FixedUpdate()
    {
        if (start == true)
        {
            if (canmove || is_feed)
                transform.position = Vector3.MoveTowards(transform.position, target_position, speed_h);

            if (!canmove && !is_feed)
            {
                transform.position = pos;
            }
            if (is_feed)
                target_position = new Vector3(-40, transform.position.y);
            if (transform.position.x < -39)
            {
                Destroy(gameObject);
            }
        }

    }

    public void Feed(FOOD_TYPE food)
    {
        if (!is_feed)
            if (transform.position.x <= 0.2)
            {
                // the food is not corect
                if(food != this.food)
                {
                    raspunsuri_ok_consecutive = 0;
                    raspunsuri_gresite_consecutive++;

                    if(raspunsuri_gresite_consecutive == 2)
                    {
                        voiceOverManager.VoiceOver_RandomRaspunsGresit();
                    }
                    else
                    if (raspunsuri_gresite_consecutive == 3)
                    {
                        switch (this.food)
                        {
                            case FOOD_TYPE.OASE:
                                voiceOverManager.VoiceOverTara_Indiciu("1");
                                break;
                            case FOOD_TYPE.IARBA:
                                voiceOverManager.VoiceOverTara_Indiciu("2");
                                break;
                            case FOOD_TYPE.MORCOV:
                                voiceOverManager.VoiceOverTara_Indiciu("3");
                                break;
                            case FOOD_TYPE.BOABE:
                                voiceOverManager.VoiceOverTara_Indiciu("4");
                                break;
                            case FOOD_TYPE.PESTE:
                                voiceOverManager.VoiceOverTara_Indiciu("5");
                                break;
                        }
                        raspunsuri_gresite_consecutive = 0;
                    }
                }
                //the food is corect
                if (food == this.food && food_count > 0)
                {
                    GameObject.Find("SoundRaspunsCorect").GetComponent<AudioSource>().Play();

                    food_count--;
                    Destroy(bule[index]);
                    index++;
                    raspunsuri_gresite_consecutive = 0;

                    raspunsuri_ok_consecutive++;
                    if(raspunsuri_ok_consecutive == 8)
                    {
                        voiceOverManager.VoiceOver_RandomRaspunsCorect();
                        raspunsuri_ok_consecutive = 0;
                    }
                }
                // animal is feed
                if (food_count == 0 || index >= bule.Length)
                {
                    is_feed = true;
                    int curent_score = int.Parse(score.text.Split(':')[1]);
                    score.text = "SCOR : " + (curent_score + 1);

                    total_animale_hranite++;
                    if(total_animale_hranite == 40)
                    {
                        GameManager gameManager = FindObjectOfType<GameManager>();
                        ScriptTara scriptTara = gameManager.GetComponent<ScriptTara>();
                        scriptTara.EndGame();
                    }
                }
            }
    }


}
