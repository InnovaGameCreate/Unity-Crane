using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : MonoBehaviour {
    private const int disappeartime = 10;  //消えるまでの時間
    private float count;    //カウンター 
    // Use this for initialization
    void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if (count > disappeartime)
        {
            count = 0;
            Destroy(this.gameObject);
        }
    }
}
