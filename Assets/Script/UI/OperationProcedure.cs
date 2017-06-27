using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationProcedure : MonoBehaviour
{
    private RectTransform rect;

    void ShowPanel()
    {
        //表示
        rect.anchorMax = new Vector2(1, 1);
        rect.anchorMin = new Vector2(0, 0);
    }

    public void HidePanel()
    {
        //非表示
        rect.anchorMax = new Vector2(1, 0);
        rect.anchorMin = new Vector2(0, -1);
    }

    // Use this for initialization
    void Start()
    {
        rect = GetComponent<RectTransform>();
        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowPanel();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            HidePanel();
        }
    }
}
