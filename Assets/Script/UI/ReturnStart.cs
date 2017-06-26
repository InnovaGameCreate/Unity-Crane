using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStart : MonoBehaviour
{

    private RectTransform rect;
    private bool is_drawing;

    void ShowPanel()
    {
        //表示
        is_drawing = true;
        rect.anchorMax = new Vector2(1, 1);
        rect.anchorMin = new Vector2(0, 0);
    }

    public void HidePanel()
    {
        //非表示
        is_drawing = false;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (is_drawing)
                HidePanel();
            else
                ShowPanel();
        }
    }

    public void LoadStartScene()
    {
        //スタート画面に戻る
        SceneManager.LoadScene("Start");
    }
}
