﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking.Types;

public class SimpleCarController : MonoBehaviour
{
    public float Speed;
    public float Maxsteer;　//タイヤの曲がる限界の角度
    public float RotateSpeed;　//タイヤの曲がる速さ
    public WheelCollider FrontRight; //前輪
    public WheelCollider FrontLeft;
    public WheelCollider RearRight;//後輪
    public WheelCollider RearLeft;
    private AudioSource[] se = new AudioSource[(int)EngineSe.None];
    private bool checkse = false;           //エンジン音切り替えフラグ
    private float count;                    //スタートエンジン音終了までのカウント
    float Breaking = 1000; 

    private Rigidbody rb;

    //エンジン効果音
    private enum EngineSe
    {
        Idling,
        Starting,
        Running,
        None
    }
    void Start()
    {
        //se関連
        AudioSource[] audioSources = GetComponents<AudioSource>();
        for(int i=0;i<(int)EngineSe.None;i++)
         se[i]= audioSources[i];

        //回転方向変更(よく分からなかったのでとりあえず動くように調整)
        FrontLeft.steerAngle = -90;
        FrontRight.steerAngle = -90;
        RearLeft.steerAngle = -90;
        RearRight.steerAngle = -90;

        rb = GetComponent<Rigidbody>();
   
    }

    void Update()
    {
        //前方向速度取得
        var fwdSpeed = Vector3.Dot(GetComponent<Rigidbody>().velocity, -transform.right);
        Debug.Log(fwdSpeed);
     
        if (fwdSpeed > 1&&checkse==true) {
            if (count == 0)
            {
                se[(int)EngineSe.Idling].Stop();
                se[(int)EngineSe.Starting].Play();
            }

            count += Time.deltaTime;
            if(count<4)
                se[(int)EngineSe.Running].Play();
            if (count >5)
            {
                se[(int)EngineSe.Starting].Stop();
          
                checkse = false;
                count = 0;
            }
        
        }
        else if(fwdSpeed <= 1 && checkse ==false)
        {
            se[(int)EngineSe.Idling].Play();
            se[(int)EngineSe.Starting].Stop();
            se[(int)EngineSe.Running].Stop();
            checkse = true;
        }
        //重心計算
        rb.ResetCenterOfMass();
        Vector3 mass = rb.centerOfMass;
        mass.y -= 1;
        rb.centerOfMass = mass;

        //移動
        RearRight.motorTorque = Input.GetAxis("Vertical") * Speed;
        RearLeft.motorTorque = Input.GetAxis("Vertical") * Speed;

        //タイヤの角度変更(なぜかＷＡＳＤでも動いた)
        if (Input.GetKey(KeyCode.RightArrow) && FrontRight.steerAngle < -90 + Maxsteer)
        {
            FrontRight.steerAngle += RotateSpeed;
            FrontLeft.steerAngle += RotateSpeed;

        }

        if (Input.GetKey(KeyCode.LeftArrow) && FrontRight.steerAngle > -90 - Maxsteer)
        {
            FrontRight.steerAngle -= RotateSpeed;
            FrontLeft.steerAngle -= RotateSpeed;

        }
        if(Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            FrontRight.steerAngle = FrontLeft.steerAngle =-90 ;
           
        }

        RearLeft.brakeTorque = 0;
        RearRight.brakeTorque =0;
        //Bを押せばブレーキ。 
        if (Input.GetKey(KeyCode.B))
        {
            // ブレーキをかける値に代入。 
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }


   
      



    }
}