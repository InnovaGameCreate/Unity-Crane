using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{

    private SpeedMeterPointer pointer_;
    private SpeedMeterText text_;

    [SerializeField]
    private float now_speed_;

    // Use this for initialization
    void Start()
    {
        pointer_ = transform.Find("Pointer").GetComponent<SpeedMeterPointer>();
        text_ = transform.Find("Text").GetComponent<SpeedMeterText>();
        now_speed_ = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        now_speed_ += Time.deltaTime;
        pointer_.ChangeNowSpeed(now_speed_);
        text_.ChangeNowSpeed(now_speed_);
    }

    public void ChangeNowSpeed(float speed)
    {
        now_speed_ = speed;
    }
}
