using UnityEngine;
using UnityEngine.UI;

public class ScriptOras : MonoBehaviour
{
    /// <summary>
    /// Administrare
    /// </summary>
    private GameManager gameManager;
    private VoiceOverManager voiceOverManager;
    public Camera mainCamera;
    public float speed = 2;
    Vector3 target_position;
    bool moveCamera = false;

    /// <summary>
    /// Zazi
    /// </summary>
    public GameObject zazi_explicand;
    public Image zazi_explicand_dreapta;
    public GameObject zazi_mirat;
    public GameObject taxi;
    public GameObject zazi_recicland;
    public Image zazi_explicand_end;

    public GameObject semafor_verde;
    public GameObject semafor_rosu;

    /// <summary>
    /// Canvas-uri
    /// </summary>
    public GameObject score;
    public GameObject canvasPrezentare;
    public GameObject canvasInstructiuni;
    public GameObject canvasEndGame;
    public GameObject gunoaie;


    bool instructiuniOK = false;
    bool singleRunAfterOR1_1 = true;
    bool singleRunAfterOR1_2 = true;

    public static bool singleRunIndiciu = true;

    public static bool OR1_1_gata = false;
    public static bool OR1_2_gata = false;
    public static bool OR1_3_gata = false;
    public static bool OR2_gata = false;

    public static bool endGame = false;

    void Start()
    {
        /// <summary>
        /// Instantieri
        /// </summary>
        gameManager = FindObjectOfType<GameManager>();
        voiceOverManager = gameObject.AddComponent<VoiceOverManager>();

        /// <summary>
        /// Dezactivare canvas-uri
        /// </summary>
        score.SetActive(false);
        canvasInstructiuni.SetActive(false);
        canvasEndGame.SetActive(false);
        gunoaie.SetActive(false);
        //zazi_recicland.SetActive(false);

        /// <summary>
        /// Mutare camera
        /// </summary>
        target_position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = new Vector3(-19, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    int count = 100;

    void FixedUpdate()
    {
        if(count-- < 0)
        {
            MakeSemaforVerde();
        }
        else
        {
            MakeSemaforRosu();
        }
        if (count < -100)
            count = 100;

        if (Input.GetKeyDown("v") && OR1_3_gata)
            moveCamera = true;

        if (moveCamera)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, target_position, speed * Time.deltaTime);
            zazi_mirat.transform.position = Vector3.MoveTowards(zazi_mirat.transform.position, new Vector3(zazi_mirat.transform.position.x, -11, zazi_mirat.transform.position.z), speed * 2 * Time.deltaTime);
            taxi.transform.position = Vector3.MoveTowards(taxi.transform.position, new Vector3(13, taxi.transform.position.y, taxi.transform.position.z), speed * 2.5f * Time.deltaTime);
        }

        if (mainCamera.transform.position.x == target_position.x && !instructiuniOK)
        {
            instructiuniOK = true;
            StartInstructiuni();
            StartGame();
        }

        if(OR1_1_gata && singleRunAfterOR1_1)
        {
            singleRunAfterOR1_1 = false;
            canvasPrezentare.SetActive(true);
            voiceOverManager.VoiceOverOras2();
        }

        if (OR1_2_gata && singleRunAfterOR1_2)
        {
            singleRunAfterOR1_2 = false;
            canvasPrezentare.SetActive(false);
            zazi_explicand.SetActive(false);
            zazi_mirat.SetActive(true);
            voiceOverManager.VoiceOverOras3();
        }

        if (OR2_gata)
        {
            canvasInstructiuni.SetActive(false);
        }

        if (instructiuniOK)
        {
            zazi_explicand_dreapta.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_dreapta.rectTransform.localPosition, new Vector3(203f, zazi_explicand_dreapta.rectTransform.localPosition.y, zazi_explicand_dreapta.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);
        }

        if (endGame)
        {
            zazi_explicand_end.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_end.rectTransform.localPosition, new Vector3(zazi_explicand_end.rectTransform.localPosition.x, -49, zazi_explicand_end.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);
        }

    }

    public void MakeSemaforRosu()
    {
        semafor_rosu.SetActive(true);
        semafor_verde.SetActive(false);
    }

    public void MakeSemaforVerde()
    {
        semafor_rosu.SetActive(false);
        semafor_verde.SetActive(true);
    }

    public void StartGame()
    {
        score.SetActive(true);
        gunoaie.SetActive(true);
        zazi_recicland.SetActive(true);
    }

    public void StartInstructiuni()
    {
        canvasInstructiuni.SetActive(true);
        voiceOverManager.VoiceOverOras_Instructiuni();
    }

    public void EndGame()
    {
        endGame = true;

        score.SetActive(false);
        gunoaie.SetActive(false);
        zazi_recicland.SetActive(false);

        canvasEndGame.SetActive(true);
        voiceOverManager.VoiceOverOras_EndGame();
    }

    public void NextLevel()
    {
        gameManager.ChangeToScene(6);
    }
}
