using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HartaButtons : MonoBehaviour
{
    static private List<Button> disabledButtons;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        var buttons = canvas.transform.GetChild(0).GetComponentsInChildren<Button>();
        disabledButtons = new List<Button>(buttons);
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
