using System.Collections;
using UnityEngine;

public class Effect : MonoBehaviour {
    public float mud_speed = 20000;
    public float save_speed = 3000;
    public WheelCollider RearRight;//後輪
    public WheelCollider RearLeft;

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerStay(Collider hit)
    {
        // 接触対象はCraneタグですか？
        if (hit.CompareTag("Crane"))
        {
            Debug.Log("a");
            if (RearRight.motorTorque > save_speed)
            {
                RearRight.motorTorque = RearLeft.motorTorque = -mud_speed;
            }
            else if (RearRight.motorTorque < -save_speed)
            {
                RearRight.motorTorque = RearLeft.motorTorque = mud_speed;
            }
        }
    }


}
