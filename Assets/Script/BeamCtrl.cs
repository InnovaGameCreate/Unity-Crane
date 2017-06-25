using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamCtrl : MonoBehaviour {
    //ビーコンを常に上側に打ち続けるためのスクリプト

    private Transform my_rot;

	void Start () {
        my_rot = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        
            gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

    }
}
