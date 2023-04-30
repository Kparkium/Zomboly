using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //-----------------------------------------------------------------[VARIABLES]-----------------------------------------------------------------

    public float mouseSensitivity;
    public float xRotation = 0f;
    public Transform playerModel;

    //-----------------------------------------------------------------[START]-----------------------------------------------------------------

    void Start()
    {
        // Set cursor to be locked to the screen
        Cursor.lockState = CursorLockMode.Locked;

        // to get out of lock mode Cursor.lockState = CursorLockMode.None;
    }

    //-----------------------------------------------------------------[UPDATE]-----------------------------------------------------------------

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -88f, 88f); // Clamp vertical camera rotation so can't flip camera upside down

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Move local camera
        playerModel.Rotate(Vector3.up * mouseX); // Move player model
    }
}
