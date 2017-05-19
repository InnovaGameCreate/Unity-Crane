﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour {
    public float MoveSpeed;
    private float LimitDown = -10;
    public GameObject crane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rot  =  GetComponent<Transform>().localRotation.eulerAngles;
        if (Input.GetKey(KeyCode.W))
        {
            rot = new Vector3(rot.x, rot.y, rot.z - MoveSpeed);
            if (rot.z > 325)
                transform.Rotate(new Vector3(0, 0, 1), -MoveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rot = new Vector3(rot.x, rot.y, rot.z + MoveSpeed);
            if (rot.z<360&&rot.z>325)
                transform.Rotate(new Vector3(0, 0, 1), MoveSpeed);
        }

    }
}
