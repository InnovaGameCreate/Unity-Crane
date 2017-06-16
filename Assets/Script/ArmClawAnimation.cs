using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmClawAnimation : MonoBehaviour
{
    private Animator anim;
    private float defaultSpeed;
    public Collision arm1;
    public Collision arm2;
    public Collision arm3;
    public Collision arm4;
    public GameObject a;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        defaultSpeed = anim.speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.X))//スぺースでアームが開き始める
        {
            anim.SetBool("ArmStart", true);
        }
        else anim.SetBool("ArmStart", false);



    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手が運ぶものなら処理をする
        if (collision.gameObject.CompareTag("MovableObj"))
        {
            anim.speed = 0;

            // 衝突した対象(collisionオブジェクト)の色を変更している。
            //collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
            anim.speed = defaultSpeed;
    }
}

        