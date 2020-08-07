using UnityEngine;
using UnityEngine.UI;

public class ScriptTara : MonoBehaviour
{
    public float speed = 2;
    public GameObject zazi_explicand;
    public Image zazi_explicand_dreapta;
    public Image zazi_explicand_end;
    public Text score;
    public Camera mainCamera;

    public GameObject zazi_hranind_animalele;
    public GameObject canvasPrezentare;
    public GameObject canvasInstructiuni;
    public GameObject canvasInstructiuni2;
    public GameObject canvasEndGame;

    Vector3 target_position;
    bool move = false;

    bool singleRunAfterT1_1 = true;

    bool instructiuniOK = false;
    bool instructiuniOK2 = false;

    public static bool T1_1_gata = false;   //introducere la tara
    public static bool T1_gata = false;   //introducere la tara
    public static bool T2_gata = false;   //insctructiuni la tara
    public static bool T2_gata2 = false;   //insctructiuni2 la tara
    public static bool T3_gata = false;
    public static bool endGame = false;

    private GameManager gameManager;
    private VoiceOverManager voiceOverManager;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        voiceOverManager = gameObject.AddComponent<VoiceOverManager>();

        score.enabled = false;
        zazi_hranind_animalele.SetActive(false);
        canvasInstructiuni.SetActive(false);
        canvasEndGame.SetActive(false);

        target_position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = new Vector3(-18, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("v") && T1_gata)
                move = true;

        if (move == true)
        {
            canvasPrezentare.SetActive(false);
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, target_position, speed * Time.deltaTime);
            zazi_explicand.transform.position = Vector3.MoveTowards(zazi_explicand.transform.position, new Vector3(-35, zazi_explicand.transform.position.y, zazi_explicand.transform.position.z), speed * Time.deltaTime);
        }

        if (mainCamera.transform.position.x == target_position.x && !instructiuniOK)
        {
            instructiuniOK = true;
            StartInstructiuni();
        }

        if(T1_1_gata && singleRunAfterT1_1)
        {
            singleRunAfterT1_1 = false;
            voiceOverManager.VoiceOverTara2();
            canvasPrezentare.SetActive(true);
        }

        if (T2_gata && !instructiuniOK2)
        {
            instructiuniOK2 = true;
            StartInstructiuni2();
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

    public void StartGame()
    {
        MoveAnimal.start = true;
        score.enabled = true;
        zazi_hranind_animalele.SetActive(true);

        canvasInstructiuni.SetActive(false);
        canvasInstructiuni2.SetActive(false);
    }

    public void StartInstructiuni()
    {
        canvasInstructiuni.SetActive(true);
        voiceOverManager.VoiceOverTara_Instructiuni();
    }

    public void StartInstructiuni2()
    {
        canvasInstructiuni.SetActive(false);
        canvasInstructiuni2.SetActive(true);
        voiceOverManager.VoiceOverTara_Instructiuni2();
    }

    public void EndGame()
    {
        score.enabled = false;
        zazi_hranind_animalele.SetActive(false);
        canvasEndGame.SetActive(true);
        voiceOverManager.VoiceOverTara_EndGame();
    }

    public void NextLevel()
    {
        gameManager.ChangeToScene(6);
    }
}
