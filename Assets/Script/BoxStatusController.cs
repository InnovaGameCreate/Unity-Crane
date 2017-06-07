using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatusController : MonoBehaviour
{
    private GameObject target;   //運ぶもの
    private GameObject crane;    //クレーン　
    private GameObject fireobj;  //生成した炎obj  
    public GameObject fire;     //炎
	// Use this for initialization
	void Start () {
        target = GameObject.Find("運ぶ物");
        crane = GameObject.Find("Craneまとめ/CraneCar");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //燃える
    public void burn()
    {
        if (GameObject.Find("運ぶ物/炎(Clone)") == null)
        {
            fireobj = Instantiate(fire, target.transform.position, crane.transform.rotation);
            fireobj.transform.parent = target.transform;
        }
    }
}
