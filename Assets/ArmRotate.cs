using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour {
    public GameObject RightArm; //アーム下部
    public GameObject LeftArm;
    public GameObject RightArm1; //アーム上部
    public GameObject LeftArm1;
    public float RotateSpeed;
    private bool MaxRotate; //アームの閉じる限界角度
    private bool MinRotate; //アームの開く限界角度
    private float valArmRotation;
	// Use this for initialization
	void Start () {
        MaxRotate = false;
        MinRotate = false;
        valArmRotation = RightArm.transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {

        //アームの開閉の限界判定（rotation.zで判定すると揺れでzのrotationが変化するため不規則になる)
        if (valArmRotation <= -20)//ここらへんごり押し
            MaxRotate = true;
        else
            MaxRotate = false;

        if (valArmRotation >= 5)//ここらへんごり押し
            MinRotate = true;
        else
            MinRotate = false;

        //スペースがアーム閉　Ｘが開
        if (Input.GetKey(KeyCode.Space) && !MaxRotate)
        {
 
            RightArm.transform.Rotate(0, 0, -RotateSpeed);
            LeftArm.transform.Rotate(0, 0, RotateSpeed);
            RightArm1.transform.Rotate(0, 0, RotateSpeed);
            LeftArm1.transform.Rotate(0, 0, -RotateSpeed);
            valArmRotation -= RotateSpeed;
        }
        if (Input.GetKey(KeyCode.X) && !MinRotate)
        {

            RightArm.transform.Rotate(0, 0, RotateSpeed);
            LeftArm.transform.Rotate(0, 0, -RotateSpeed);
            RightArm1.transform.Rotate(0, 0, -RotateSpeed);
            LeftArm1.transform.Rotate(0, 0, RotateSpeed);
            valArmRotation += RotateSpeed;

        }
    }
}
