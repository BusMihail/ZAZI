using UnityEngine;
using UnityEngine.UI;

public class ScriptMare : MonoBehaviour
{
    /// <summary>
    /// Administrare
    /// </summary>
    private GameManager gameManager;
    private VoiceOverManager voiceOverManager;
    public Camera mainCamera;
    public float speed = 2;
    public Vector3 target_position;
    bool moveCamera = false;

    public Button butonMare;
    public Button butonPlaja;

    public static bool vorbesteZazi = false;

    public Transform melci;
    public Transform scoici;
    public Transform perle;
    /// <summary>
    /// Zazi
    /// </summary>
    public GameObject zazi_explicand;
    public Image zazi_explicand_dreapta;
    public Image zazi_explicand_end;
    public GameObject zazi_plaja;
    public GameObject zazi_end;

    public GameObject recompensaSucuriBar;

    /// <summary>
    /// Canvas-uri
    /// </summary>
    public GameObject score;
    public GameObject canvasIntro;
    public GameObject canvasIndicator;
    public GameObject canvasInstructiuni;

    public GameObject canvasPerle;
    public GameObject canvasScoici;
    public GameObject canvasMelci;

    public GameObject canvasEndGame;

    /// <summary>
    /// Vreme
    /// </summary>
    public GameObject mareLinistita;
    public GameObject mareCuValuri;

    bool instructiuniOK = false;
    bool instructiuniOK2 = false;

    public static bool MA1_gata = false;
    public static bool MA2_gata = false;
    public static bool MA2_gata2 = false;
    public static bool melci_gata = false;
    public static bool scoici_gata = false;
    public static bool perle_gata = false;
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
        canvasInstructiuni.SetActive(false);
        canvasEndGame.SetActive(false);
        canvasIndicator.SetActive(false);
        score.SetActive(false);

        canvasIntro.SetActive(true);

        /// <summary>
        /// Mutare camera
        /// </summary>
        target_position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = new Vector3(-18, mainCamera.transform.position.y, mainCamera.transform.position.z);

