using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackHinge : MonoBehaviour {

    GameObject CRANE;
	// Use this for initialization
	void Start () {
        this.CRANE = GameObject.Find("crane");

    }
	
	// Update is called once per frame
	void Update () {
		        GetComponent<HingeJoint>().anchor = new Vector3(this.CRANE.transform.position.x -1, this.CRANE.transform.position.y, this.CRANE.transform.position.z);

	}
}
