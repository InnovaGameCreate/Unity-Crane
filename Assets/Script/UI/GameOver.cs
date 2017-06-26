using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private RectTransform rect;
    private bool hasShow = false;

    //ゲームオーバー時いじるもの
    private GameObject goal;

    // Use this for initialization
    void Start()
    {
        rect = GetComponent<RectTransform>();
        goal = GameObject.Find("ゴール");
        //非表示
        rect.anchorMax = new Vector2(1, 0);
        rect.anchorMin = new Vector2(0, -1);
    }

    void Update()
    {
        //未表示&時間切れ
        if (!hasShow && Timer.time_ <= 0)
        {
            Show();//表示

            //オブジェクト削除
            Destroy(goal);
        }
    }

    //表示
    void Show()
    {
        //表示
        rect.anchorMax = new Vector2(1, 1);
        rect.anchorMin = new Vector2(0, 0);
    }

    public void LoadStartScene()
    {
        //スタート画面に戻る
        SceneManager.LoadScene("Start");
    }
}
