using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeterPointer : MonoBehaviour
{

    private RawImage raw_image_;
    private float now_speed_;

    private const float kMinRotate = 120.0f;
    private const float kMaxRotate = -120.0f;
    private const float kMinSpeed = 0.0f;
    private const float kMaxSpeed = 130.0f;

    // Use this for initialization
    void Start()
    {
        raw_image_ = GetComponent<RawImage>();
        now_speed_ = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion to_rotation = Quaternion.Euler(0.0f, 0.0f, (((now_speed_ - kMinSpeed) / kMaxSpeed) * (kMaxRotate - kMinRotate)) + kMinRotate);
        raw_image_.rectTransform.rotation = Quaternion.Slerp(raw_image_.rectTransform.rotation, to_rotation, Time.deltaTime * 3.0f);
    }

    public void ChangeNowSpeed(float speed)
    {
        now_speed_ = speed;
        if (now_speed_ > kMaxSpeed)
            now_speed_ = kMaxSpeed;
        else if (now_speed_ < kMinSpeed)
            now_speed_ = kMinSpeed;
    }
}
