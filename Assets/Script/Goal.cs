using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
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

=======

public class Goal : MonoBehaviour {
    public ArmRotate armrotate;         //クレーンのArmを指定
    public GameObject clearui;           //クリアUI

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MovableObj") && !armrotate.get_catching())
            clearui.SetActive(true);

>>>>>>> 3492851a250a340db1ec231ee25615632125268f
    }
}
