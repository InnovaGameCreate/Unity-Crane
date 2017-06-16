using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{

    private Text text_;
    private int frame_count_;
    private float prev_time_;

    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
        frame_count_ = 0;
        prev_time_ = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ++frame_count_;
        float time = Time.realtimeSinceStartup - prev_time_;
        if (time >= 0.5f)
        {
            text_.text = (frame_count_ / time).ToString("N2");
            frame_count_ = 0;
            prev_time_ = Time.realtimeSinceStartup;
        }
    }
}
