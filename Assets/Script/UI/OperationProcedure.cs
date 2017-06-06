using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationProcedure : MonoBehaviour
{
    Canvas canvas;

    // Use this for initialization
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
        }
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }
}
