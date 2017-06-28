using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObejct : MonoBehaviour
{

    private TargetStatus status;

    //運ぶ物のプレファブ
    [SerializeField]
    private GameObject hako_prefab;

    //運ぶ物の初期位置
    Vector3 ini_position;         

    // Use this for initialization
    void Start()
    {
        status = GetComponent<TargetStatus>();
        ini_position = transform.position;//初期位置記録

        //respawn時設定用
        BoxGaugeNow.now_box_ = 100;//ゲージを再登録
        GetComponentInChildren<LineRenderer>().enabled = true;//ビーコン表示
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //地下に潜ったときor耐久値0のとき
        if (transform.position.y < -50 || status.Hp <= 0)
        {
            Instantiate(hako_prefab, ini_position, Quaternion.identity);//箱再度生成
            Destroy(gameObject);//箱削除
        }
    }
}
