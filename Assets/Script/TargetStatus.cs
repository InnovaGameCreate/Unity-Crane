using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStatus : MonoBehaviour
{
    private float basescale;            //目標の運ぶもののサイズ
    private Status boxstatus = Status.None;         //運ぶものの遷移状態
    private GameObject crane;    //クレーンオブジェクト
    private int size;           //箱サイズ
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
    }

    // Update is called once per frame
    void Update()
    {
        switch (boxstatus)
        {
            case Status.Heavier:
                if (transform.localScale.x < basescale )
                    transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
                else 
                    boxstatus = Status.None;
                break;
            case Status.Lighter:
                if (transform.localScale.x > basescale )
                    transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
                else 
                    boxstatus = Status.None;

                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heavier"))
        {
            basescale = transform.localScale.x * 2;
            Destroy(other.gameObject);
            if (size<1)
            {
                boxstatus = Status.Heavier;
                size++;
            }
        }
        else if (other.CompareTag("Lighter"))
        {
            basescale = transform.localScale.x / 2;
            Destroy(other.gameObject);
            if (size > -1)
            {
                boxstatus = Status.Lighter;
                size--;
            }
        }

        if (other.CompareTag("Heavier")|| other.CompareTag("Lighter"))
        {
            switch (size)
            {
                case -1:
                    crane.GetComponent<SimpleCarController>().Speed = 12000;
                    break;
                case 0:
                    crane.GetComponent<SimpleCarController>().Speed = 9000;
                    break;
                case 1:
                    crane.GetComponent<SimpleCarController>().Speed = 6000;
                    break;

            }
        }
    }
}
