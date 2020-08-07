using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    int growthStage = 0;
    int maxGrowStage = 2;
    Vector3 beginPos;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        beginPos = transform.position + Vector3.up * spriteRenderer.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale += Vector3.one * 0.2f;
            var y = spriteRenderer.bounds.extents.y;
            transform.position = new Vector3(beginPos.x,-5,0) + Vector3.up * y;
        }
    }
}
