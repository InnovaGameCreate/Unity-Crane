using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatusController : MonoBehaviour
{
    private GameObject target;   //運ぶもの
    private GameObject crane;    //クレーン　
    private GameObject fireobj;  //生成した炎obj  
    public GameObject fire;     //炎

    //yok追加
    public float BoxMaxHP;//箱の初期耐久力
    public float BoxNowHP;//箱の耐久力
    private bool OnFire = false;//着火しているかどうか

	// Use this for initialization
	void Start () {
        target = GameObject.Find("運ぶ物");
        crane = GameObject.Find("Craneまとめ/CraneCar");
        BoxNowHP = BoxMaxHP;
	}
	
	// Update is called once per frame
	void Update () {
        if (OnFire)//yok追加
        {
            BoxNowHP -= 10 * Time.deltaTime;//ほんとは攻撃力の変数がいいよね
            Debug.Log("hoge");
            if(BoxNowHP <= 0)
            {
                /*箱のリスポーン処理*/
                OnFire = false;
            }
        }
	}
    //燃える
    public void burn()
    {
        if (GameObject.Find("運ぶ物/炎(Clone)") == null)
        {
            Debug.Log("qwe");
            fireobj = Instantiate(fire, target.transform.position, crane.transform.rotation);
            fireobj.transform.parent = target.transform;
            OnFire = true;//なんか呼ばれてない気がするんですがそれは・・・

        }
    }
}
