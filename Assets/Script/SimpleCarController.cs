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
    private SpeedMeter speedmeter;       //スピードメーター

    private AudioSource[] se = new AudioSource[(int)EngineSe.None];
    private bool checkse = false;           //エンジン音切り替えフラグ
    private float count;                    //スタートエンジン音終了までのカウント
    private bool brakingflag = false;       //ブレーキフラグ Se用
    private float fwdSpeed;                   //前進速度
    float Breaking = 10000;

    private Rigidbody rb;

    //エンジン効果音
    private enum EngineSe
    {
        Idling,
        Starting,
        Running,
        Braking,
        Damage,
        None
    }
    void Start()
    {
        //se関連
        AudioSource[] audioSources = GetComponents<AudioSource>();
        for (int i = 0; i < (int)EngineSe.None; i++)
            se[i] = audioSources[i];

        //回転方向変更(よく分からなかったのでとりあえず動くように調整)
        FrontLeft.steerAngle = 0;
        FrontRight.steerAngle = 0;
        RearLeft.steerAngle = 0;
        RearRight.steerAngle = 0;

        rb = GetComponent<Rigidbody>();
        speedmeter = transform.Find("/Canvas/SpeedMeter").GetComponent<SpeedMeter>();
    }

    void Update()
    {
        Vector3 rot = GetComponent<Transform>().localRotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, 0);
        GetComponent<Transform>().localRotation = Quaternion.Euler(rot);
        //前方向速度取得
        fwdSpeed = Vector3.Dot(GetComponent<Rigidbody>().velocity, transform.forward);
        speedmeter.ChangeNowSpeed(Mathf.Abs(fwdSpeed));
        //Debug.Log(fwdSpeed);
        if (fwdSpeed > 1 && checkse == true)
        {
            if (count == 0)
            {
                se[(int)EngineSe.Idling].Stop();
                se[(int)EngineSe.Starting].Play();
            }

            count += Time.deltaTime;
            if (count < 4)
                se[(int)EngineSe.Running].Play();
            if (count > 5)
            {
                se[(int)EngineSe.Starting].Stop();

                checkse = false;
                count = 0;
            }

        }
        else if (fwdSpeed <= 1 && checkse == false)
        {
            se[(int)EngineSe.Idling].Play();
            se[(int)EngineSe.Starting].Stop();
            se[(int)EngineSe.Running].Stop();
            checkse = true;
        }


        //重心計算
        // rb.ResetCenterOfMass();
        //   Vector3 mass = rb.centerOfMass;
        // mass.y -= 1;
        //rb.centerOfMass = mass;

        //移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RearRight.motorTorque = RearLeft.motorTorque = Speed;
            brakingflag = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
            RearRight.motorTorque = RearLeft.motorTorque = -Speed;
        else
            RearRight.motorTorque = RearLeft.motorTorque = 0;


        //タイヤの角度変更(なぜかＷＡＳＤでも動いた)
        if (Input.GetKey(KeyCode.RightArrow) && FrontRight.steerAngle < +Maxsteer)
        {
            FrontRight.steerAngle += RotateSpeed;
            FrontLeft.steerAngle += RotateSpeed;

        }

        if (Input.GetKey(KeyCode.LeftArrow) && FrontRight.steerAngle > -Maxsteer)
        {
            FrontRight.steerAngle -= RotateSpeed;
            FrontLeft.steerAngle -= RotateSpeed;


        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            FrontRight.steerAngle = FrontLeft.steerAngle = 0;

        }

        RearLeft.brakeTorque = 0;
        RearRight.brakeTorque = 0;
        //Bを押せばブレーキ。 
        if (Input.GetKey(KeyCode.Space))
        {
            if (!se[(int)EngineSe.Braking].isPlaying && fwdSpeed > 3 && brakingflag)
            {
                se[(int)EngineSe.Braking].Play();
                brakingflag = false;
            }
            // ブレーキをかける値に代入。 
            RearLeft.brakeTorque = Breaking;
            RearRight.brakeTorque = Breaking;
        }

        // se[(int)EngineSe.Braking].Stop();
    }

    public float get_fwdspeed()
    {
        return fwdSpeed;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Stage")|| collider.CompareTag("MovableObj"))
            if (!se[(int)EngineSe.Damage].isPlaying && fwdSpeed > 3)
                se[(int)EngineSe.Damage].Play();

    }
}