using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomThunder : MonoBehaviour
{
    public GameObject thunder;  //カミナリオブジェクト
    private GameObject light;   //ライトオブジェクト
    private GameObject crane;   //クレーンオブジェクト
    private const float lighttime = 5;      //雷落ちるまでの時間
    private float count;
    private float thunderwiderange = 5;        //カミナリ発生横範囲
    private float thunderforwardrange = 10;        //カミナリ発生奥行範囲
    private float lum = 1.0f;   //明るさ
    private bool startthunder =false;     //かみなり発生開始かどうか

    // Use this for initialization
    void Start()
    {
        crane = GameObject.Find("Craneまとめ/CraneCar");
        light = GameObject.Find("Directional Light");

    }

    // Update is called once per frame
    void Update()
    {


        if (startthunder)
        {
            count += Time.deltaTime;

            if (count > lighttime)
            {
                light.GetComponent<Light>().intensity = 0;
                count = 0;
                appearThunder();
            }
            else if (count > 1)
            {
                light.GetComponent<Light>().intensity = 1;
            }
        }
        else
           if( Random.Range(0 , 5)>3)
            startthunder=true;

    }

   public void set_startthunder(bool set)
    {
        startthunder = set;
    }
    //カミナリ発生
    void appearThunder()
    {
        Vector3 pos = crane.GetComponent<Transform>().position + crane.GetComponent<Transform>().forward * 50;
        Vector2 randrange = new Vector2(Random.RandomRange(-thunderwiderange, thunderwiderange), Random.RandomRange(-thunderforwardrange, thunderforwardrange));
        Vector3 edit = new Vector3(pos.x+ randrange.x+2, pos.y+10, pos.z+ randrange.y);
      
        edit = new Vector3(pos.x + randrange.x, pos.y + 28, pos.z + randrange.y);
        Instantiate(thunder,edit , Quaternion.Euler(new Vector3(90,0,0)));
    }
}
