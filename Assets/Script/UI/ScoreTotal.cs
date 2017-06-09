using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{

    private Text text_;
    private float anim_score_;
    private float score_;

    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
        text_.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //スコアアニメーション更新
        if (anim_score_ < score_)
        {
            anim_score_ += Time.deltaTime * Score.kAddAnimScorePerSeconds;
            if (anim_score_ > score_)
                anim_score_ = score_;
        }
        //描画
        text_.text = "Score:\t" + (int)anim_score_;
    }

    public void Registor(float score)
    {
        score_ += score;
    }
}
