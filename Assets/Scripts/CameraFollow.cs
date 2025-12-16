using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float sensibility = 300;

    Vector2 entradaAngulos;
    Vector2 angulos;

    [SerializeField] Vector2 limitesCamara;
    // Update is called once per frame
    void Update()
    {
        entradaAngulos = new Vector2(Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X")) * Time.deltaTime;
        angulos.x -= entradaAngulos.x * sensibility;
        angulos.y += entradaAngulos.y * sensibility;

        angulos.x = Mathf.Clamp(angulos.x, limitesCamara.x, limitesCamara.y);

        transform.localRotation = Quaternion.Euler(angulos.x, angulos.y, 0f);
    }
}
