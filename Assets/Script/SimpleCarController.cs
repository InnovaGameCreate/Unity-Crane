using UnityEngine;
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
    float Breaking = 1000;

    private Rigidbody rb;

    void Start()
    {
        //回転方向変更(よく分からなかったのでとりあえず動くように調整)
        FrontLeft.steerAngle = -90;
        FrontRight.steerAngle = -90;
        RearLeft.steerAngle = -90;
        RearRight.steerAngle = -90;

        rb = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
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
        // SPACEを押せばブレーキ。 
        if (Input.GetKey(KeyCode.Space))
        {
            // ブレーキをかける値に代入。 
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }


   
      



    }
}