using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMaxRank : MonoBehaviour
{

    [SerializeField]
    private StartSceneManeger.Stage stage;

    //ランク画像
    [SerializeField]
    private GameObject s_rank_image;
    [SerializeField]
    private GameObject a_rank_image;
    [SerializeField]
    private GameObject b_rank_image;
    [SerializeField]
    private GameObject c_rank_image;

    //生成したランク画像
    private GameObject max_rank_image = null;

    // Use this for initialization
    void Start()
    {
        int max_rank = PlayerPrefs.GetInt("" + stage, 0);//最大ランクを取得
        //画像生成
        switch (max_rank)
        {
            case 'S':
                max_rank_image = Instantiate(s_rank_image, transform.position, Quaternion.identity);
                break;
            case 'A':
                max_rank_image = Instantiate(a_rank_image, transform.position, Quaternion.identity);
                break;
            case 'B':
                max_rank_image = Instantiate(b_rank_image, transform.position, Quaternion.identity);
                break;
            case 'C':
                max_rank_image = Instantiate(c_rank_image, transform.position, Quaternion.identity);
                break;
        }

        //画像は自分の子要素とする
        max_rank_image.transform.parent = transform;
        //位置調節
        max_rank_image.GetComponent<RectTransform>().Translate(70, -70, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
