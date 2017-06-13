using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGaugeNow : MonoBehaviour
{

    private RectTransform rect_;
    private float max_width_;

    [SerializeField]
    private float now_fuel_;

    public float Now_fuel_
    {
        get { return now_fuel_; }
        private set { now_fuel_ = value; }
    }

    public float max_fuel_ = 1000.0f;

    // Use this for initialization
    void Start()
    {
        rect_ = GetComponent<RectTransform>();
        max_width_ = rect_.sizeDelta.x;
        now_fuel_ = max_fuel_;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 size = rect_.sizeDelta;
        size.x = max_width_ * (now_fuel_ / max_fuel_);
        rect_.sizeDelta = size;
    }

    public void ChangeNowFuel(float diff)
    {
        now_fuel_ += diff;
        //ラップする
        if (now_fuel_ > max_fuel_)
            now_fuel_ = max_fuel_;
        if (now_fuel_ < 0)
            now_fuel_ = 0;
    }
}
