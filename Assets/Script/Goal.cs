using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public ArmRotate armrotate;         //クレーンのArmを指定
    public GameObject clearui;           //クリアUI

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MovableObj") && !armrotate.get_catching())
            clearui.SetActive(true);

    }
}
