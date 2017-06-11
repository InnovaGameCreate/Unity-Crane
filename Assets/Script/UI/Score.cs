using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private struct ScoreItem
    {
        public float score_ { get; set; }
        public float anim_score_ { get; set; }
        public float time_ { get; set; }//score_==anim_score_になってからの経過時間
        public ScoreTag tag_ { get; set; }
    }

    public enum ScoreTag
    {
        kEnemyKill
    }

    public const float kLifeTime = 3.0f;//更新切れ秒数
    public const float kAddAnimScorePerSeconds = 100.0f;//スコアアニメーションの秒間レート

    private Text text_;
    private ScoreMinorTotal minor_total_;
    private ScoreTotal total_;
    List<ScoreItem> items_ = new List<ScoreItem>();

    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
        minor_total_ = GameObject.Find("Canvas/ScoreMinorTotal").GetComponent<ScoreMinorTotal>();
        total_ = GameObject.Find("Canvas/ScoreTotal").GetComponent<ScoreTotal>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreItem item;
        for (int i = 0; i < items_.Count; i++)
        {
            //時間をカウント
            if (items_[i].anim_score_ == items_[i].score_)
            {
                item = items_[i];
                item.time_ += Time.deltaTime;
                items_[i] = item;
            }
            //寿命切れアイテムを削除
            if (items_[i].time_ >= kLifeTime)
            {
                items_.RemoveAt(i);
                continue;
            }
            //スコアアニメーション更新
            if (items_[i].anim_score_ < items_[i].score_)
            {
                item = items_[i];
                item.anim_score_ += Time.deltaTime * kAddAnimScorePerSeconds;
                if (item.anim_score_ > item.score_)
                    item.anim_score_ = item.score_;         //ラップ
                items_[i] = item;
            }
        }
        //描画更新
        text_.text = "";
        foreach (var i in items_)
        {
            text_.text += i.tag_ + "\t" + ((int)i.anim_score_).ToString();
            text_.text += "\n";
        }
    }

    public void Registor(ScoreTag tag, float score)
    {
        ScoreItem item;

        //スコア小計に登録
        minor_total_.Registor(score);
        //スコア合計に登録
        total_.Registor(score);

        //最後の要素が同じタグのとき同アイテムに追加
        if (items_.Count > 0 && items_[items_.Count - 1].tag_ == tag)
        {
            item = items_[items_.Count - 1];
            item.time_ = 0.0f;//時間リセット
            item.score_ += score;
            items_[items_.Count - 1] = item;
            return;
        }
        //同じでないときは最後に追加
        item = new ScoreItem()
        {
            tag_ = tag,
            score_ = score
        };
        items_.Add(item);
    }
}