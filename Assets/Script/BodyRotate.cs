using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour {
    public float RotateSpeed = 5;
    private float Position;
    private float BeforePosition;
    private float relationPosition;
	// Use this for initialization
	void Start () {
        Position = gameObject.transform.rotation.y;
       
	}
	
	// Update is called once per frame
	void Update () {

            transform.Rotate(0,  Position, 0);
       
        if (Input.GetKey(KeyCode.H))
        {
            Position += RotateSpeed;
            BeforePosition = gameObject.transform.rotation.y;
            transform.Rotate(0, Position, 0);
        }

        if(Input.GetKey(KeyCode.F))
        {
            Position -= RotateSpeed;
            BeforePosition = gameObject.transform.rotation.y;
            transform.Rotate(0, Position, 0);
        }
  

    }
}
