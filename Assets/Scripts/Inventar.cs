using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public static bool show = false;
    private void Awake()
    {
        //SetVisibleItems(false);
    }
    public void SetVisibleItems(bool visibility)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var s = transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = visibility;
        }
    }
}
