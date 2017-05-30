using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time_ = 180.0f;//180秒に設定
    private Text text_;
    private int minute;
    private int second;
<<<<<<< HEAD
    private bool stop;  //ゴールなどした際カウントを止める
=======
>>>>>>> 3492851a250a340db1ec231ee25615632125268f

    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (!stop)
            time_ -= Time.deltaTime;
=======
        time_ -= Time.deltaTime;
>>>>>>> 3492851a250a340db1ec231ee25615632125268f
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

<<<<<<< HEAD
    public void set_stop(bool set)
    {
        stop = set;
    }

=======
>>>>>>> 3492851a250a340db1ec231ee25615632125268f
    void TimeToMinute()
    {
        minute = (int)time_ / 60;
        second = (int)time_ % 60;
    }
}
