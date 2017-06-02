using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {
    private Image clearui;           //クリアUI
    private ArmRotate armrotate;    //クレーンのArmを指定
    private Timer timer;            //タイマーUI

    private void Start()
    {
        clearui = GameObject.Find("Canvas/クリア").GetComponent<Image>();
        armrotate = GameObject.Find("Craneまとめ/Himo/Arm").GetComponent<ArmRotate>();
        timer = GameObject.Find("Canvas/Timer/Text").GetComponent<Timer>();

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MovableObj") && !armrotate.get_catching())
        {
            clearui.enabled=true;
            timer.set_stop(true);
        }

    }
}
