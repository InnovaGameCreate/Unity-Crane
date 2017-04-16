using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera[] cameraobj = new Camera[4];
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            cameraobj[0].enabled = true;
            cameraobj[1].enabled = cameraobj[2].enabled = cameraobj[3].enabled = false;
        }
        else if (Input.GetKey(KeyCode.Alpha2)) {
            cameraobj[1].enabled = true;
            cameraobj[0].enabled = cameraobj[2].enabled = cameraobj[3].enabled = false;

        } else if (Input.GetKey(KeyCode.Alpha3)) {
            cameraobj[2].enabled = true;
            cameraobj[0].enabled = cameraobj[1].enabled = cameraobj[3].enabled = false;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            cameraobj[3].enabled = true;
            cameraobj[0].enabled = cameraobj[1].enabled = cameraobj[2].enabled = false;
        }
            
    }
}
