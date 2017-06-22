using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    public GameObject RightArm; //アーム下部
    public GameObject LeftArm;
    public GameObject RightArm1; //アーム上部
    public GameObject LeftArm1;
    public GameObject catchobjcollider; //キャッチあたり判定
    public float RotateSpeed;


    private bool catching = false; //持ってるかどうか
    private GameObject catchobj; //つかんだオブジェクト
    private bool MaxRotate; //アームの閉じる限界角度
    private bool MinRotate; //アームの開く限界角度
    private float valArmRotation;
    private AudioSource[] se = new AudioSource[(int)ArmSe.None];
    //エンジン効果音
    private enum ArmSe
    {
        Up,
        Down,
        None
    }

    // Use this for initialization
    void Start()
    {
        //se関連
        AudioSource[] audioSources = GetComponents<AudioSource>();
        for (int i = 0; i < (int)ArmSe.None; i++)
            se[i] = audioSources[i];

        MaxRotate = false;
        MinRotate = false;
        valArmRotation = RightArm.transform.rotation.z;
        catchobjcollider = GameObject.Find("Sphere");

    }

    // Update is called once per frame
    void Update()
    {
        //アームの開閉の限界判定（rotation.zで判定すると揺れでzのrotationが変化するため不規則になる)
        if (valArmRotation <= -20)//ここらへんごり押し
            MaxRotate = true;
        else
            MaxRotate = false;

        if (valArmRotation >= 5)//ここらへんごり押し
            MinRotate = true;
        else
            MinRotate = false;

        //スペースがアーム閉　Cが開
        if (Input.GetKeyDown(KeyCode.C) && !MaxRotate)
        {
        
            RightArm.transform.Rotate(0, 0, -RotateSpeed);
            LeftArm.transform.Rotate(0, 0, RotateSpeed);
            RightArm1.transform.Rotate(0, 0, RotateSpeed);
            LeftArm1.transform.Rotate(0, 0, -RotateSpeed);
            valArmRotation -= RotateSpeed;
        }
        if (Input.GetKey(KeyCode.X) && !MinRotate)
        {

            RightArm.transform.Rotate(0, 0, RotateSpeed);
            LeftArm.transform.Rotate(0, 0, -RotateSpeed);
            RightArm1.transform.Rotate(0, 0, -RotateSpeed);
            LeftArm1.transform.Rotate(0, 0, RotateSpeed);
            valArmRotation += RotateSpeed;

        }

        setObjUpdate();
    }

    void setObjUpdate()
    {
        if (catching)
        {

            catchobj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            if (Input.GetKeyDown(KeyCode.C))
            {
                se[(int)ArmSe.Down].Play();
                catching = false;
                //for (int i = 0; i < catchobj.transform.childCount; i++)
                //   catchobj.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
                catchobj.GetComponent<BoxCollider>().enabled = true;
                catchobj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                catchobj.transform.GetComponentInChildren<LineRenderer>().enabled = true;//yok追加
                catchobj = null;
            }
        }


    }

   public bool get_catching()
    {
        return catching;
    }

    void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.X) && collider.CompareTag("MovableObj"))
        {
            se[(int)ArmSe.Up].Play();
            catching = true;
            catchobj = collider.gameObject;
            // 子要素を全て取得する
            //あたり判定一時的に無効
            // for (int i = 0; i < catchobj.transform.childCount; i++)
            //    catchobj.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            catchobj.GetComponent<BoxCollider>().enabled = false;

            //yok追加
            //箱のビームを消す
            catchobj.transform.GetComponentInChildren<LineRenderer>().enabled = false;
        }


    }


}
