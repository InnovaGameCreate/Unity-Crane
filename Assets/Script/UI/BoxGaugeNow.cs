using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxGaugeNow : MonoBehaviour
{

    private RectTransform rect_;
    private float max_width_;
    public static float now_box_ { get; set; }
    float pre_box_;

    public float max_box_ = 100.0f;

    // Use this for initialization
    void Start()
    {
        rect_ = GetComponent<RectTransform>();
        max_width_ = rect_.sizeDelta.x;
        pre_box_=now_box_ = max_box_;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 size = rect_.sizeDelta;
        size.x = max_width_ * (pre_box_ / max_box_);
        if (now_box_ < pre_box_)
            pre_box_ -= 0.1f;
        rect_.sizeDelta = size;
    }

    public void ChangeNowBox(float diff)
    {
        now_box_ += diff;
        //ラップする
        if (now_box_ > max_box_)
            now_box_ = max_box_;
        if (now_box_ < 0)
            now_box_ = 0;
    }
}
