using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson2 : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [Range (0,1)] [SerializeField] float lerpVal;
    [SerializeField] float sensibility;

    Transform target;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpVal);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
