using System.Collections;
using UnityEngine;

public class Effect : MonoBehaviour {
    public float mud_speed = 50000;
    public WheelCollider RearRight;//後輪
    public WheelCollider RearLeft;

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerStay(Collider hit)
    {
        // 接触対象はCraneタグですか？
        if (hit.CompareTag("Crane"))
        {
            Debug.Log("a");
            if (RearRight.motorTorque == -9000)
            {
                RearRight.brakeTorque = RearLeft.brakeTorque = mud_speed;
                Debug.Log("b");
            }
            else if (RearRight.motorTorque == 9000)
            {
                RearRight.brakeTorque = RearLeft.brakeTorque = mud_speed;
                Debug.Log("c");
            }
        }
    }


}
