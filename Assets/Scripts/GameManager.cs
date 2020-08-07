using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 4f;

    public GameObject canvasButoane;
    public GameObject canvasIesire;
    public GameObject MainPanel;
    public GameObject zazi_map;

    public Texture2D cursorImage;
    private Vector2 hotspot;

    bool gameHasEnded = false;
    private VoiceOverManager voiceOverManager;
    private static AudioSource menuSong;

    public static bool gataAudioEnd = false;

    private void Start()
    {
        voiceOverManager = gameObject.AddComponent<VoiceOverManager>();

        hotspot = new Vector2(cursorImage.width / 2, cursorImage.height / 2);
        Cursor.SetCursor(cursorImage, hotspot, CursorMode.Auto);

        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                menuSong = BGSoundScript.Instance.gameObject.GetComponent<AudioSource>();
                voiceOverManager.VoiceOverMainMenu(menuSong);
                break;
            case "Harta":
                if(menuSong == null)
                    menuSong = BGSoundScript.Instance.gameObject.GetComponent<AudioSource>();
                voiceOverManager.VoiceOverHarta(menuSong);
                break;
            case "Harta2":
                //TODO implementare
                //voiceOverManager.VoiceOverHarta2();
                break;
            case "Tara":
                voiceOverManager.VoiceOverTara();
                break;
            case "Oras":
                voiceOverManager.VoiceOverOras();
                break;
            case "Mare":
                voiceOverManager.VoiceOverMare();
                break;
            case "Munte":
                voiceOverManager.VoiceOverMunte();
                break;

        }
        
    }

    public void FixedUpdate()
    {
        if (gataAudioEnd)
        {
            CloseApp();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeToScene(int SceneToChangeTo)
    {
        if(SceneToChangeTo != 1 && SceneToChangeTo != 6) //daca nu schimbam pe harta
        {
            GameObject music = GameObject.Find("Music");
            Destroy(music);
        }
 
        SceneManager.LoadScene(SceneToChangeTo);
    }

    public void Quit()
    {
        voiceOverManager.VoiceOverGame_EndGame();
        canvasIesire.SetActive(true);

        if (zazi_map != null)
            zazi_map.SetActive(false);

        if (canvasButoane != null)
            canvasButoane.SetActive(false);
    }

    public void CloseApp()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
