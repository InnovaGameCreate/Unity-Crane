using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRectTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //ScrollRectが更新されず子要素が表示されないので値を変えて無理やり更新
        GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
