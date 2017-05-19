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
        Vector3 rot = GetComponent<Transform>().localRotation.eulerAngles;
        transform.Rotate(0,  Position, 0);
        if (Input.GetKey(KeyCode.D))
        {
            rot = new Vector3(rot.x, rot.y + RotateSpeed, rot.z);
      //      Position += RotateSpeed;
           // BeforePosition = gameObject.transform.rotation.y;
        //    transform.Rotate(0, Position, 0);
            if (rot.y < 90|| rot.y>270)
                transform.Rotate(new Vector3(0, 1, 0), RotateSpeed);
        }

       else if(Input.GetKey(KeyCode.A))
        {
            rot = new Vector3(rot.x, rot.y - RotateSpeed, rot.z);

            //Position -= RotateSpeed;
            //BeforePosition = gameObject.transform.rotation.y;
           // transform.Rotate(0, Position, 0);

            if (rot.y > 270|| rot.y < 90)
                transform.Rotate(new Vector3(0, 1, 0), -RotateSpeed);
        }
  

    }
}
