using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeterText : MonoBehaviour
{

    private Text text_;
    private float now_speed_;


    // Use this for initialization
    void Start()
    {
        text_ = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        text_.text = Mathf.Floor(now_speed_).ToString() + " km/h";
    }

    public void ChangeNowSpeed(float speed)
    {
        now_speed_ = speed;
    }
}
