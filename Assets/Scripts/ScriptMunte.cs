using UnityEngine;
using UnityEngine.UI;

public class ScriptMunte : MonoBehaviour
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
    public GameObject zazi_plantand;
    public Image zazi_explicand_dreapta;
    public Image zazi_explicand_end;

    /// <summary>
    /// Canvas-uri
    /// </summary>
    public Text score;
    public GameObject canvasInstructiuni;
    public GameObject canvasInstructiuniPropozitii;
    public GameObject canvasEndGame;


    bool instructiuniOK = false;
    bool instructiuniPropozitiiOk = false;

    public static bool MU1_gata = false;
    public static bool MU2_gata = false; 
    public static bool MU2_gata2 = false;
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
        score.enabled = false;
        canvasInstructiuni.SetActive(false);
        canvasEndGame.SetActive(false);

        /// <summary>
        /// Mutare camera
        /// </summary>
        target_position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = new Vector3(-18, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("v") && MU1_gata)
            moveCamera = true;

        if (moveCamera)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, target_position, speed * Time.deltaTime);
            zazi_explicand.transform.position = Vector3.MoveTowards(zazi_explicand.transform.position, new Vector3(-35, zazi_explicand.transform.position.y, zazi_explicand.transform.position.z), speed * Time.deltaTime);
        }

        if (mainCamera.transform.position.x == target_position.x && !instructiuniOK)
        {
            instructiuniOK = true;
            StartInstructiuni();
        }

        if (instructiuniOK)
        {
            zazi_explicand_dreapta.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_dreapta.rectTransform.localPosition, new Vector3(203f, zazi_explicand_dreapta.rectTransform.localPosition.y, zazi_explicand_dreapta.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);
        }

        if(MU2_gata && !instructiuniPropozitiiOk)
        {
            instructiuniPropozitiiOk = true;
            StartInstructiuniPropozitii();
        }

        if (MU2_gata2 && !endGame)
        {
            endGame = true;
            EndGame();
        }

        if (endGame)
        {
            zazi_explicand_end.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_end.rectTransform.localPosition, new Vector3(zazi_explicand_end.rectTransform.localPosition.x, -49, zazi_explicand_end.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);
        }

    }

    public void StartInstructiuni()
    {
        canvasInstructiuni.SetActive(true);
        voiceOverManager.VoiceOverMunte_Instructiuni();
    }

    public void StartInstructiuniPropozitii()
    {
        canvasInstructiuni.SetActive(false);
        zazi_plantand.SetActive(false);

        canvasInstructiuniPropozitii.SetActive(true);
        voiceOverManager.VoiceOverMunte_InstructiuniPropozitii();
    }

    public void EndGame()
    {
        canvasInstructiuniPropozitii.SetActive(false);
        canvasEndGame.SetActive(true);
        voiceOverManager.VoiceOverMunte_EndGame();
    }

    public void NextLevel()
    {
        gameManager.ChangeToScene(6);
    }
}
