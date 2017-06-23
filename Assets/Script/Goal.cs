﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour {
    private Image clearui;           //クリアUI
    private ArmRotate armrotate;    //クレーンのArmを指定
    private Timer timer;            //タイマーUI
    private float scenechangecount;     //シーン移動までの時間

    private void Start()
    {
        clearui = GameObject.Find("Canvas/クリア").GetComponent<Image>();
        armrotate = GameObject.Find("Craneまとめ/Himo/CreanCar_Claw").GetComponent<ArmRotate>();
        timer = GameObject.Find("Canvas/Timer/Text").GetComponent<Timer>();
    }

    private void Update()
    {
        if (scenechangecount > 5)
            SceneManager.LoadScene("Result");
       else if (scenechangecount > 0)
            scenechangecount += Time.deltaTime;


   
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MovableObj") && !armrotate.get_catching())
        {
            GetComponent<AudioSource>().Play();
            clearui.enabled=true;
            timer.set_stop(true);
            if (scenechangecount ==0)
            scenechangecount = 1;

        }

    }
}
