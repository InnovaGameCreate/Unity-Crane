using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour {
    public float MoveSpeed;
    private float LimitDown = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rot  =  GetComponent<Transform>().localRotation.eulerAngles;
        if (Input.GetKey(KeyCode.W))
        {
            rot = new Vector3(rot.x - MoveSpeed, rot.y, rot.z );
            if (rot.x < 320)
                transform.Rotate(new Vector3(1, 0, 0), -MoveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rot = new Vector3(rot.x + MoveSpeed, rot.y, rot.z );
            if (rot.x >273)
                transform.Rotate(new Vector3(1, 0, 0), MoveSpeed);
     
        }

    }
}
