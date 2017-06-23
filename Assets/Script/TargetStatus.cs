using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStatus : MonoBehaviour
{
    private float basescale;            //目標の運ぶもののサイズ
    private Status boxstatus = Status.None;         //運ぶものの遷移状態
    private GameObject crane;    //クレーンオブジェクト
    private int size;           //箱サイズ
    private ArmRotate arm;        //armいんすたんす
    private GameObject fireobj;  //生成した炎obj  
    public GameObject fire;     //炎
    private AudioSource[] se = new AudioSource[2];
    private int hp = 100;       //耐久値
    private int nexthp = -1;         //減った後の耐久値
    private const int firedamage = 10;    //炎で減る耐久値の量
    private bool decreasehp;        //hpが減るかどうか
    private float burncount;    //燃えるかどうか補正
    private BoxGaugeNow box;            //箱ゲージインスタンス
    enum Status
    {
        Heavier,
        Lighter,
        None
    }
    // Use this for initialization
    void Start()
    {
        crane = GameObject.Find("Craneまとめ/CraneCar");
        arm = GameObject.Find("Craneまとめ/Himo/CreanCar_Claw").GetComponent<ArmRotate>();

        //se関連
        AudioSource[] audioSources = GetComponents<AudioSource>();
        for (int i = 0; i < 2; i++)
            se[i] = audioSources[i];
        box = GameObject.Find("/Canvas/Boxhp/BoxGaugeNow").GetComponent<BoxGaugeNow>();
    }

    //箱の耐久値を減らす
    public void damageset(int damage)
    {
        box.ChangeNowBox(-damage);
        //if (!decreasehp) {
        //    nexthp = hp - damage;
        //    decreasehp = true;
        //} else
        //    nexthp = nexthp - damage;

        //if (nexthp < 0)
        //    nexthp = 0;
      
    }
    private void decreaseHp()
    {
        if (decreasehp&&nexthp < hp)
            hp--;
        else if (nexthp == hp)
            decreasehp = false;
 
    }
    // Update is called once per frame
    void Update()
    {
        if (burncount > 0)
            burncount -= Time.deltaTime;
       // decreaseHp();

        Debug.Log(hp);
        switch (boxstatus)
        {
            case Status.Heavier:
                if (transform.localScale.x < basescale)
                    transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
                else
                    boxstatus = Status.None;
                break;
            case Status.Lighter:
                if (transform.localScale.x > basescale)
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                else
                    boxstatus = Status.None;

                break;
        }
        if (!arm.get_catching())
            crane.GetComponent<SimpleCarController>().Speed = 9000;
        else
        {
            switch (size)
            {
                case -1:
                    crane.GetComponent<SimpleCarController>().Speed = 8000;
                    break;
                case 0:
                    crane.GetComponent<SimpleCarController>().Speed = 7000;
                    break;
                case 1:
                    crane.GetComponent<SimpleCarController>().Speed = 6000;
                    break;

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
 


        if (other.CompareTag("Heavier"))
        {
            se[0].Play();
            basescale = transform.localScale.x * 2;
            Destroy(other.gameObject);
            if (size < 1)
            {
                boxstatus = Status.Heavier;
                size++;
            }
        }
        else if (other.CompareTag("Lighter"))
        {
            se[1].Play();
            basescale = transform.localScale.x / 2;
            Destroy(other.gameObject);
            if (size > -1)
            {
                boxstatus = Status.Lighter;
                size--;
            }
        }

    }
    //燃える
    public void burn()
    {
        if (burncount <= 0&&GameObject.Find("運ぶ物/炎(Clone)") == null)
        {
            fireobj = Instantiate(fire, transform.position, crane.transform.rotation);
            fireobj.transform.parent = transform;
                burncount = 3;
            //引数の3倍のダメージ
            damageset(15);
        }
    }
}
