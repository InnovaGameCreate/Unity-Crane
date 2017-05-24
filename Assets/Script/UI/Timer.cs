﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time_ = 180.0f;//180秒に設定
    private Text text_;
    private int minute;
    private int second;

    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time_ -= Time.deltaTime;
        if (time_ > 0)
        {
            TimeToMinute();
            text_.text = minute + "分" + second + "秒";
        }
        else
        {
            text_.text = "終了";
        }
    }

    void TimeToMinute()
    {
        minute = (int)time_ / 60;
        second = (int)time_ % 60;
    }
}