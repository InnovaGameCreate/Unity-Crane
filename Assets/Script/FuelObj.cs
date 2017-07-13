﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelObj : MonoBehaviour {
    private bool flag;          //スコア獲得フラグ
    public int scorepoint = 250;  //得られる燃料
    private FuelGaugeNow fuel;            //燃料インスタンス
    private AudioSource se;
    void Start () {
        fuel = GameObject.Find("/Canvas/Fuel/FuelGaugeNow").GetComponent<FuelGaugeNow>();
        se = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 1, 0);

        if (flag && se.isPlaying == false)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            if (!flag)
            {
                fuel.ChangeNowFuel(scorepoint);
                se.Play();
                flag = true;
                transform.Find("Jerry Can Green").gameObject.SetActive(false);

            }

        }
    }
}
