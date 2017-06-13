using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavier : MonoBehaviour {
    private bool flag;
    private int maxsize = 2;
    private GameObject box;    //重くする運ぶ対象
    private bool bigger; //大きくなってるかどうか
    private float basescale;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (box != null && bigger == true)
        {
            if (box.transform.localScale.x < basescale)
                box.transform.localScale = new Vector3(box.transform.localScale.x + 0.1f, box.transform.localScale.y + 0.1f, box.transform.localScale.z + 0.1f);
            else
                bigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovableObj"))
        {
            box = other.gameObject;
            basescale = box.transform.localScale.x * 2;
            bigger = true;
            //Destroy(this.gameObject);
        }
    }
}
