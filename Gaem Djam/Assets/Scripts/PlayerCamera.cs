using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform viewer;
    
    private float xRotation;
    private float yRotation;

    void Awake()
    {
        viewer = transform.Find("Viewer");
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y");
        xRotation = Mathf.Clamp(xRotation, -90f, 90);
        yRotation += Input.GetAxis("Mouse X");
    }

    void LateUpdate()
    {
        viewer.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
