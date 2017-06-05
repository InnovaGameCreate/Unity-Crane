using System.Collections;
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
		
        if(Input.GetKey(KeyCode.G))
        {
            transform.Rotate(new Vector3(0, 0, 1), -MoveSpeed);
        }
        if (Input.GetKey(KeyCode.T))
        {
            transform.Rotate(new Vector3(0, 0, 1), MoveSpeed);
        }

    }
}
