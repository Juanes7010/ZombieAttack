using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThirdPerson : MonoBehaviour
{
    [SerializeField] float sensibility = 80f;
    [SerializeField] Vector3 offset = new Vector3(0, 1.627f, 0.5f);

    Transform playerBody;
    float xRotation = 0;
    float yRotation = 0;
    void Start()
    {
        playerBody = GameObject.Find("Player").GetComponent<Transform>();
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
        transform.position = playerBody.position + offset;
        //playerBody.Rotate(Vector3.up * mouseX);
        playerBody.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