        MareLinistita();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("v") && MA1_gata)
        {
            moveCamera = true;
            canvasIntro.SetActive(false);
        }

        if (moveCamera)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, target_position, speed * Time.deltaTime);
            zazi_explicand.transform.position = Vector3.MoveTowards(zazi_explicand.transform.position, new Vector3(-35, zazi_explicand.transform.position.y, zazi_explicand.transform.position.z), speed * Time.deltaTime);
        }

        if (mainCamera.transform.position.x == target_position.x && !instructiuniOK)
        {
            instructiuniOK = true;
            moveCamera = false;

            canvasIndicator.SetActive(true);
            dezactiveazaButoane();

            StartInstructiuni();
        }

        if (vorbesteZazi)
        {
            dezactiveazaButoane();
        }
        else
        {
            activeazaButoane();
            scapaDeCanvasuri();
        }

        if(!vorbesteZazi && endGame)
        {
            EndGame();
        }

        if((melci.childCount == 0 && scoici.childCount == 0 && perle.childCount == 0))
        {
            // schimbarea de scena      _________
            //      _____________      /          \
            //     /             \    /  Help     /
            //    / ---       --- \   \ I Need   /
            //   |  \_/ \   / \_/  |   \ help  /
            //   |  o o  \_/    o  |  _/     /
            //    \  o^       ^o o/  <_____/
            //     o\ o  \==/  o/ o       
            //      o \       / o o
            //     o o  \___/    o
            //
            //
            //
            //gameManager.ChangeToScene(6);
        }

        if(scoici.childCount == 0)
        {
            melci.gameObject.SetActive(true);
            scoici.gameObject.SetActive(false);
        }

        if (melci.childCount == 0 && ! melci_gata)
        {
            melci_gata = true;
            vorbesteZazi = true;
            voiceOverManager.VoiceOverMare_MelciGata();
            canvasMelci.SetActive(true);
        }

        if (scoici.childCount == 0 && !scoici_gata)
        {
            scoici_gata = true;
            vorbesteZazi = true;
            voiceOverManager.VoiceOverMare_ScoiciGata();
            MareLinistita();
            canvasScoici.SetActive(true);
        }

        if (perle.childCount == 0 && !perle_gata)
        {
            perle_gata = true;
            vorbesteZazi = true;
            voiceOverManager.VoiceOverMare_PerleGata();
            canvasPerle.SetActive(true);
        }

        if(melci_gata && perle_gata && scoici_gata && !endGame)
        {
            endGame = true;
            zazi_explicand_end.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_end.rectTransform.localPosition, new Vector3(zazi_explicand_end.rectTransform.localPosition.x, -49, zazi_explicand_end.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);

            recompensaSucuriBar.SetActive(true);
            zazi_plaja.SetActive(false);
        }

        if (instructiuniOK)
        {
            zazi_explicand_dreapta.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_dreapta.rectTransform.localPosition, new Vector3(270f, zazi_explicand_dreapta.rectTransform.localPosition.y, zazi_explicand_dreapta.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);
        }

        if (MA2_gata && !instructiuniOK2)
        {
            instructiuniOK2 = true;

            canvasInstructiuni.SetActive(false);
            zazi_plaja.SetActive(true);

            vorbesteZazi = true;
            voiceOverManager.VoiceOverMare_Instructiuni2();
        }

        if (MA2_gata2)
        {

        }

        if (endGame)
        {
            zazi_explicand_end.rectTransform.localPosition = Vector3.MoveTowards(zazi_explicand_end.rectTransform.localPosition, new Vector3(zazi_explicand_end.rectTransform.localPosition.x, -49, zazi_explicand_end.rectTransform.localPosition.z), speed * 80 * Time.deltaTime);
        }

    }

    public void MareLinistita()
    {
        mareLinistita.SetActive(true);
        mareCuValuri.SetActive(false);
    }

    public void MareCuValuri()
    {
        mareLinistita.SetActive(false);
        mareCuValuri.SetActive(true);
    }

    public void StartGame()
    {
        MoveAnimal.start = true;
        canvasInstructiuni.SetActive(false);
    }

    public void StartInstructiuni()
    {
        canvasInstructiuni.SetActive(true);

        vorbesteZazi = true;
        voiceOverManager.VoiceOverMare_Instructiuni();
    }

    public void EndGame()
    {
        vorbesteZazi = true;

        canvasIndicator.SetActive(false);
        zazi_end.SetActive(true);

        voiceOverManager.VoiceOverMare_EndGame();

        //canvasEndGame.SetActive(true);
    }

    public void scapaDeCanvasuri()
    {
        canvasMelci.SetActive(false);
        canvasScoici.SetActive(false);
        canvasPerle.SetActive(false);
    }

    public void InMarePerle()
    {
        if (perle.childCount != 0)
        {
            if (mareCuValuri.activeSelf)
            {
                Debug.Log("Nu putem intra in apa");
                vorbesteZazi = true;
                voiceOverManager.VoiceOverMare_MareValuri();
            }
            else
            {
                canvasIndicator.SetActive(false);
                mainCamera.transform.position = new Vector3(-18, 16, mainCamera.transform.position.z);
                CufarController.resetareScor();
                score.SetActive(true);
                score.GetComponent<Text>().text = "SCOR : 0";
            }
        }
        else
        {
            Debug.Log("Am adunat toate perlele");
            vorbesteZazi = true;
            voiceOverManager.VoiceOverMare_CerereMarePerleGata();
        }
    }

    public void PePlajaMelciScoici()
    {
        if (melci.childCount != 0 || scoici.childCount != 0)
        {
            score.SetActive(true);
            canvasIndicator.SetActive(false);
            mainCamera.transform.position = new Vector3(10, 14, mainCamera.transform.position.z);
            CufarController.resetareScor();
            score.GetComponent<Text>().text = "SCOR : 0";
        }
        else
        {
            vorbesteZazi = true;
            voiceOverManager.VoiceOverMare_UltimaSolutieMarea();
        }
    }

    public void PePlaja()
    {
        mainCamera.transform.position = new Vector3(0, 0, mainCamera.transform.position.z);
    }

    public void dezactiveazaButoane()
    {
        butonMare.interactable = false;
        butonPlaja.interactable = false;
    }

    public void activeazaButoane()
    {
        butonMare.interactable = true;
        butonPlaja.interactable = true;
    }

    public void NextLevel()
    {
        gameManager.ChangeToScene(6);
    }
}
