using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    [SerializeField] private float mouseSensetivity = 2f;
    float xRotation = 0f;
    float yRotation = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

       
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        xRotation += mouseX;
        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }
}
