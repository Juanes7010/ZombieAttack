using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    [SerializeField] float sensibility = 80f;
    [SerializeField] Vector3 offset = new Vector3(0, 1.627f, 0.5f);

    Transform playerBody;
    Health health;
    float xRotation = 0;
    float yRotation = 0;
    void Start()
    {
        playerBody = GameObject.Find("Player").GetComponent<Transform>();
        health = GameObject.Find("Player").GetComponent<Health>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        yRotation = Mathf.Clamp(yRotation, -36000, 36000);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.position = playerBody.position + new Vector3(0,offset.y,0);
        //playerBody.Rotate(Vector3.up * mouseX);
        if (!health.ReturnGameOver())
        {
            playerBody.localRotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
