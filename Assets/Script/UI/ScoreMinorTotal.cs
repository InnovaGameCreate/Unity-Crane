using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMinorTotal : MonoBehaviour
{

    private Text text_;
    private float anim_score_;
    private float score_;
    private float time_;
    private bool shoud_draw_ = false;

    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
        text_.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //時間カウント
        if (shoud_draw_ && anim_score_ == score_)
        {
            time_ += Time.deltaTime;
        }
        //スコアアニメーション更新
        if (anim_score_ < score_)
        {
            anim_score_ += Time.deltaTime * Score.kAddAnimScorePerSeconds;
            if (anim_score_ > score_)
                anim_score_ = score_;
        }
        //更新時間切れなら表示しない
        if (time_ >= Score.kLifeTime)
        {
            anim_score_ = score_ = time_ = 0.0f;
            text_.text = "";
            shoud_draw_ = false;
        }
        //描画
        if (shoud_draw_)
            text_.text = "+" + (int)anim_score_;
    }

    public void Registor(float score)
    {
        score_ += score;
        time_ = 0.0f;
        shoud_draw_ = true;
    }
}
