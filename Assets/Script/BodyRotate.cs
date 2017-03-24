using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour {
    public float RotateSpeed = 5;
    private float Position;
	// Use this for initialization
	void Start () {
        Position = gameObject.transform.rotation.y;
           
       
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, Position, 0);
        if (Input.GetKey(KeyCode.H))
        {
            transform.Rotate(0, Position, 0);
            Position += RotateSpeed;
        }

        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(0, Position, 0);
            Position -= RotateSpeed;
        }
		
	}
}
