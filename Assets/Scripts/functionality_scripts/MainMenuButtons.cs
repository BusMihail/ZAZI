using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuButtons : MonoBehaviour
{
    static private List<Button> disabledButtons;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        var button = canvas.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        var buttonExit = canvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
        MainMenuButtons.disabledButtons = new List<Button>
        {
            // buton start
            button,
            buttonExit
        };
        DisableButtons();
    }


    public static void DisableButtons()
    {
        if (disabledButtons != null)
        disabledButtons.ForEach(x => x.interactable = false);
    }
    
    public static void EnableButtons()
    {
        disabledButtons.ForEach(x => x.interactable = true);
    }
}
