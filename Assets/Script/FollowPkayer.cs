using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPkayer : MonoBehaviour {
    Vector3 rota;
	// Use this for initialization
	void Start () {
        rota = transform.eulerAngles;

    }
	
	// Update is called once per frame
	void Update () {
        rota = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(rota.x,rota.y, 0);
    }
}
