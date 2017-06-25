using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    public GameObject catchobjcollider; //キャッチあたり判定
    public float RotateSpeed;


    private bool catching = false; //持ってるかどうか
    private GameObject catchobj; //つかんだオブジェクト
    private GameObject catchobjpos;// 掴む位置用のオブジェクト（透明)
    private GameObject Claw;    //爪（角度計算に使う）
    private GameObject Crane; //クレーン（角度計算に使う)
    private bool MaxRotate; //アームの閉じる限界角度
    private bool MinRotate; //アームの開く限界角度
    private float valArmRotation;
    private float relClawRot;//相対的な詰めの角度
    private AnimatorStateInfo animinfo;//現在のアニメーションの状態
    private AudioSource[] se = new AudioSource[(int)ArmSe.None];


    private bool test;//テスト

    private Animator anim;
    private float defaultSpeed;
    public Collision arm1;
    public Collision arm2;
    public Collision arm3;
    public Collision arm4;
    public GameObject a;

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
        catchobjcollider = GameObject.Find("Sphere");
        catchobjpos = GameObject.Find("CatchPos");
        Claw = GameObject.Find("Claw_Top_R");
        Crane = GameObject.Find("CraneCar");
      /*  if (catchobjpos == null)
            print("NULL");
        else
            print("ok");*/

        anim = GetComponent<Animator>();
        defaultSpeed = anim.speed;
    }

    // Update is called once per frame
    void Update()
    {
        animinfo = anim.GetCurrentAnimatorStateInfo(0);

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

            valArmRotation -= RotateSpeed;
        }
        if (Input.GetKey(KeyCode.X) && !MinRotate)
        {
            valArmRotation += RotateSpeed;

        }

        setObjUpdate();


        if (Input.GetKey(KeyCode.X))//スぺースでアームが開き始める
        {
            anim.SetBool("ArmStart", true);
            test = false;

        }
        else anim.SetBool("ArmStart", false);


        //相対的な爪の角度
        relClawRot = Claw.transform.eulerAngles.y - Crane.transform.eulerAngles.y;

        if (animinfo.fullPathHash == Animator.StringToHash("Base Layer.Idle"))
        {
            anim.SetBool("CatchEnd", false);
        }
        if (test == true)
            anim.SetBool("CatchEnd", true);

      
    }

    void setObjUpdate()
    {
        if (catching)
        {
            anim.speed = 0;//爪は掴んでいる間は停止
            if(test == false)
            catchobj.GetComponent<Transform>().position = catchobjpos.GetComponent<Transform>().position;
            if (Input.GetKeyDown(KeyCode.C))
            {
                test = true;
                anim.SetBool("CatchEnd", true);
                anim.speed =  defaultSpeed;
                se[(int)ArmSe.Down].Play();
                catching = false;
                //for (int i = 0; i < catchobj.transform.childCount; i++)
                //   catchobj.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
                catchobj.GetComponent<BoxCollider>().enabled = true;
                catchobj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
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
      

       // print(anim.GetBool("test"));
        if (/*Input.GetKeyDown(KeyCode.X) &&*/ collider.CompareTag("MovableObj")//一定の角度でのみcatching判定に
            && relClawRot > 160.0
            && relClawRot < 174.5
           // && anim.GetCurrentAnimatorStateInfo(0).IsTag("CLOSE")
            && anim.GetBool("CatchEnd") == false
            && test ==false)
        {
            se[(int)ArmSe.Up].Play();
            catching = true;
            catchobj = collider.gameObject;
            // 子要素を全て取得する
            //あたり判定一時的に無効
            // for (int i = 0; i < catchobj.transform.childCount; i++)
            //    catchobj.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
           catchobj.GetComponent<BoxCollider>().enabled = false;
        }


    }
    void OnTriggerExit(Collider collision)
    {
        anim.speed = defaultSpeed;
        //print("TriggerExit");

    }
    void OnCollisionExit(Collision collision)
    {
        //print("CollisionExit");
        anim.speed = defaultSpeed;

    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手が運ぶものなら処理をする
        if (collision.gameObject.CompareTag("MovableObj"))
        {
            anim.speed = 0;
           // print("hit");
            // 衝突した対象(collisionオブジェクト)の色を変更している。
          //  collision.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        
           
    }
}
