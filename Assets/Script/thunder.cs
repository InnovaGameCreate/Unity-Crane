using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder : MonoBehaviour {
    private const int disappeartime=8;  //消えるまでの時間
    private float count;    //カウンター 
    private Light light;   //ライト
    private TargetStatus boxst;  //箱状態
	// Use this for initialization
	void Start () {
        boxst = GameObject.Find("運ぶ物").GetComponent<TargetStatus>();
        light = transform.Find("Point light").GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if (count > 0.7f)
            light.enabled = false ;
        if (count > disappeartime)
        {
            count = 0;
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovableObj"))
            boxst.burn();
    }
}

